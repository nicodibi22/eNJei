using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosWeb.Clases
{
    public class resFechaPago
    {
        string idMensaje;

        public string IdMensaje
        {
            get { return idMensaje; }
            set { idMensaje = value; }
        }

        int codigoTransaccion;

        public int CodigoTransaccion
        {
            get { return codigoTransaccion; }
            set { codigoTransaccion = value; }
        }

        string codigoDetalle;

        public string CodigoDetalle
        {
            get { return codigoDetalle; }
            set { codigoDetalle = value; }
        }

        DateTime fechaPago;

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }

        }
    }
}