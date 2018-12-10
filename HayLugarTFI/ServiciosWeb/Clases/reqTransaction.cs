using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosWeb.Clases
{
    public class reqTransaction
    {
        int nroSeguimiento;

        public int NroSeguimiento
        {
            get { return nroSeguimiento; }
            set { nroSeguimiento = value; }
        }

        string idMessage;

        public string IdMessage
        {
            get { return idMessage; }
            set { idMessage = value; }
        }
    }
}

