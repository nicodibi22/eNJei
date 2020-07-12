using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;


namespace UI
{
    public partial class CalculoEnvio : System.Web.UI.Page
    {

        private DataTable DataTableZona
        {
            set { ViewState["_DataTableZona"] = value; }
            get { return ViewState["_DataTableZona"] != null ? (DataTable)ViewState["_DataTableZona"] : null; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTableZona = BIZZona.SelectAll().Tables[0];
                    ddlDespacho.DataSource = DataTableZona;
                    ddlDespacho.DataValueField = "idZona";
                    ddlDespacho.DataTextField = "direccion";
                    ddlDespacho.DataBind();
                    ddlDespacho.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddlDespacho.SelectedIndex = 0;
                }
                catch (Exception)
                {

                    throw;
                }
            }            
        }

        protected void ddlDespacho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDespacho.SelectedValue))
            {
                hdPrecio.Value = DataTableZona.Select("idZona = " + ddlDespacho.SelectedValue)[0][3].ToString();
            }
            
        }
    }
}