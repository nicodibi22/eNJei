using BIZ;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace UI
{
    public partial class ModificarPlaza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                cargarPlazas();
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlazasDisponibles.aspx");
        }

        private void cargarPlazas()
        {
            try
            {
                CultureInfo us = new CultureInfo("es-ES");
                gvPlaza.DataSource = BIZPlaza.SelectAll();
                gvPlaza.DataBind();

                if (gvPlaza.Rows.Count > 0)
                {
                    //Attribute to show the Plus Minus Button.
                    gvPlaza.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvPlaza.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvPlaza.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }

        private void Send_Info_Reserva(string userId)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            //mail.From = new MailAddress("info.conelmed@gmail.com", "Info LO DE FITO", Encoding.UTF8);
            mail.From = new MailAddress("haylugararg@gmail.com", "Info Hay Lugar", Encoding.UTF8);
            //Aquí ponemos el asunto del correo
            mail.Subject = "Hay Lugar - Reserva";
            //Aquí ponemos el mensaje que incluirá el correo

            string body = string.Empty;

            using (StreamReader reader = new StreamReader(Server.MapPath("~/Uploads/EmailTemplateReserva.htm")))
            {
                body += reader.ReadToEnd();
            }

            string url = "www.haylugar.somee.com";
            body = body.Replace("{UserName}", User.Identity.GetUserName());
            body = body.Replace("{Accion}", "Tu reserva ha sido confirmada:");
            body = body.Replace("{Plaza}", txtIdPlaza.Text);
            body = body.Replace("{Direccion}", txtCalle.Text + " " + txtAltura.Text + " - " + txtdatosAdicionales.Text + " - " + txtdescBarrio.Text);
            body = body.Replace("{Url}", url);

            mail.Body = body;
            mail.IsBodyHtml = true;

            //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
            mail.To.Add(User.Identity.GetUserName());

            //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
            //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));

            //Configuracion del SMTP
            SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
            //Especificamos las credenciales con las que enviaremos el mail
            SmtpServer.Credentials = new System.Net.NetworkCredential("haylugararg@gmail.com", "sandra2017");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                BIZPlaza.UpdateAvailable(Convert.ToInt32(txtIdPlaza.Text), User.Identity.GetUserId());

                //envio mail
                Send_Info_Reserva(User.Identity.GetUserId());
                
                txtIdPlaza.Text = "";
                txtdescEstacionamiento.Text = "";
                txtdescBarrio.Text = "";
                txtdatosAdicionales.Text = "";
                txtCalle.Text = "";
                txtAltura.Text = "";

                txtIdPlaza.Visible = true;
                lblIdPlaza.Visible = true;

                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                //divPrecio.Visible = false;
                lblMensaje.Text = string.Empty;
                cargarPlazas();
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }

        }

        protected void gvPlaza_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdPlaza.Text = gvPlaza.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            //txtdescEstacionamiento.Text = gvPlaza.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtdescEstacionamiento.Text = ((Label)gvPlaza.Rows[e.NewEditIndex].FindControl("lblTarifa")).Text.Substring(1);

            txtCalle.Text = gvPlaza.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            txtAltura.Text = gvPlaza.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            txtdatosAdicionales.Text = gvPlaza.Rows[e.NewEditIndex].Cells[4].Text.ToString();
            txtdescBarrio.Text = gvPlaza.Rows[e.NewEditIndex].Cells[5].Text.ToString();
            e.Cancel = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void gvPlaza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPlaza.PageIndex = e.NewPageIndex;
            cargarPlazas();

        }
    }
}