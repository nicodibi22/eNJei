using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;


namespace BIZ
{
    public static class BIZPago
    {
        /// <summary>
        /// Inserta registros dentro de la tabla Pago.
        /// </summary>
        /// <param name="fechaPago"></param>
        /// <param name="importe"></param>
        /// <param name="idMulta"></param>
        /// <param name="idReserva"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(DateTime fechaPago, decimal importe, int idMulta, int idReserva)
        {
            try
            {
                return DALPago.Insert(fechaPago, importe, idMulta, idReserva);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Actualiza registros de la tabla Pago.
        /// </summary>
        /// <param name="idPago"></param>
        /// <param name="fechaPago"></param>
        /// <param name="importe"></param>
        /// <param name="idMulta"></param>
        /// <param name="idReserva"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idPago, DateTime fechaPago, decimal importe, int idMulta, int idReserva)
        {
            try
            {
                DALPago.Update(idPago, fechaPago, importe, idMulta, idReserva);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Suprime un registro de la tabla Pago por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idPago)
        {
            try
            {
                DALPago.Delete(idPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Pago a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdMulta(int idMulta)
        {
            try
            {
                DALPago.DeleteByIdMulta(idMulta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Pago a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdReserva(int idReserva)
        {
            try
            {
                DALPago.DeleteByIdReserva(idReserva);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Selecciona un registro desde la tabla Pago.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idPago)
        {
            try
            {
                return DALPago.Select(idPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Pago.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectAll()
        {
            try
            {
                return DALPago.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Pago a través de una foreign key.
        /// </summary>
        /// <param name="idMulta"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdMulta(int idMulta)
        {
            try
            {
                return DALPago.SelectByIdMulta(idMulta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Pago a través de una foreign key.
        /// </summary>
        /// <param name="idReserva"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdReserva(int idReserva)
        {
            try
            {
                return DALPago.SelectByIdReserva(idReserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
