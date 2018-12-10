using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;

namespace UI
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cargarLista()
        {
            try
            {
                CultureInfo us = new CultureInfo("es-ES");
                gvZonas.DataSource = BIZZona.SelectAll();
                gvZonas.DataBind();

                if (gvZonas.Rows.Count > 0)
                {
                    //Attribute to show the Plus Minus Button.
                    gvZonas.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvZonas.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gvZonas.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }

        protected void gvZonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZonas.PageIndex = e.NewPageIndex;
            cargarLista();
        }
    }
}