using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Microsoft.AspNet.Identity;

namespace UI
{
    public partial class Rendimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrillaCC();
        }

        private void cargarGrillaCC()
        {
            try
            {
                gv_DatosCC.DataSource = BIZCuentaCorriente.Select(User.Identity.GetUserId());
                gv_DatosCC.DataBind();

                if (gv_DatosCC.Rows.Count > 0)
                {

                    //Attribute to show the Plus Minus Button.
                    gv_DatosCC.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gv_DatosCC.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";

                    //Adds THEAD and TBODY to GridView.
                    gv_DatosCC.HeaderRow.TableSection = TableRowSection.TableHeader;

                    pnlTabcc.Visible = true;
                }
                else
                {
                    pnlTabcc.Visible = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("ErrorDB.aspx");
            }
        }


        protected void btnVerMovCC_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'CtaCteHist.aspx', null, 'height=350,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }
    }
}