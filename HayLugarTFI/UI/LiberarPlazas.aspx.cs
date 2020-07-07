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
using Microsoft.AspNet.Identity;

namespace UI
{
    public partial class LiberarPlazas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*TimeZoneInfo infotime = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            DateTime now = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            lblTime.Text = TimeZoneInfo.ConvertTimeToUtc(now, infotime).ToString("dd/MM/yyyy HH:mm:ss");*/
            
            lblTime.Text = Utils.GetDateTimeLocal().ToString("dd/MM/yyyy HH:mm:ss");

        }
        protected void TimerTime_Tick(object sender, EventArgs e)
        {
            
            lblTime.Text = Utils.GetDateTimeLocal().ToString("dd/MM/yyyy HH:mm:ss");
            //lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        protected void btnAjustarHora_Click(object sender, EventArgs e)
        {
            BIZReserva.ReservaUpdateFinalizado(Convert.ToDateTime(txtFecha.Text), txtHoraDesde.Text);
            BIZBitacora.Insert(Utils.GetDateTimeLocal(), Context.User.Identity.GetUserId(), "MODIFICACIÓN", "Liberación Plazas");
            ((SiteMaster)this.Master).ShowMessage("<strong>Se ajustó la fecha correctamente</strong>", SiteMaster.WarningType.Success);
        }
    }
}