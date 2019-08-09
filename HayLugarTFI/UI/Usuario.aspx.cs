using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace UI
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                if (Context.User.IsInRole("Administrador"))
                {
                    cargarZonas();
                }
                else
                {
                    Response.Redirect("ErrorAcceso.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }


        }

        private void cargarZonas()
        {
            try
            {
                CultureInfo us = new CultureInfo("es-ES");
                gvUsuario.DataSource = BIZDatosPersonales.SelectAll();
                gvUsuario.DataBind();

                //Attribute to show the Plus Minus Button.
                gvUsuario.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                gvUsuario.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                gvUsuario.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            catch (Exception)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            titleProdAccion.InnerText = "Agregar Usuario";

            pnlTab1.Visible = false;
            pnlTab2.Visible = true;


            txtUsuarioId.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            ddlRol.SelectedValue = "2";

            txtNroDocumento.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCuil.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtPatente.Text = string.Empty;
            lblValicionCuil.Text = string.Empty;
            txtUsuarioId.Visible = false;
            lblUsuarioId.Visible = false;
            txtMail.Enabled = true;
            //txtDescripcion.Enabled = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuario.PageIndex = e.NewPageIndex;
            cargarZonas();

        }

        protected void gvUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtUsuarioId.Text = gvUsuario.Rows[e.NewEditIndex].Cells[0].Text.ToString().Replace("&nbsp;", ""); ;
            txtApellido.Text = gvUsuario.Rows[e.NewEditIndex].Cells[1].Text.ToString().Replace("&nbsp;", ""); ;
            txtNombre.Text = gvUsuario.Rows[e.NewEditIndex].Cells[2].Text.ToString().Replace("&nbsp;", ""); ;
            ddlRol.SelectedValue = ((Label)gvUsuario.Rows[e.NewEditIndex].FindControl("lblIdRol")).Text;
            ddlTipoDocumento.Text = gvUsuario.Rows[e.NewEditIndex].Cells[4].Text.ToString();
            txtNroDocumento.Text = gvUsuario.Rows[e.NewEditIndex].Cells[5].Text.ToString().Replace("&nbsp;", ""); ;
            txtMail.Text = gvUsuario.Rows[e.NewEditIndex].Cells[6].Text.ToString().Replace("&nbsp;", ""); ;
            txtMail.Enabled = false;
            txtTelefono.Text = gvUsuario.Rows[e.NewEditIndex].Cells[7].Text.ToString().Replace("&nbsp;", ""); ;
            e.Cancel = true;

            if (ddlRol.SelectedValue == "2" || ddlRol.SelectedValue == "4")
            {
                divConductor.Visible = true;
                DataSet dsVehiculo = BIZVehiculo.SelectByIdUsr(txtUsuarioId.Text);
                txtMarca.Text = dsVehiculo.Tables[0].Rows[0]["marca"].ToString();
                txtModelo.Text = dsVehiculo.Tables[0].Rows[0]["modelo"].ToString();
                txtPatente.Text = dsVehiculo.Tables[0].Rows[0]["patente"].ToString();
                hdIdVehiculo.Value = dsVehiculo.Tables[0].Rows[0]["idVehiculo"].ToString();
            }
            else
            {
                divConductor.Visible = false;
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;

                if (!string.IsNullOrEmpty(txtCuil.Text))
                {
                    bool cuilValido = BIZUtilites.ValidaCuit(txtCuil.Text);
                    if (!cuilValido) { 
                        lblMensaje.Text = "Verifique el CUIL";
                        return;
                    }
                }

                if (txtUsuarioId.Text == string.Empty)
                {

                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                    var user = new ApplicationUser() { UserName = txtMail.Text, Email = txtMail.Text };
                    IdentityResult result = manager.Create(user, "Dni" + "-" + txtNroDocumento.Text);
                    if (result.Succeeded)
                    {

                        //inserto el ROL para el usuario
                        BIZAspNetUserRoles.Insert(user.Id, ddlRol.SelectedValue);

                        //agregado para crear cuenta corriente cuando se registra                        
                        BIZCuentaCorriente.Insert(user.Id, 100, DateTime.Now);

                        BIZDatosPersonales.Insert(user.Id, ddlTipoDocumento.SelectedValue, txtNroDocumento.Text, txtMail.Text, txtTelefono.Text, string.Empty, string.Empty, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtCuil.Text);
                        BIZVehiculo.Insert(user.Id, txtMarca.Text, txtModelo.Text, txtPatente.Text);

                        //envio mail
                        Send_Account_Activation_Link(txtMail.Text, user.Id);

                        // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                        //string code = manager.GenerateEmailConfirmationToken(user.Id);
                        //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                        //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                        //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);

                    }

                    

                }
                else
                {
                    
                    //actualizo el ROL para el usuario
                    BIZAspNetUserRoles.Update(txtUsuarioId.Text, ddlRol.SelectedValue);

                    BIZDatosPersonales.Update(txtUsuarioId.Text, ddlTipoDocumento.SelectedValue, txtNroDocumento.Text, txtMail.Text, txtTelefono.Text, string.Empty, string.Empty, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtCuil.Text);
                    if (!string.IsNullOrEmpty(hdIdVehiculo.Value))
                    {
                        BIZVehiculo.Update(Convert.ToDecimal(hdIdVehiculo.Value), txtUsuarioId.Text, txtMarca.Text, txtModelo.Text, txtPatente.Text);
                    }
                    

                }
                txtUsuarioId.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtNombre.Text = string.Empty;
                ddlRol.SelectedValue = "2";

                txtNroDocumento.Text = string.Empty;
                txtMail.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtCuil.Text = string.Empty;
                txtMarca.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtPatente.Text = string.Empty;

                txtUsuarioId.Visible = true;
                lblUsuarioId.Visible = true;

                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                //divPrecio.Visible = false;
                lblMensaje.Text = string.Empty;
                cargarZonas();
                
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuario.aspx");

        }

        protected void gvUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idZona = (int)gvUsuario.DataKeys[e.RowIndex].Value;
                BIZZona.Delete(idZona);
                cargarZonas();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "alert('No se pudo eliminar la zona');", true);
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
                body = body.Replace("{UserName}", txtMail.Text);
                body = body.Replace("{UserPass}", txtNroDocumento.Text);
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

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRol.SelectedValue == "3" || ddlRol.SelectedValue == "1")
            {
                divConductor.Visible = false;
            }
            else
            {
                divConductor.Visible = true;
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            bool cuilValido = BIZUtilites.ValidaCuit(txtCuil.Text);

            if (cuilValido)
            {
                lblValicionCuil.ForeColor = Color.Green;
                lblValicionCuil.Text = "Correcto";
            }
            else
            {
                lblValicionCuil.ForeColor = Color.Red;
                lblValicionCuil.Text = "CUIL Inválido";
            }
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaMasivaUsuario.aspx");
        }
    }
}