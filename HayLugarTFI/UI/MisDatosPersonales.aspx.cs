using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using BIZ;



namespace UI
{
    public partial class MisDatosPersonales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                cargarDatos();
        }

        private void cargarDatos()
        {
            try
            {
                gvDatosPersonales.DataSource = BIZ.BIZDatosPersonales.SelectByIdUsr(User.Identity.GetUserId());
                gvDatosPersonales.DataBind();

                //gvVehiculo.DataSource = BIZVehiculo.SelectByIdUsr(User.Identity.GetUserId());
                //gvVehiculo.DataBind();

                if (gvDatosPersonales.Rows.Count > 0)
                {

                    //Attribute to show the Plus Minus Button.
                    gvDatosPersonales.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvDatosPersonales.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvDatosPersonales.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Response.Redirect("ErrorDB.aspx");
            }
        }

        protected void gvDatosPersonales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDatosPersonales.PageIndex = e.NewPageIndex;
            cargarDatos();
        }

        protected void gvDatosPersonales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlTab1.Visible = false;
            pnlTab2.Visible = true;

            txtAliasEmp.Text = ((Label)gvDatosPersonales.Rows[e.NewEditIndex].FindControl("lblNroReg")).Text; //gvDatosPersonales.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            ddlTipoDocumento.Text = gvDatosPersonales.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtNumeroDocumento.Text = gvDatosPersonales.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            txtEmail.Text = gvDatosPersonales.Rows[e.NewEditIndex].Cells[3].Text.ToString();
            txtNroTelefono.Text = gvDatosPersonales.Rows[e.NewEditIndex].Cells[5].Text.ToString();
            ddltipotelefono.SelectedValue = ((Label)gvDatosPersonales.Rows[e.NewEditIndex].FindControl("lblTipoTelefono")).Text;
            //txtAliasEmp.Text = ((Label)gvDatosPersonales.Rows[e.NewEditIndex].FindControl("lblAliasEmp")).Text;

            e.Cancel = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisDatosPersonales.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BIZDatosPersonales.Update(Convert.ToInt32(txtAliasEmp.Text), User.Identity.GetUserId(), ddlTipoDocumento.SelectedValue, txtNumeroDocumento.Text, txtEmail.Text, txtNroTelefono.Text, ddltipotelefono.SelectedValue, txtAliasEmp.Text);
                txtNumeroDocumento.Text = "";
                txtEmail.Text = "";
                txtNroTelefono.Text = "";
                txtAliasEmp.Text = "";
                pnlTab2.Visible = false;
                pnlTab1.Visible = true;
                cargarDatos();
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }

        protected void cvNumDNI_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTipoDocumento.SelectedValue == "CUIT")
            {
                args.IsValid = BIZUtilites.ValidaCuit(txtNumeroDocumento.Text);
            }

        }

        protected void gvVehiculo_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvVehiculo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}