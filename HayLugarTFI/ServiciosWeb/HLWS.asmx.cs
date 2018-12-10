using ServiciosWeb.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosWeb
{
    /// <summary>
    /// Descripción breve de HLWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class HLWS : System.Web.Services.WebService
    {

        [WebMethod(Description = @"fechaOperacion es un string con formato dd/mm/yyy. " 
            + " Para diaDeCobro1 y diaDeCobro2 --> 1=LUNES, 2=MARTES, 3=MIERCOLES, 4=JUEVES, 5=VIERNES, 6=SABADO, 7= DOMINGO")]
        public resFechaPago ShippingCharge(string idMensaje, decimal monto, string fechaOperacion, int diaDeCobro1, int diaDeCobro2)
        {
            resFechaPago resFP;
            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_FechaPago", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
                cmd.Parameters.Add("@fechaOperacion", SqlDbType.DateTime).Value = DateTime.Parse(fechaOperacion);
                cmd.Parameters.Add("@diaCobro1", SqlDbType.Int).Value = diaDeCobro1;
                cmd.Parameters.Add("@diaCobro2", SqlDbType.Int).Value = diaDeCobro2;
                cmd.Parameters.Add("@fechaDePago", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                DateTime fechaResult = DateTime.Parse(cmd.Parameters["@fechaDePago"].Value.ToString());
                cnn.Close();
                resFP = new resFechaPago();
                resFP.IdMensaje = idMensaje;
                resFP.CodigoTransaccion = 0;
                resFP.FechaPago = fechaResult;
                return resFP;

            }
            catch (Exception e)
            {
                //ante un error no contemplado, retorna codError=9 con la descripción.
                resFP = new resFechaPago();
                resFP.CodigoTransaccion = 999;
                resFP.CodigoDetalle = e.Message;
                resFP.IdMensaje = resFP.IdMensaje;
                return resFP;
            }
        }

        [WebMethod]
        public resTransaction TrackingShipment(int nroSeguimiento, string idMensaje)
        {
            //Genero el request
            reqTransaction req = new reqTransaction();
            req.NroSeguimiento = nroSeguimiento;
            req.IdMessage = idMensaje;
            resTransaction res;

            try
            {
                res = new resTransaction();

                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_TrackingShipment", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nroSeguimiento", SqlDbType.Int).Value = req.NroSeguimiento;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@fechaEntrega", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@observaciones", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@codTransaccion", SqlDbType.Int).Direction = ParameterDirection.Output;

                int bandera = 0;

                cmd.ExecuteNonQuery();

                bandera = int.Parse(cmd.Parameters["@codTransaccion"].Value.ToString());
                cnn.Close();


                res.IdMensaje = req.IdMessage;
                res.CodigoTransaccion = bandera;

                if (bandera == 0)
                {
                    res.Estado = cmd.Parameters["@estado"].Value.ToString();
                    res.FechaEntrega = DateTime.Parse(cmd.Parameters["@fechaEntrega"].Value.ToString());
                    res.Observaciones = cmd.Parameters["@observaciones"].Value.ToString();
                }
                else
                {
                    res.Observaciones = "Nro envío: " + nroSeguimiento + " inexistente.";

                }

                return res;


            }
            catch (Exception e)
            {

                //ante un error no contemplado, retorna codError=999 con la descripción.
                res = new resTransaction();
                res.CodigoTransaccion = 999;
                res.Observaciones = e.Message;
                res.IdMensaje = req.IdMessage;
                return res;

            }

        }


    }
}
