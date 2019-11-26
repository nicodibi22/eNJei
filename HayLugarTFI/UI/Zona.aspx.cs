using System;
using System.Collections.Generic;
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
                gvZona.DataSource = BIZZona.SelectAll();
                gvZona.DataBind();

                //Attribute to show the Plus Minus Button.
                gvZona.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                gvZona.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                gvZona.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            catch (Exception)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
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

            e.Cancel = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;

                if (txtIdZona.Text == string.Empty)
                {
                    BIZZona.Insert(txtDescripcion.Text, txtDireccion.Text, 100);

                }
                else
                {
                    BIZZona.Update(Convert.ToInt32(txtIdZona.Text), txtDescripcion.Text, txtDireccion.Text, 100);

                }
                txtIdZona.Text = "";
                txtDescripcion.Text = "";
                txtDireccion.Text = "";

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

        protected void gvZona_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idZona = (int)gvZona.DataKeys[e.RowIndex].Value;
                BIZZona.Delete(idZona);
                cargarZonas();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "alert('No se pudo eliminar la zona');", true);
            }
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
                    cargarZonas();
                    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "BootstrapDialog.alert('Registro eliminado correctamente.');", true);
                    //data.
                    Response.Redirect("~/Zona.aspx");
                }
            }
            catch (Exception ex)
            {

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "BootstrapDialog.alert('No se pudo eliminar el registro. Error: " + ex.Message + "');", true);
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
    }
}