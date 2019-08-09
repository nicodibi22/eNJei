using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZPlaza
    {

        /// <summary>
        /// Inserta registros dentro de la tabla Plaza.
        /// </summary>
        /// <param name="idEstacionamiento"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idTarifa"></param>
        /// <param name="disponible"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(int idEstacionamiento, string idUsuario, int idTarifa, bool disponible)
        {
            try
            {
                return DALPlaza.Insert(idEstacionamiento, idUsuario, idTarifa, disponible, false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla Plaza.
        /// </summary>
        /// <param name="idPlaza"></param>
        /// <param name="idEstacionamiento"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idTarifa"></param>
        /// <param name="disponible"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idPlaza, int idEstacionamiento, string idUsuario, int idTarifa, bool disponible, bool pago)
        {
            try
            {
                DALPlaza.Update(idPlaza, idEstacionamiento, idUsuario, idTarifa, disponible, pago);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void UpdateAvailable(int idPlaza, string idUsuario)
        {
            try
            {
                DALPlaza.UpdateAvailable(idPlaza, idUsuario);
            }
            catch (Exception ex)
            {
                string mje = ex.Message;

                throw;
            }
        }


        public static void UpdateNOAvailable(int idPlaza, string idUsuario)
        {
            try
            {
                DALPlaza.UpdateNOAvailable(idPlaza, idUsuario);
            }
            catch (Exception ex)
            {
                string mje = ex.Message;

                throw;
            }
        }


        /// <summary>
        /// Suprime un registro de la tabla Plaza por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idPlaza)
        {
            try
            {
                DALPlaza.Delete(idPlaza);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Plaza a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdEstacionamiento(int idEstacionamiento)
        {
            try
            {
                DALPlaza.DeleteByIdEstacionamiento(idEstacionamiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Plaza a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdTarifa(int idTarifa)
        {
            try
            {
                DALPlaza.DeleteByIdTarifa(idTarifa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla Plaza.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idPlaza)
        {
            try
            {
                return DALPlaza.Select(idPlaza);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Plaza.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectAll(int? idTipoEstadia, int? idZona, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            try
            {
                return DALPlaza.SelectAll(idTipoEstadia, idZona, fechaDesde, fechaHasta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectDisponibilidadByPlaza(int? idPlaza, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            try
            {
                return DALPlaza.SelectDisponibilidadByPlaza(idPlaza, fechaDesde, fechaHasta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Plaza a través de una foreign key.
        /// </summary>
        /// <param name="idEstacionamiento"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdEstacionamiento(int idEstacionamiento)
        {
            try
            {
                return DALPlaza.SelectByIdEstacionamiento(idEstacionamiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Plaza a través de una foreign key.
        /// </summary>
        /// <param name="idTarifa"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdTarifa(int idTarifa)
        {
            try
            {
                return DALPlaza.SelectByIdTarifa(idTarifa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectDisponibilidadDiario(DateTime fecha)
        {
            try
            {
                //PlazaSelectAllHoraAvailable
                return DALPlaza.SelectDisponibilidadDiario(fecha);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectDisponibilidadHora(DateTime fecha, string hora)
        {
            try
            {
                //PlazaSelectAllHoraAvailable
                return DALPlaza.SelectDisponibilidadHora(fecha, hora);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
