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
using Microsoft.AspNet.Identity;
using BIZ;
using System.Drawing;

namespace UI
{
    public partial class CargaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadXML(object sender, EventArgs e)
        {
            lblMje.ForeColor = Color.Green;
            lblMje.Text = string.Empty;
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            if (string.IsNullOrEmpty(fileName))
            {
                lblMje.ForeColor = Color.Red;
                lblMje.Text = "Debe elegir un archivo.";
                return;
            }
            string filePath, xml;
            try
            {
                filePath = Server.MapPath("~/Uploads/") + fileName;
                FileUpload1.SaveAs(filePath);
                xml = File.ReadAllText(filePath);
            }
            catch (Exception)
            {

                lblMje.ForeColor = Color.Red;
                lblMje.Text = "Debe elegir un archivo existente.";
                return;
            }
            

            string extension = fileName.Split('.').Length > 0 ? fileName.Split('.')[fileName.Split('.').Length - 1] : "";

            if (!extension.ToUpper().Equals("CSV"))
            {
                lblMje.ForeColor = Color.Red;
                lblMje.Text = "El archivo debe tener extension CSV.";
                return;
            }

            using (var reader = new StreamReader(@filePath))
            {


                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                int registro = 0;
                while (!reader.EndOfStream)
                {
                    registro++;
                    try
                    {
                        var line = reader.ReadLine();
                        string[] values = line.Split(';');

                        /*
                         Estacionamiento.value('(descripcion/text())[1]','VARCHAR(100)') AS descripcion, --TAG 
	Estacionamiento.value('(calle/text())[1]','VARCHAR(100)') AS calle, --TAG 
	Estacionamiento.value('(altura/text())[1]','INT') AS altura, --TAG 
	Estacionamiento.value('(datosAdicionales/text())[1]','VARCHAR(100)') AS datosAdicionales, --TAG 
	Estacionamiento.value('(idBarrio/text())[1]','INT') AS idBarrio, --TAG 
	Estacionamiento.value('(latitud/text())[1]','NUMERIC(18,6)') AS latitud, --TAG 
	Estacionamiento.value('(longitud/text())[1]','NUMERIC(18,6)') AS longitud --TAG 

                        prueba;calle falsa;1234;Springfield;1;-34.454;-58.321;1
                         */

                        if (values.Length == 8)
                        {
                            int idEstacionamiento = BIZEstacionamiento.Insert(values[0], values[1], Convert.ToInt32(values[2]), values[3], Convert.ToInt32(values[4]),
                        Convert.ToDecimal(values[5]), Convert.ToDecimal(values[6]));

                            BIZPlaza.Insert(idEstacionamiento, Context.User.Identity.GetUserId(), int.Parse(values[7]), true);
                            
                        }
                        else
                        {
                            lblMje.Text += "Se produjo error al procesar el registro Nº " + registro + ": La cantidad de campos no es correcta.\n";
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMje.Text = "Se produjo un error al procesar el archivo. Intentalo nuevamente.";
                        return;
                    }

                }
                BIZBitacora.Insert(Utils.GetDateTimeLocal(), Context.User.Identity.GetUserId(), "ALTA", "Carga Masiva Estacionamiento");
                lblMje.Text += "Se importó el archivo correctamente. Se agregaron " +  registro + " estacionamientos";
            }



            
        }

        protected void btnCargaMasivaBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estacionamiento");
        }
    }
}