using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZOperacionesTC
    {


        /// <summary>
        /// Inserta registros dentro de la tabla OperacionesTC.
        /// </summary>
        /// <param name="nroTarjeta"></param>
        /// <param name="fechaVenc"></param>
        /// <param name="codSeg"></param>
        /// <param name="nroReserva"></param>
        /// <param name="fechaOperacion"></param>
        /// <param name="detalle"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	27/11/2017 23:27:18
        /// </history>
        public static int Insert(string nroTarjeta, DateTime fechaVenc, int codSeg, int nroReserva, DateTime fechaOperacion, string detalle, string UserId)
        {
            try
            {
                return DALOperacionesTC.Insert(nroTarjeta, fechaVenc, codSeg, nroReserva, fechaOperacion, detalle, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla OperacionesTC.
        /// </summary>
        /// <param name="idOperacion"></param>
        /// <param name="nroTarjeta"></param>
        /// <param name="fechaVenc"></param>
        /// <param name="codSeg"></param>
        /// <param name="nroReserva"></param>
        /// <param name="fechaOperacion"></param>
        /// <param name="detalle"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	27/11/2017 23:27:18
        /// </history>
        public static void Update(int idOperacion, string nroTarjeta, DateTime fechaVenc, int codSeg, int nroReserva, DateTime fechaOperacion, string detalle, string UserId)
        {
            try
            {
                DALOperacionesTC.Update(idOperacion, nroTarjeta, fechaVenc, codSeg, nroReserva, fechaOperacion, detalle, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla OperacionesTC.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	27/11/2017 23:27:18
        /// </history>
        public static DataSet Select(int idOperacion)
        {
            try
            {
                return DALOperacionesTC.Select(idOperacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla OperacionesTC.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	27/11/2017 23:27:18
        /// </history>
        public static DataSet SelectAll()
        {
            try
            {
                return DALOperacionesTC.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}

