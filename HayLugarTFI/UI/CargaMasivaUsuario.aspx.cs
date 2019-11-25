using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Net.Mail;
using System.Text;
using System.Drawing;
using BIZ;

namespace UI
{
    public partial class CargaMasivaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadArchivo(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);
            string xml = File.ReadAllText(filePath);

            string extension = fileName.Split('.').Length > 0 ? fileName.Split('.')[fileName.Split('.').Length - 1] : "";

            if(!extension.ToUpper().Equals("CSV"))
            {
                lblMje.ForeColor = Color.Red;
                lblMje.Text = "El archivo debe tener extension CSV.";
                return;
            }

            using (var reader = new StreamReader(@filePath))
            {

                
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                int registro = 0;
                while (!reader.EndOfStream)
                {
                    registro++;
                    try 
	                {
                        var line = reader.ReadLine();
                        string[] values = line.Split(';');

                        if (values.Length == 11 || values.Length == 8)
                        {
                            if((values[7] == "2" || values[7] == "4") && values.Length != 11)
                            {
                                txtResultado.Text += "Se produjo error al procesar el registro Nº " + registro + ": Si el usuario es Conductor debe indicar datos del vehículo.\n";
                            }
                            else
                            {
                                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                                var user = new ApplicationUser() { UserName = values[0], Email = values[0] };
                                IdentityResult result = manager.Create(user, "Dni" + "-" + values[2]);
                                if (result.Succeeded)
                                {

                                    //inserto el ROL para el usuario
                                    BIZAspNetUserRoles.Insert(user.Id, values[7]);

                                    //agregado para crear cuenta corriente cuando se registra                        
                                    BIZCuentaCorriente.Insert(user.Id, 100, DateTime.Now);

                                    BIZDatosPersonales.Insert(user.Id, values[1], values[2], values[0], values[5], string.Empty, string.Empty, values[4], values[3], values[6], string.Empty);
                                    if (values[7] == "2" || values[7] == "4")
                                    {
                                        BIZVehiculo.Insert(user.Id, values[8], values[9], values[10]);
                                    }

                                    BIZBitacora.Insert(DateTime.Now, Context.User.Identity.GetUserId(), "ALTA", "Carga Masiva Usuarios");

                                    //envio mail
                                    Send_Account_Activation_Link(values[0], user.Id, values[2]);

                                    txtResultado.Text += "Registro Nº " + registro + " OK\n";
                                }
                                else
                                {
                                    txtResultado.Text += "Se produjo error al procesar el registro Nº " + registro + " " + result.Errors.First() + "\n";
                                }
                            }
                            
                        }
                        else
                        {
                            txtResultado.Text += "Se produjo error al procesar el registro Nº " + registro + ": La cantidad de campos no es correcta.\n";
                        }
	                }
                    catch (Exception ex)
                    {
                        txtResultado.Text += "Se produjo error al procesar el registro Nº " + registro + " " + ex.Message + ".\n";
                        
                    }
                    
                }
            }
            
            
            
        }

        protected void btnCargaMasivaBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario");
        }
        private void Send_Account_Activation_Link(string emailaddress, string userId, string nroDocumento)
        {
            try
            {


                string constr = BIZUtilites.getConnection();
                string activationCode = Guid.NewGuid().ToString();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }



                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                //mail.From = new MailAddress("info.conelmed@gmail.com", "Info LO DE FITO", Encoding.UTF8);
                mail.From = new MailAddress("haylugararg@gmail.com", "Info Hay Lugar", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = "Hay Lugar - Alta de usuario";
                //Aquí ponemos el mensaje que incluirá el correo

                string body = string.Empty;

                string urlFinal = @"http://haylugar.somee.com/Account/CS_Activation.aspx?ActivationCode=" + activationCode;

                body += "<br /><br />Ingresa al siguiente enlace para activar tu cuenta:";
                body += "<br /><br />";
                body += "<br /><a href ='" + urlFinal + "'>ACTIVAR CUENTA</a>";
                body += "<br /><br />";


                using (StreamReader reader = new StreamReader(Server.MapPath("~/Uploads/EmailTemplate.htm")))
                {
                    body += reader.ReadToEnd();
                }
                string url = "www.haylugar.somee.com";
                body = body.Replace("{UserName}", emailaddress);
                body = body.Replace("{UserPass}", nroDocumento);
                body = body.Replace("{Url}", url);
                body = body.Replace("{activationCode}", activationCode);

                mail.Body = body;
                mail.IsBodyHtml = true;

                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add(emailaddress);

                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));

                //Configuracion del SMTP
                SmtpServer.Port = 25; //Puerto que utiliza Gmail para sus servicios 587
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("haylugararg@gmail.com", "sandra2017");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                //String err = 
                //lblErrorMail.Text = ex.Message;

            }

        }

    }
}