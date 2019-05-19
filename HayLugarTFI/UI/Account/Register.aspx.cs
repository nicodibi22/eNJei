using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using UI.Models;
using BIZ;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace UI.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {

                //inserto el ROL para el usuario
                BIZAspNetUserRoles.Insert(user.Id, ddlRol.SelectedValue);

                //agregado para crear cuenta corriente cuando se registra
                AltaCuentaCorriente(user.Id);

                AltaDatosPersonales(user.Id, Email.Text);


                //envio mail
                Send_Account_Activation_Link(Email.Text, user.Id);

                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);

                Response.Redirect("~/Account/ActivacionPendiente.aspx");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void AltaDatosPersonales(string id, string email)
        {
            try
            {
                BIZDatosPersonales.Insert(id, "DNI", "00000000", email, "9999999999", "MOVIL", "Nombre Apellido", string.Empty, string.Empty, string.Empty, string.Empty);
                BIZVehiculo.Insert(id, "MARCA", "MODELO", "XXX XXX");
            }
            catch (Exception)
            {
                return;
            }
        }

        private void AltaCuentaCorriente(string id)
        {
            try
            {
                BIZCuentaCorriente.Insert(id, 100, DateTime.Now);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void Send_Account_Activation_Link(string emailaddress, string userId)
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
                body = body.Replace("{UserName}", Email.Text);
                body = body.Replace("{UserPass}", Password.Text);
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
                lblErrorMail.Text = ex.Message;

            }

        }
    }
}