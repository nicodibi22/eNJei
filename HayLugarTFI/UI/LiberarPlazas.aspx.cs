using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BIZ;

namespace UI
{
    public partial class LiberarPlazas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*TimeZoneInfo infotime = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            DateTime now = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            lblTime.Text = TimeZoneInfo.ConvertTimeToUtc(now, infotime).ToString("dd/MM/yyyy HH:mm:ss");*/


            DateTime MyDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            TimeZoneInfo JOTZ = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");//Jordan
            MyDateTime = TimeZoneInfo.ConvertTime(MyDateTime, JOTZ);
            lblTime.Text = TimeZoneInfo.ConvertTimeToUtc(MyDateTime.AddHours(4), JOTZ).ToString("dd/MM/yyyy HH:mm:ss");

        }
        protected void TimerTime_Tick(object sender, EventArgs e)
        {
            DateTime MyDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            TimeZoneInfo JOTZ = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");//Jordan
            MyDateTime = TimeZoneInfo.ConvertTime(MyDateTime, JOTZ);
            lblTime.Text = TimeZoneInfo.ConvertTimeToUtc(MyDateTime.AddHours(4), JOTZ).ToString("dd/MM/yyyy HH:mm:ss");
            //lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        protected void btnAjustarHora_Click(object sender, EventArgs e)
        {
            BIZReserva.ReservaUpdateFinalizado(Convert.ToDateTime(txtFecha.Text), txtHoraDesde.Text);
            ((SiteMaster)this.Master).ShowMessage("<strong>Se ajustó la fecha correctamente</strong>", SiteMaster.WarningType.Success);
        }
    }
}