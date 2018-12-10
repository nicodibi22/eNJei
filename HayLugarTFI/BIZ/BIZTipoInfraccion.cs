using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
   public static class BIZTipoInfraccion
    {


        /// <summary>
        /// Inserta registros dentro de la tabla TipoInfraccion.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="porcentaje"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(string descripcion, decimal porcentaje)
        {
            try
            {
                return DALTipoInfraccion.Insert(descripcion, porcentaje);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Actualiza registros de la tabla TipoInfraccion.
        /// </summary>
        /// <param name="idTipoInfraccion"></param>
        /// <param name="descripcion"></param>
        /// <param name="porcentaje"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idTipoInfraccion, string descripcion, decimal porcentaje)
        {
            try
            {
                DALTipoInfraccion.Update(idTipoInfraccion, descripcion, porcentaje);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Suprime un registro de la tabla TipoInfraccion por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idTipoInfraccion)
        {
            try
            {
                DALTipoInfraccion.Delete(idTipoInfraccion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla TipoInfraccion.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idTipoInfraccion)
        {
            try
            {
                return DALTipoInfraccion.Select(idTipoInfraccion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla TipoInfraccion.
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
                return DALTipoInfraccion.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
