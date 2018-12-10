using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZOperacionesCtaCte
    {
        /// <summary>
        /// Inserta registros dentro de la tabla OperacionesCtaCte.
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <param name="monto"></param>
        /// <param name="fechaOperacion"></param>
        /// <param name="detalle"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static int Insert(int idCuenta, decimal monto, DateTime fechaOperacion, string detalle, string tipoOperacion)
        {
            try
            {
                return DALOperacionesCtaCte.Insert(idCuenta, monto, fechaOperacion, detalle, tipoOperacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla OperacionesCtaCte.
        /// </summary>
        /// <param name="idOperacion"></param>
        /// <param name="idCuenta"></param>
        /// <param name="monto"></param>
        /// <param name="fechaOperacion"></param>
        /// <param name="detalle"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static void Update(int idOperacion, int idCuenta, decimal monto, DateTime fechaOperacion, string detalle, string tipoOperacion)
        {
            try
            {
                DALOperacionesCtaCte.Update(idOperacion, idCuenta, monto, fechaOperacion, detalle, tipoOperacion);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Selecciona un registro desde la tabla OperacionesCtaCte.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static DataSet Select(string idUsr)
        {
            try
            {
                return DALOperacionesCtaCte.Select(idUsr);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla OperacionesCtaCte.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static DataSet SelectAll()
        {
            try
            {
                return DALOperacionesCtaCte.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

