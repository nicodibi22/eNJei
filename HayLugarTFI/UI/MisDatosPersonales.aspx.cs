﻿using System;
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

                gvVehiculo.DataSource = BIZVehiculo.SelectByIdUsr(User.Identity.GetUserId());
                gvVehiculo.DataBind();

                if (gvDatosPersonales.Rows.Count > 0)
                {

                    //Attribute to show the Plus Minus Button.
                    gvDatosPersonales.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvDatosPersonales.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvDatosPersonales.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
                if (Context.User.IsInRole("Propietario"))
                {
                    pnlTab3.Visible = false;
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
            pnlTab3.Visible = false;
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
                pnlTab3.Visible = true;
                pnlTab1.Visible = true;
                pnlVehiculo.Visible = false;
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
            pnlTab1.Visible = false;
            pnlTab3.Visible = false;
            pnlVehiculo.Visible = true;

            txtIdVehiculo.Text = ((Label)gvVehiculo.Rows[e.NewEditIndex].FindControl("lblNroReg")).Text;
            txtMarca.Text = gvVehiculo.Rows[e.NewEditIndex].Cells[0].Text.ToString();
            txtModelo.Text = gvVehiculo.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            txtPatente.Text = gvVehiculo.Rows[e.NewEditIndex].Cells[2].Text.ToString();
            
            e.Cancel = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pepe", "mostrar();", true);
        }

        protected void gvVehiculo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnCancelarVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MisDatosPersonales.aspx");
        }

        protected void btnConfirmarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                BIZVehiculo.Update(int.Parse(txtIdVehiculo.Text), User.Identity.GetUserId(), txtMarca.Text, txtModelo.Text, txtPatente.Text);
                txtNumeroDocumento.Text = "";
                txtEmail.Text = "";
                txtNroTelefono.Text = "";
                txtAliasEmp.Text = "";
                pnlTab2.Visible = false;
                pnlTab3.Visible = true;
                pnlTab1.Visible = true;
                pnlVehiculo.Visible = false;
                cargarDatos();
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }
    }
}