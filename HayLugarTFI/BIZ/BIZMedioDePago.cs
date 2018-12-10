using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZMedioDePago
    {
        /// <summary>
        /// Inserta registros dentro de la tabla MedioDePago.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(string descripcion)
        {
            try
            {
                return DALMedioDePago.Insert(descripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla MedioDePago.
        /// </summary>
        /// <param name="idMedioPago"></param>
        /// <param name="descripcion"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idMedioPago, string descripcion)
        {
            try
            {
                DALMedioDePago.Update(idMedioPago, descripcion);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Suprime un registro de la tabla MedioDePago por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idMedioPago)
        {
            try
            {
                DALMedioDePago.Delete(idMedioPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla MedioDePago.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idMedioPago)
        {
            try
            {
               return DALMedioDePago.Select(idMedioPago);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla MedioDePago.
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
                return DALMedioDePago.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
