using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BIZ
{
    public static class BIZTipoEstadia
    {
        /// <summary>
        /// Inserta registros dentro de la tabla TipoEstadia.
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
                return DALTipoEstadia.Insert(descripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla TipoEstadia.
        /// </summary>
        /// <param name="idTipoEstadia"></param>
        /// <param name="descripcion"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idTipoEstadia, string descripcion)
        {
            try
            {
                DALTipoEstadia.Update(idTipoEstadia, descripcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Suprime un registro de la tabla TipoEstadia por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idTipoEstadia)
        {
            try
            {
                DALTipoEstadia.Delete(idTipoEstadia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla TipoEstadia.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idTipoEstadia)
        {
            try
            {
                return DALTipoEstadia.Select(idTipoEstadia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla TipoEstadia.
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
                return DALTipoEstadia.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
