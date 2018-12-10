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
    public partial class MisReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                    cargarReservas();
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }


        }

        private void cargarReservas()
        {
            try
            {
                if (Context.User.IsInRole("Administrador"))
                {
                    gvReserva.DataSource = BIZReserva.MisReservasSelectAllByEstadoPago(true);
                    gvReserva.DataBind();

                    gvReservasPendientes.DataSource = BIZReserva.MisReservasSelectAllByEstadoPago(false);
                    gvReservasPendientes.DataBind();


                }
                else
                {
                    gvReserva.DataSource = BIZReserva.MisReservasSelectByPagoStateAndUserId(true, User.Identity.GetUserId());
                    gvReserva.DataBind();

                    gvReservasPendientes.DataSource = BIZReserva.MisReservasSelectByPagoStateAndUserId(false, User.Identity.GetUserId());
                    gvReservasPendientes.DataBind();

                }


                CultureInfo us = new CultureInfo("es-ES");
                if (gvReserva.Rows.Count > 0)
                {

                    //Attribute to show the Plus Minus Button.
                    gvReserva.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvReserva.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvReserva.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;

                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void gvReserva_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReserva.PageIndex = e.NewPageIndex;
            cargarReservas();
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
            body = body.Replace("{Accion}", "Tu reserva ha sido cancelada:");
            body = body.Replace("{Plaza}", txtIdReserva.Text);
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

        protected void gvReserva_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdReserva.Text = gvReserva.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            txtdescEstacionamiento.Text = gvReserva.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtCalle.Text = gvReserva.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            txtAltura.Text = gvReserva.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            txtdatosAdicionales.Text = gvReserva.Rows[e.NewEditIndex].Cells[4].Text.ToString();
            txtdescBarrio.Text = gvReserva.Rows[e.NewEditIndex].Cells[5].Text.ToString();
            txtUser.Text = gvReserva.Rows[e.NewEditIndex].Cells[6].Text.ToString();

            e.Cancel = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisReservas.aspx");

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                BIZPlaza.UpdateNOAvailable(Convert.ToInt32(txtIdReserva.Text), User.Identity.GetUserId());

                //envio mail
                Send_Info_Reserva(User.Identity.GetUserId());

                txtIdReserva.Text = "";
                txtdescEstacionamiento.Text = "";
                txtdescBarrio.Text = "";
                txtdatosAdicionales.Text = "";
                txtCalle.Text = "";
                txtAltura.Text = "";
                txtUser.Text = "";

                txtIdReserva.Visible = true;
                lblIdReserva.Visible = true;

                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                //divPrecio.Visible = false;
                lblMensaje.Text = string.Empty;

                cargarReservas();

            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }

    }

        protected void gvReserva_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ImprimirReserva")
            {
                Response.Redirect("Reserva.aspx?pPurchaseOrderID=" + e.CommandArgument);
            }

        }

        protected void gvReservasPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Pagar")
            {

                //string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
                //string pNroReserva = valores[0];
                //string pPrecio = valores[1];
                //Response.Redirect("PagoReserva.aspx?pnr=" + pNroReserva + "?ppr=" + pPrecio);

                string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
                Session["Nro_Reserva"] = valores[0];
                double importe = Convert.ToDouble(valores[1]);
                Session["Importe_Reserva"] = importe;
                Response.Redirect("PagoReserva");



            }

        }

        protected void gvReservasPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReservasPendientes.PageIndex = e.NewPageIndex;
            cargarReservas();

        }

        protected void gvReservasPendientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdReserva.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            txtdescEstacionamiento.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtCalle.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            txtAltura.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            txtdatosAdicionales.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[4].Text.ToString();
            txtdescBarrio.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[5].Text.ToString();
            txtUser.Text = gvReservasPendientes.Rows[e.NewEditIndex].Cells[6].Text.ToString();

            e.Cancel = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }
    }
}