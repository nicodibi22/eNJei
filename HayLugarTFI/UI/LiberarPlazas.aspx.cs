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
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");


        }
        protected void TimerTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        protected void btnAjustarHora_Click(object sender, EventArgs e)
        {
            BIZReserva.ReservaUpdateFinalizado(Convert.ToDateTime(txtFecha.Text), txtHoraDesde.Text);
        }
    }
}