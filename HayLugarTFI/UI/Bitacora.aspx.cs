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
using System.Data.SqlClient;

namespace UI
{
    public partial class Bitacora : System.Web.UI.Page
    {
        decimal Total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                //BIZReserva.ReservaUpdateFinalizado(DateTime.Today, DateTime.Today.Hour.ToString().PadLeft(2, '0'));
                //cargarReservas();
                cargarBitacora();
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                
                ddlMail.DataSource = BIZDatosPersonales.SelectAll();
                ddlMail.DataBind();
                ddlMail.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlMail.SelectedIndex = 0;
            }

        }

        private void cargarBitacora()
        {
            try
            {
                if (Context.User.IsInRole("Administrador"))
                {
                    
                    gvReservasPendientes.DataSource = BIZBitacora.Select(DateTime.Now, DateTime.Now, null, 0);
                    gvReservasPendientes.DataBind();


                }


                CultureInfo us = new CultureInfo("es-ES");
                if (gvReservasPendientes.Rows.Count > 0)
                {

                    //Attribute to show the Plus Minus Button.
                    gvReservasPendientes.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvReservasPendientes.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvReservasPendientes.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;

                Response.Redirect("ErrorPage.aspx");
            }
        }

        private bool ValidacionFechas(out DateTime fechaDesde, out DateTime fechaHasta)
        {
            fechaDesde = DateTime.MinValue;
            fechaHasta = DateTime.MinValue;
            if (string.IsNullOrEmpty(txtFechaDesde.Text) || string.IsNullOrEmpty(txtFechaHasta.Text))
            {
                lblErrorFiltro.Text = "Debe completar los filtros de fecha.";
                return false;
            }

            if (!string.IsNullOrEmpty(txtFechaDesde.Text))
            {
                DateTime result;
                DateTime.TryParse(txtFechaDesde.Text, out fechaDesde);
                if (fechaDesde.Equals(DateTime.MinValue))
                {
                    lblErrorFiltro.Text = "El formato de la Fecha Desde no es correcto.";
                    return false;
                }

                DateTime.TryParse(txtFechaHasta.Text, out fechaHasta);
                if (fechaHasta.Equals(DateTime.MinValue))
                {
                    lblErrorFiltro.Text = "El formato de la Fecha Hasta no es correcto.";
                    return false;
                }

                if (fechaDesde > fechaHasta)
                {
                    lblErrorFiltro.Text = "La fecha hasta no debe ser menor a la fecha desde.";
                    return false;
                }
            }
            

            return true;
        }

        protected void gvReservasPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReservasPendientes.PageIndex = e.NewPageIndex;
            cargarBitacora();

        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            lblErrorFiltro.Text = string.Empty;
            DateTime fechaDesde;
            DateTime fechaHasta;
            if (ValidacionFechas(out fechaDesde, out fechaHasta))
            {
                DateTime? fechaDesdeFiltro = fechaDesde != DateTime.MinValue ? fechaDesde : (DateTime?)null;
                DateTime? fechaHastaFiltro = fechaHasta != DateTime.MinValue ? fechaHasta : (DateTime?)null;

                string usuario = string.IsNullOrEmpty(ddlMail.SelectedValue) ? null : ddlMail.SelectedValue;
                int perfil = int.Parse(ddlPerfil.SelectedValue);
                gvReservasPendientes.DataSource = BIZBitacora.Select(fechaDesdeFiltro.Value, fechaHastaFiltro.Value, usuario, perfil);
                gvReservasPendientes.DataBind();
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

        protected void gvReserva_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTarifa");
                Total += Decimal.Parse(lblTotal.Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = Total.ToString();
            }
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFechaDesde.Text = string.Empty;
            txtFechaHasta.Text = string.Empty;
            ddlMail.SelectedIndex = 0;
        }

    }
}