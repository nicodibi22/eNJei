using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
namespace UI
{
    public partial class Zona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == true)
                {
                    if (Context.User.IsInRole("Administrador"))
                    {
                        divHora.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Warning.ToString().ToLower());
                        
                        cargarZonas();
                        if (Request.QueryString["delete"] != null)
                        {
                            if (Convert.ToBoolean(Request.QueryString["delete"]) == true)
                            {
                                lblPlazasHora.Text = "Registro eliminado.";
                            }
                            else
                            {
                                lblPlazasHora.Text = "No se pudo eliminar la zona. Verifique que no tenga estacionamientos activos.";
                            }
                            divHora.Visible = true;
                        }
                            
                        else
                            divHora.Visible = false;
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
            


        }

        private void cargarZonas()
        {
            try
            {
                CultureInfo us = new CultureInfo("es-ES");
                gvZona.DataSource = BIZZona.SelectAll();
                gvZona.DataBind();
                divHora.Visible = false;
                //Attribute to show the Plus Minus Button.
                if (gvZona.HeaderRow != null && gvZona.HeaderRow.Cells.Count > 0)
                {
                    gvZona.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvZona.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvZona.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                

            }
            catch (Exception)
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            divHora.Visible = false;
            titleProdAccion.InnerText = "Agregar Zona";

            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdZona.Visible = false;
            lblIdZona.Visible = false;

            txtDescripcion.Enabled = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
        }

        protected void gvZona_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZona.PageIndex = e.NewPageIndex;
            cargarZonas();

        }

        protected void gvZona_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtIdZona.Text = gvZona.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            txtDescripcion.Text = gvZona.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtDireccion.Text = gvZona.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            txtPrecio.Text = gvZona.Rows[e.NewEditIndex].Cells[3].Text.ToString().Replace(",", ".");

            e.Cancel = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
                    lblMensaje.Text = "Ingrese un precio válido.";
                    lblMensaje.Visible = true;
                    return;
                } 

                if (txtIdZona.Text == string.Empty)
                {
                    BIZZona.Insert(txtDescripcion.Text, txtDireccion.Text, precio);

                }
                else
                {
                    BIZZona.Update(Convert.ToInt32(txtIdZona.Text), txtDescripcion.Text, txtDireccion.Text, precio);

                }
                txtIdZona.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtPrecio.Text = string.Empty;

                txtIdZona.Visible = true;
                lblIdZona.Visible = true;

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
            Response.Redirect("~/Zona.aspx");

        }



        protected void gvZona_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    LinkButton lnkView = (LinkButton)e.CommandSource;

                    string dealId = hiddenRow.Value;
                    int idZona = int.Parse(dealId);
                    BIZZona.Delete(idZona);
                    //Response.Redirect("~/Zona.aspx?delete=true", true);
                    //cargarZonas();

                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "BootstrapDialog.alert('Registro eliminado correctamente.');", true);
                    //data.


                    Response.Redirect("~/Zona.aspx?delete=true", true);
                }
            }
            catch (SqlException)
            {
                Response.Redirect("~/Zona.aspx?delete=false");
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "BootstrapDialog.alert('No se pudo eliminar el registro. Error: " + ex.Message + "');", true);
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvZona_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkDelete");
                lnkView.OnClientClick = string.Concat("if(!popup(this.id", ",", e.Row.Cells[0].Text, ",\"", e.Row.Cells[0].Text, "\"))return false; ");
            }
        }

        protected void gvZona_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            cargarZonas();
        }

        protected void gvZona_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            cargarZonas();
        }
    }
}