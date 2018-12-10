using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZZona
    {

        /// <summary>
        /// Inserta registros dentro de la tabla Zona.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(string descripcion, string direccion, decimal precioKm)
        {
            try
            {
                return DALZona.Insert(descripcion, direccion, precioKm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla Zona.
        /// </summary>
        /// <param name="idZona"></param>
        /// <param name="descripcion"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idZona, string descripcion, string direccion, decimal precioKm)
        {
            try
            {
                DALZona.Update(idZona, descripcion, direccion, precioKm);
            }
            catch (Exception ex)
            {
                string pepe = ex.Message;

                throw;
            }
        }

        /// <summary>
        /// Suprime un registro de la tabla Zona por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idZona)
        {
            try
            {
                DALZona.Delete(idZona);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla Zona.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idZona)
        {
            try
            {
                return DALZona.Select(idZona);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Zona.
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
                return DALZona.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
