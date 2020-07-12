using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BIZ
{
    public static class BIZTipoReclamo
    {
        /// <summary>
        /// Inserta registros dentro de la tabla TipoReclamo.
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
                return DALTipoReclamo.Insert(descripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla TipoReclamo.
        /// </summary>
        /// <param name="idTipoReclamo"></param>
        /// <param name="descripcion"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idTipoReclamo, string descripcion)
        {
            try
            {
                DALTipoReclamo.Update(idTipoReclamo, descripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Suprime un registro de la tabla TipoReclamo por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idTipoReclamo)
        {
            try
            {
                DALTipoReclamo.Delete(idTipoReclamo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla TipoReclamo.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idTipoReclamo)
        {
            try
            {
                return DALTipoReclamo.Select(idTipoReclamo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla TipoReclamo.
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
                return DALTipoReclamo.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
