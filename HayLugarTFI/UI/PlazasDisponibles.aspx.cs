using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using System.Configuration;
using System.Data.SqlClient;

namespace UI
{
    public partial class PlazasDisponibles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {

                try
                {
                    if (!this.IsPostBack)
                    {
                        ddlZona.DataSource = BIZZona.SelectAll();
                        ddlZona.DataBind();
                        string query = @"SELECT E.[descripcion], E.[calle], E.[altura], E.[datosAdicionales], B.[descripcion], E.[latitud] ,E.[longitud], TE.[idTipoEstadia]  FROM [Estacionamiento] E, [Plaza] P, [Barrio] B, [TipoEstadia] TE, [Tarifa] T where E.[idEstacionamiento] = P.[idEstacionamiento] AND B.[idBarrio] = E.[idBarrio] AND P.[disponible] = 1 AND P.[pago] = 0 and P.idTarifa = T.idTarifa and T.idTipoEstadia = TE.idTipoEstadia";
                        DataTable dt = this.GetData(query);

                        int? idTipoEstadia = !string.IsNullOrEmpty(ddlTipoAlquiler.SelectedValue) ? int.Parse(ddlTipoAlquiler.SelectedValue) : (int?)null;
                        int? idZona = int.Parse(ddlZona.SelectedValue);
                        DateTime? fechaDesde = !string.IsNullOrEmpty(txtFechaDesde.Text) ? Convert.ToDateTime(txtFechaDesde.Text) : (DateTime?)null;
                        DateTime? fechaHasta = !string.IsNullOrEmpty(txtFechaHasta.Text) ? Convert.ToDateTime(txtFechaHasta.Text) : (DateTime?)null;

                        
                        dt = BIZPlaza.SelectAll(idTipoEstadia, idZona, fechaDesde, fechaHasta).Tables[0];
                        Session["PlazasFiltradas"] = dt;
                        rptMarkers.DataSource = dt;
                        rptMarkers.DataBind();

                        if (dt.Rows.Count == 0)
                        {
                            lblErrorMapa.Text = "No se encuentran plazas disponibles";
                            lblErrorMapa.Visible = true;
                        }
                        
                        

                    }
                }
                catch (Exception)
                {
                    rptMarkers.DataSource = null;
                    lblErrorMapa.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        private DataTable GetData(string query)
        {
            //string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string conString = BIZUtilites.getConnection();
            //string conString = @"workstation id=haylugardbnew.mssql.somee.com;packet size=4096;user id=sbiondini_SQLLogin_2;pwd=z9j9uo7kaq;data source=haylugardbnew.mssql.somee.com;persist security info=False;initial catalog=haylugardbnew";


            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarPlaza.aspx");
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int? idTipoEstadia = !string.IsNullOrEmpty(ddlTipoAlquiler.SelectedValue) ? int.Parse(ddlTipoAlquiler.SelectedValue) : (int?)null;
            int? idZona = int.Parse(ddlZona.SelectedValue);
            DateTime? fechaDesde;
            DateTime? fechaHasta;
            if (idTipoEstadia == 1)
            {
                fechaDesde = !string.IsNullOrEmpty(txtFechaDesde.Text) ? Convert.ToDateTime(txtFechaDesde.Text) : (DateTime?)null;
                fechaHasta = !string.IsNullOrEmpty(txtFechaHasta.Text) ? Convert.ToDateTime(txtFechaHasta.Text) : (DateTime?)null;
            }
            else
            {
                fechaDesde = !string.IsNullOrEmpty(txtFecha.Text) ? Convert.ToDateTime(txtFecha.Text) : (DateTime?)null;
                fechaHasta = !string.IsNullOrEmpty(txtFecha.Text) ? Convert.ToDateTime(txtFecha.Text) : (DateTime?)null;
            }

            DataTable dt = BIZPlaza.SelectAll(idTipoEstadia, idZona, fechaDesde, fechaHasta).Tables[0];
            Session["PlazasFiltradas"] = dt;
            rptMarkers.DataSource = dt;
            rptMarkers.DataBind();

            if (dt.Rows.Count == 0)
            {
                lblErrorMapa.Text = "No se encuentran plazas disponibles";
                lblErrorMapa.Visible = true;
            }
        }

        protected void ddlTipoAlquiler_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
    }
}