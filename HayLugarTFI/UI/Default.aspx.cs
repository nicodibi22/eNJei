using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime MyDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

                TimeZoneInfo JOTZ = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");//Jordan
                MyDateTime = TimeZoneInfo.ConvertTime(MyDateTime, JOTZ);
                MyDateTime = TimeZoneInfo.ConvertTimeToUtc(MyDateTime.AddHours(4), JOTZ);
                
                int diario = Convert.ToInt32(BIZPlaza.SelectDisponibilidadDiario(MyDateTime).Tables[0].Rows[0][0]);
                int hora = Convert.ToInt32(BIZPlaza.SelectDisponibilidadHora(MyDateTime, MyDateTime.ToString("HH:mm")).Tables[0].Rows[0][0]);

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
    }
}