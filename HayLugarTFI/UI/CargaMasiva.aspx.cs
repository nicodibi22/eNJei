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

namespace UI
{
    public partial class CargaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadXML(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);
            string xml = File.ReadAllText(filePath);
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertXML"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@xml", xml);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                lblMje.Text = "El archivo se ha procesado exitosamente!";
            }
            catch (Exception)
            {
                lblMje.Text = "Se produjo un error al procesar el archivo. Intentalo nuevamente.";
                lblMje.ForeColor = System.Drawing.Color.Red;
                throw;
            }
        }

        protected void btnCargaMasivaBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estacionamiento");
        }
    }
}