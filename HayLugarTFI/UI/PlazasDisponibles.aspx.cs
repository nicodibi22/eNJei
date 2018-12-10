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
                        string query = @"SELECT E.[descripcion], E.[calle], E.[altura], E.[datosAdicionales], B.[descripcion], E.[latitud] ,E.[longitud]  FROM [Estacionamiento] E, [Plaza] P, [Barrio] B where E.[idEstacionamiento] = P.[idEstacionamiento] AND B.[idBarrio] = E.[idBarrio] AND P.[disponible] = 1 AND P.[pago] = 0";
                        DataTable dt = this.GetData(query);
                        rptMarkers.DataSource = dt;
                        rptMarkers.DataBind();
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
    }
}