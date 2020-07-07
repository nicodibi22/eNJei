using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.SqlClient;

namespace UI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BIZBitacora.Insert(Utils.GetDateTimeLocal(), Context.User.Identity.GetUserId(), "INGRESO", "Login");


                int diario = Convert.ToInt32(BIZPlaza.SelectDisponibilidadDiario(Utils.GetDateTimeLocal()).Tables[0].Rows[0][0]);
                int hora = Convert.ToInt32(BIZPlaza.SelectDisponibilidadHora(Utils.GetDateTimeLocal(), Utils.GetDateTimeLocal().ToString("HH:mm")).Tables[0].Rows[0][0]);

                lblPlazasDia.Text = string.Format(lblPlazasDia.Text, diario);
                lblPlazasHora.Text = string.Format(lblPlazasHora.Text, hora);

                if (diario > 10)
                {
                    divDiario.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Success.ToString().ToLower());
                }
                else if (diario > 0)
                {
                    divDiario.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Warning.ToString().ToLower());
                }
                else
                {
                    divDiario.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Danger.ToString().ToLower());
                }

                if (hora > 10)
                {
                    divHora.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Success.ToString().ToLower());
                }
                else if (hora > 0)
                {
                    divHora.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Warning.ToString().ToLower());
                }
                else
                {
                    divHora.CssClass = string.Format("alert alert-{0} alert-dismissable", UI.SiteMaster.WarningType.Danger.ToString().ToLower());
                }
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
    }
}