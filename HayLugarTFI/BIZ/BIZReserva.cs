using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZReserva
    {
        /// <summary>
        /// Inserta registros dentro de la tabla Reserva.
        /// </summary>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="horaDesde"></param>
        /// <param name="horaHasta"></param>
        /// <param name="idPlaza"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(DateTime fechaDesde, DateTime fechaHasta, string horaDesde, string horaHasta, int idPlaza, string idUsuario)
        {
            try
            {
                return DALReserva.Insert(fechaDesde, fechaHasta, horaDesde, horaHasta, idPlaza, idUsuario);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Actualiza registros de la tabla Reserva.
        /// </summary>
        /// <param name="idReserva"></param>
        /// <param name="fechaDesde"></param>
        /// <param name="fechaHasta"></param>
        /// <param name="horaDesde"></param>
        /// <param name="horaHasta"></param>
        /// <param name="idPlaza"></param>
        /// <param name="idUsuario"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idReserva, DateTime fechaDesde, DateTime fechaHasta, string horaDesde, string horaHasta, int idPlaza, string idUsuario)
        {
            try
            {
                DALReserva.Update(idReserva, fechaHasta, fechaHasta, horaHasta, horaHasta, idPlaza, idUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void PlazaUpdateStatePayment(int idPlaza, bool pago)
        {
            try
            {
                DALReserva.PlazaUpdateStatePayment(idPlaza, pago);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Suprime un registro de la tabla Reserva por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idReserva)
        {
            try
            {
                DALReserva.Delete(idReserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Reserva a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdPlaza(int idPlaza)
        {
            try
            {
                DALReserva.DeleteByIdPlaza(idPlaza);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla Reserva.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idReserva)
        {
            try
            {
                return DALReserva.Select(idReserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva.
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
                return DALReserva.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva a través de una foreign key.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet MisReservasSelectByIdUser(string id)
        {
            try
            {
               return DALReserva.MisReservasSelectByIdUser(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet MisReservasSelectByIdReserva(int idReserva)
        {
            try
            {
                return DALReserva.MisReservasSelectByIdReserva(idReserva);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet MisReservasSelectAll()
        {
            try
            {
                return DALReserva.MisReservasSelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Reserva a través de una foreign key.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdPlaza(int idPlaza)
        {
            try
            {
                return DALReserva.SelectByIdPlaza(idPlaza);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet MisReservasSelectAllByEstadoPago(bool pago)
        {
            try
            {
                return DALReserva.MisReservasSelectAllByEstadoPago(pago);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static DataSet MisReservasSelectByPagoStateAndUserId(bool pago, String userId)
        {
            try
            {
                return DALReserva.MisReservasSelectByPagoStateAndUserId(pago, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
