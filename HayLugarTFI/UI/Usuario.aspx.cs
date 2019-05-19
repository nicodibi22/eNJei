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

            txtUsuarioId.Visible = false;
            lblUsuarioId.Visible = false;

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

            txtUsuarioId.Text = gvUsuario.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            txtApellido.Text = gvUsuario.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtNombre.Text = gvUsuario.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            ddlTipoDocumento.Text = gvUsuario.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            txtNroDocumento.Text = gvUsuario.Rows[e.NewEditIndex].Cells[4].Text.ToString();

            e.Cancel = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;

                if (txtUsuarioId.Text == string.Empty)
                {
                    BIZDatosPersonales.Insert(string.Empty, ddlTipoDocumento.SelectedValue, txtNroDocumento.Text, string.Empty, string.Empty, string.Empty, string.Empty, txtNombre.Text, txtApellido.Text, txtDireccion.Text, string.Empty);

                }
                else
                {
                    //BIZZona.Update(Convert.ToInt32(txtIdZona.Text), txtDescripcion.Text, txtDireccion.Text, 100);

                }
                txtUsuarioId.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtNroDocumento.Text = "";
                txtDireccion.Text = "";

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
            Response.Redirect("~/Zona.aspx");

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
    }
}