using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public class BIZBarrio
    {

        /// <summary>
        /// Inserta registros dentro de la tabla Barrio.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="idZona"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(string descripcion, int idZona)
        {
            try
            {
                return DALBarrio.Insert(descripcion, idZona);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Actualiza registros de la tabla Barrio.
        /// </summary>
        /// <param name="idBarrio"></param>
        /// <param name="descripcion"></param>
        /// <param name="idZona"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idBarrio, string descripcion, int idZona)
        {
            try
            {
                DALBarrio.Update(idBarrio, descripcion, idZona);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Suprime un registro de la tabla Barrio por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idBarrio)
        {
            try
            {
                DALBarrio.Delete(idBarrio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Barrio a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdZona(int idZona)
        {
            try
            {
                DALBarrio.DeleteByIdZona(idZona);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla Barrio.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idBarrio)
        {
            try
            {
                return DALBarrio.Select(idBarrio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Barrio.
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
                return DALBarrio.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Barrio a través de una foreign key.
        /// </summary>
        /// <param name="idZona"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdZona(int idZona)
        {
            try
            {
                return DALBarrio.SelectByIdZona(idZona);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
