using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZTarifa
    {
        /// <summary>
        /// Inserta registros dentro de la tabla Tarifa.
        /// </summary>
        /// <param name="idTipoEstadia"></param>
        /// <param name="idMedioPago"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(int idTipoEstadia, int idMedioPago)
        {
            try
            {
                return DALTarifa.Insert(idTipoEstadia, idMedioPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla Tarifa.
        /// </summary>
        /// <param name="idTarifa"></param>
        /// <param name="idTipoEstadia"></param>
        /// <param name="idMedioPago"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idTarifa, int idTipoEstadia, int idMedioPago)
        {
            try
            {
                DALTarifa.Update(idTarifa, idTipoEstadia, idMedioPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Suprime un registro de la tabla Tarifa por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idTarifa)
        {
            try
            {
                DALTarifa.Delete(idTarifa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Tarifa a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdTipoEstadia(int idTipoEstadia)
        {
            try
            {
                DALTarifa.DeleteByIdTipoEstadia(idTipoEstadia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Tarifa a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdMedioPago(int idMedioPago)
        {
            try
            {
                DALTarifa.DeleteByIdMedioPago(idMedioPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla Tarifa.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idTarifa)
        {
            try
            {
               return DALTarifa.Select(idTarifa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Tarifa.
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
               return DALTarifa.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Tarifa a través de una foreign key.
        /// </summary>
        /// <param name="idTipoEstadia"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdTipoEstadia(int idTipoEstadia)
        {
            try
            {
                return DALTarifa.SelectByIdTipoEstadia(idTipoEstadia);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Tarifa a través de una foreign key.
        /// </summary>
        /// <param name="idMedioPago"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdMedioPago(int idMedioPago)
        {
            try
            {
                return DALTarifa.SelectByIdMedioPago(idMedioPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
