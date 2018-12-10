using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using BIZ;
using System.Globalization;

namespace UI
{
    public partial class Reserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gvReserva.DataSource = BIZReserva.MisReservasSelectByIdReserva(Convert.ToInt32(Request["pPurchaseOrderID"]));
                gvReserva.DataBind();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Reserva.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                this.Page.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 15f, 15f, 2f, 5f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);

                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();

                pdfDoc.Close();
                Response.Write(pdfDoc);
                //Response.End();
                Response.Flush();
                //response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                string err = ex.Message;

                Response.Redirect("ErrorPage.aspx");
            }


        }
    }
}