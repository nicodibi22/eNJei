using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;


namespace UI
{
    public partial class CalculoEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ddlDespacho.DataSource = BIZZona.SelectAll().Tables[0];
                ddlDespacho.DataValueField = "idZona";
                ddlDespacho.DataTextField = "direccion";
                ddlDespacho.DataBind();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}