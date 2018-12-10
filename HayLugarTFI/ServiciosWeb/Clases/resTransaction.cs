using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosWeb.Clases
{
    public class resTransaction
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

        DateTime fechaEntrega;

        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }

        }


        string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
    }
}