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
using System.Data;

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
                gvPlaza.DataSource = Session["PlazasFiltradas"];//BIZPlaza.SelectAll(idTipoEstadia, idZona, fechaDesde, fechaHasta);
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
                DataSet dsPlazaDisponible;

                if (!FechasValidas())
                {
                    if (ddlTipoAlquiler.SelectedValue == "1")
                        ((SiteMaster)this.Master).ShowMessage("<strong>Verifique las fechas ingresadas</strong>", SiteMaster.WarningType.Warning);
                    else
                        ((SiteMaster)this.Master).ShowMessage("<strong>Verifique la fecha y horas ingresadas</strong>", SiteMaster.WarningType.Warning);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
                    return;
                }

                if (ddlTipoAlquiler.SelectedValue == "1")
                    dsPlazaDisponible  = BIZPlaza.SelectDisponibilidadByPlaza(int.Parse(txtIdPlaza.Text), Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text));
                else
                    dsPlazaDisponible = BIZPlaza.SelectDisponibilidadByPlaza(int.Parse(txtIdPlaza.Text), Convert.ToDateTime(txtFecha.Text), Convert.ToDateTime(txtFecha.Text));
                if (dsPlazaDisponible.Tables.Count > 0 && dsPlazaDisponible.Tables[0].Rows.Count > 0)
                {
                    if (ddlTipoAlquiler.SelectedValue == "1")
                    {
                        //lblMensaje.Text = "La plaza no está disponible en la fecha seleccionada";
                        //lblMensaje.Visible = true;                        
                        ((SiteMaster)this.Master).ShowMessage("<strong>La plaza no está disponible en la fecha seleccionada</strong>", SiteMaster.WarningType.Warning);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
                        return;
                    }
                    else
                    {
                        foreach(DataRow dr in dsPlazaDisponible.Tables[0].Rows)
                        {
                            int horaInicio = int.Parse(dr["horaDesde"].ToString().Substring(0, 2)) * 100;
                            int horaFin = int.Parse(dr["horaHasta"].ToString().Substring(0, 2)) * 100;

                            int horaInicioSeleccionada = int.Parse(txtHoraDesde.Text.Substring(0, 2)) * 100 + 1;
                            int horaFinSeleccionada = int.Parse(txtHoraHasta.Text.Substring(0, 2)) * 100 -1;

                            if (horaInicioSeleccionada > horaInicio && horaInicioSeleccionada < horaFin)
                            {
                                //lblMensaje.Text = "La plaza no está disponible en la hora seleccionada";
                                //lblMensaje.Visible = true;                                
                                ((SiteMaster)this.Master).ShowMessage("<strong>La plaza no está disponible en la hora seleccionada</strong>", SiteMaster.WarningType.Warning);
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
                                return; 
                            }
                            else if (horaFinSeleccionada > horaInicio && horaFinSeleccionada < horaFin)
                            {
                                //lblMensaje.Text = "La plaza no está disponible en la hora seleccionada";
                                //lblMensaje.Visible = true;
                                ((SiteMaster)this.Master).ShowMessage("<strong>La plaza no está disponible en la hora seleccionada</strong>", SiteMaster.WarningType.Warning);
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);                                
                                return; 
                            }
                        }
                    }
                }
                
                //BIZPlaza.UpdateAvailable(Convert.ToInt32(txtIdPlaza.Text), User.Identity.GetUserId());
                if (ddlTipoAlquiler.SelectedValue == "1")
                    BIZReserva.Insert(Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), null, null, int.Parse(txtIdPlaza.Text), User.Identity.GetUserId());
                else
                    BIZReserva.Insert(Convert.ToDateTime(txtFecha.Text), Convert.ToDateTime(txtFecha.Text), txtHoraDesde.Text, txtHoraHasta.Text, int.Parse(txtIdPlaza.Text), User.Identity.GetUserId());
                //envio mail
                BIZBitacora.Insert(Utils.GetDateTimeLocal(), Context.User.Identity.GetUserId(), "ALTA", "Reserva");
                try
                {
                    Send_Info_Reserva(User.Identity.GetUserId());
                }
                catch (Exception)
                {

                    //Si no envia mail no arrojo error.
                }


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
                lblMensajeError.Text = string.Empty;
                //cargarPlazas();
                Response.Redirect("~/MisReservas.aspx", false);
                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }

        }

        protected void gvPlaza_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMensajeError.Text = string.Empty;

            DataSet dsPagosPendientes = BIZReserva.MisReservasSelectByPagoStateAndUserId(false, User.Identity.GetUserId());
            if (dsPagosPendientes.Tables.Count > 0 && dsPagosPendientes.Tables[0].Rows.Count > 0)
            {
                lblMensajeError.Text = "No puede generar la reserva: Tiene reserva pendiente de pago.";

                //((SiteMaster)this.Master).ShowMessage("<strong>No puede generar la reserva: Tiene reserva pendiente de pago.</strong>", SiteMaster.WarningType.Warning);
            }
            else
            { 
                pnlTab1.Visible = false;
                pnlTab2.Visible = true;

                txtIdPlaza.Text = gvPlaza.Rows[e.NewEditIndex].Cells[0].Text.ToString();
                //txtdescEstacionamiento.Text = gvPlaza.Rows[e.NewEditIndex].Cells[1].Text.ToString();
                txtdescEstacionamiento.Text = ((Label)gvPlaza.Rows[e.NewEditIndex].FindControl("lblTarifa")).Text.Substring(1);
                ddlTipoAlquiler.SelectedValue = gvPlaza.Rows[e.NewEditIndex].Cells[1].Text.ToString().Equals("Diario") ? "1" : "2";//((Label)gvPlaza.Rows[e.NewEditIndex].FindControl("lblTipoEstadiaId")).Text.Substring(1);
                txtCalle.Text = gvPlaza.Rows[e.NewEditIndex].Cells[3].Text.ToString();
                txtAltura.Text = gvPlaza.Rows[e.NewEditIndex].Cells[4].Text.ToString();
                txtdatosAdicionales.Text = gvPlaza.Rows[e.NewEditIndex].Cells[5].Text.ToString();
                txtdescBarrio.Text = gvPlaza.Rows[e.NewEditIndex].Cells[6].Text.ToString();
                

                /*if (Request.Browser.Browser == "Chrome")
                {
                    txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    txtFechaDesde.Text = DateTime.Today.ToString("yyyy-MM-dd");
                    txtFechaHasta.Text = DateTime.Today.ToString("yyyy-MM-dd");

                }
                else
                {
                    txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtFechaDesde.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtFechaHasta.Text = DateTime.Today.ToString("dd/MM/yyyy");
                
                }*/

                if (ddlTipoAlquiler.SelectedValue == "1")
                {
                    divDiario.Visible = true;
                    divHora.Visible = false;
                }
                else
                {
                    divDiario.Visible = false;
                    divHora.Visible = true;
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
                
            }
            e.Cancel = true;
        }

        protected void gvPlaza_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPlaza.PageIndex = e.NewPageIndex;
            cargarPlazas();

        }

        private bool FechasValidas()
        {
            if (ddlTipoAlquiler.SelectedValue == "1")
            {
                if (string.IsNullOrEmpty(txtFechaDesde.Text) || string.IsNullOrEmpty(txtFechaHasta.Text))
                    return false;
                DateTime fecha;
                if (!DateTime.TryParse(txtFechaDesde.Text, out fecha) || !DateTime.TryParse(txtFechaHasta.Text, out fecha))
                    return false;

                if (DateTime.Parse(txtFechaDesde.Text) > DateTime.Parse(txtFechaHasta.Text))
                    return false;

                if (DateTime.Today.Date > DateTime.Parse(txtFechaDesde.Text))
                    return false;
                    
            }
            else
            {
                if (string.IsNullOrEmpty(txtFecha.Text))
                    return false;

                if (string.IsNullOrEmpty(txtHoraDesde.Text) || string.IsNullOrEmpty(txtHoraHasta.Text))
                    return false;

                if (int.Parse(txtHoraDesde.Text.Substring(0, 2)) >= int.Parse(txtHoraHasta.Text.Substring(0, 2)))
                    return false;
                

                if (Utils.GetDateTimeLocal().Hour > int.Parse(txtHoraDesde.Text.Substring(0, 2)))
                    return false;
            }
            return true;
        }
    }
}