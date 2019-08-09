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

namespace UI
{
    public partial class Reclamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                if (Context.User.IsInRole("Conductor") || Context.User.IsInRole("Cond_Prop") || Context.User.IsInRole("Administrador"))
                {
                    if (!IsPostBack)
                        cargarEstacionamientos();
                }
                else
                {
                    Response.Redirect("~/ErrorAcceso.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        private void cargarEstacionamientos()
        {
            ddlReserva.DataSource = BIZReserva.ReservaPagaSelectByIdUsuario(Context.User.Identity.GetUserId());
            ddlReserva.DataValueField = "idReserva";
            ddlReserva.DataTextField = "descripcion";
            ddlReserva.DataBind();
            
            try
            {
                CultureInfo us = new CultureInfo("es-ES");
                if (Context.User.IsInRole("Administrador"))
                    gvReclamo.DataSource = BIZReclamo.SelectAll();
                else
                    gvReclamo.DataSource = BIZReclamo.SelectByIdUser(Context.User.Identity.GetUserId());
                gvReclamo.DataBind();
                
                if (gvReclamo.Rows.Count > 0)
                {
                    //Attribute to show the Plus Minus Button.
                    gvReclamo.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvReclamo.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvReclamo.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception)
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaMasiva.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            titleProdAccion.InnerText = "Agregar Reclamo";

            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdReclamo.Visible = false;
            lblIdReclamo.Visible = false;

            txtPatenteInfractor.Enabled = true;
            ddlReserva.Enabled = true;
            
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void gvReclamo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdReclamo.Text = gvReclamo.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            //txtDescripcion.Text = gvReclamo.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtPatenteInfractor.Text = ((Label)gvReclamo.Rows[e.NewEditIndex].FindControl("lblDescripcion")).Text.Substring(1).Replace(".", "").Replace(",", ".");

            
            e.Cancel = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);

        }

        protected void gvReclamo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReclamo.PageIndex = e.NewPageIndex;
            cargarEstacionamientos();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estacionamiento.aspx");

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            try
            {
                lblMensaje.Text = string.Empty;
                if (txtIdReclamo.Text == string.Empty)
                {
                    
                    int idReclamo = BIZReclamo.Insert(int.Parse(ddlReserva.SelectedValue), txtPatenteInfractor.Text, Context.User.Identity.GetUserId());

                    /*string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Uploads/") + fileName;
                    FileUpload1.SaveAs(filePath);
                    */
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string pathImagen = Server.MapPath("~/Uploads/") + "Reclamo" + idReclamo + "_" + fileName;
                    FileUpload1.SaveAs(pathImagen);

                    BIZReclamo.Update(idReclamo, pathImagen);

                    //BIZPlaza.Insert(idEstacionamiento, Context.User.Identity.GetUserId(), Convert.ToInt32(ddlTipoAlquiler.SelectedValue), true);
                }
                

                txtIdReclamo.Text = "";
                txtPatenteInfractor.Text = "";


                txtIdReclamo.Visible = true;
                lblIdReclamo.Visible = true;

                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                //divPrecio.Visible = false;
                lblMensaje.Text = string.Empty;
                cargarEstacionamientos();
            }
            catch (Exception ex)
            {
                string m = ex.Message;

                Response.Redirect("~/ErrorPage.aspx");
            }


        }

        protected void gvReclamo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            /*try
            {
                int idEstacionamiento = (int)gvReclamo.DataKeys[e.RowIndex].Value;
                BIZEstacionamiento.Delete(idEstacionamiento);
                cargarEstacionamientos();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "alert('No se pudo eliminar la zona');", true);
            }*/

        }

        protected void gvReclamo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Rechazar")
            {
                int idReclamo = int.Parse(e.CommandArgument.ToString().Split(',')[0]);
                int idReserva = int.Parse(e.CommandArgument.ToString().Split(',')[1]);
                BIZReclamo.UpdateStatus(idReclamo, 3);
                if (Context.User.IsInRole("Administrador"))
                    gvReclamo.DataSource = BIZReclamo.SelectAll();
                else
                    gvReclamo.DataSource = BIZReclamo.SelectByIdUser(Context.User.Identity.GetUserId());
                gvReclamo.DataBind();
                
            }
            else if (e.CommandName == "Pagar")
            {
                int idReclamo = int.Parse(e.CommandArgument.ToString().Split(',')[0]);
                int idReserva = int.Parse(e.CommandArgument.ToString().Split(',')[1]);
                BIZReserva.MisReservasSelectByIdReserva(idReserva);
            }
            else if (e.CommandName == "Descargar")
            {

                string filePath = e.CommandArgument.ToString();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
        }

        protected void gvReclamo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text.Equals("Rechazado") || e.Row.Cells[4].Text.Equals("Pagado"))
                {
                    e.Row.FindControl("lnkRechazarReclamo").Visible = false;
                    e.Row.FindControl("lnkPagarReclamo").Visible = false;
                }
            }
        }

    }
}