using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Microsoft.AspNet.Identity;

namespace UI
{
    public partial class GestionCtaCte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                cargarDatosCC();
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        private void cargarDatosCC()
        {
            try
            {
                ddlUsuarios.DataSource = BIZCuentaCorriente.SelectUsersSinCtaCte();
                ddlUsuarios.DataTextField = "UserName";
                ddlUsuarios.DataValueField = "id";
                ddlUsuarios.DataBind();


                if (Context.User.IsInRole("Administrador"))
                {
                    gvCC.DataSource = BIZCuentaCorriente.SelectAll();
                }
                else
                {
                    gvCC.DataSource = BIZCuentaCorriente.Select(User.Identity.GetUserId());
                }

                gvCC.DataBind();

                if (gvCC.Rows.Count > 0)
                {
                    //Attribute to show the Plus Minus Button.
                    gvCC.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    //gvCC.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                    //gvCC.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                    //gvCC.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                    //gvCC.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvCC.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }
        }

        protected void gvCC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCC.PageIndex = e.NewPageIndex;
            cargarDatosCC();

        }

        protected void gvCC_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            lblUsuarios.Visible = false;
            ddlUsuarios.Visible = false;

            txtNroCuenta.Text = gvCC.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            //txtPrecioActual.Text = ((Label)gvProductos.Rows[e.NewEditIndex].FindControl("lblPrecio")).Text.Substring(1);
            txtSaldoHoy.Text = ((Label)gvCC.Rows[e.NewEditIndex].FindControl("lblSaldoHoy")).Text.Substring(1);
            txtTitular.Text = gvCC.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            e.Cancel = true;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionCtaCte.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal saldoTotal =  Convert.ToDecimal(txtSaldoHoy.Text) - Convert.ToDecimal(txtSaldoNuevo.Text);
                if (ddlUsuarios.Visible)
                {
                    BIZCuentaCorriente.Insert(ddlUsuarios.SelectedValue, Convert.ToInt32(txtSaldoHoy.Text), DateTime.Now);
                    BIZBitacora.Insert(DateTime.Now, Context.User.Identity.GetUserId(), "ALTA", "Cuenta Corriente");
                }
                else
                {
                    BIZCuentaCorriente.UpdateSaldo(Convert.ToInt32(txtNroCuenta.Text), saldoTotal);
                    BIZBitacora.Insert(DateTime.Now, Context.User.Identity.GetUserId(), "MODIFICACIÓN", "Cuenta Corriente");
                }
                txtNroCuenta.Text = "";
                txtSaldoHoy.Text = "";
                txtSaldoNuevo.Text = "";
                txtTitular.Text = "";
                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                cargarDatosCC();
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            titleProdAccion.InnerText = "Agregar Cuenta Corriente";

            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            lblSaldoNuevo.Visible = false;
            txtSaldoNuevo.Visible = false;

            txtNroCuenta.Visible = false;
            lblCUENTA.Visible = false;
            txtSaldoHoy.Enabled = true;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);


        }
    }
}