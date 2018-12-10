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
    public partial class CtaCteHist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGrilla();

        }

        private void llenarGrilla()
        {
            try
            {
                gvHistCtaCte.DataSource = BIZOperacionesCtaCte.Select(User.Identity.GetUserId());
                gvHistCtaCte.DataBind();

                if (gvHistCtaCte.Rows.Count == 0)
                {
                    lblNODATAFOUND.Visible = true;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPage.aspx");
            }
        }

        protected void gvHistCtaCte_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHistCtaCte.PageIndex = e.NewPageIndex;
            llenarGrilla();

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}