using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZEstacionamiento
    {
        /// <summary>
        /// Inserta registros dentro de la tabla Estacionamiento.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="calle"></param>
        /// <param name="altura"></param>
        /// <param name="datosAdicionales"></param>
        /// <param name="idBarrio"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(string descripcion, string calle, int altura, string datosAdicionales, int idBarrio, decimal latitud, decimal longitud)
        {
            try
            {
                return DALEstacionamiento.Insert(descripcion, calle, altura, datosAdicionales, idBarrio, latitud, longitud);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Actualiza registros de la tabla Estacionamiento.
        /// </summary>
        /// <param name="idEstacionamiento"></param>
        /// <param name="descripcion"></param>
        /// <param name="calle"></param>
        /// <param name="altura"></param>
        /// <param name="datosAdicionales"></param>
        /// <param name="idBarrio"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idEstacionamiento, string descripcion, string calle, int altura, string datosAdicionales, int idBarrio, decimal latitud, decimal longitud)
        {
            try
            {
                DALEstacionamiento.Update(idEstacionamiento, descripcion, calle, altura, datosAdicionales, idBarrio, latitud, longitud);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Suprime un registro de la tabla Estacionamiento por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idEstacionamiento)
        {
            try
            {
                DALEstacionamiento.Delete(idEstacionamiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Estacionamiento a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdBarrio(int idBarrio)
        {
            try
            {
                DALEstacionamiento.DeleteByIdBarrio(idBarrio);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Selecciona un registro desde la tabla Estacionamiento.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idEstacionamiento)
        {
            try
            {
                return DALEstacionamiento.Select(idEstacionamiento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Estacionamiento.
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
                return DALEstacionamiento.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Estacionamiento a través de una foreign key.
        /// </summary>
        /// <param name="idBarrio"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdBarrio(int idBarrio)
        {
            try
            {
                return DALEstacionamiento.SelectByIdBarrio(idBarrio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectByIdUser(string idUser)
        {
            try
            {
                return DALEstacionamiento.SelectByIdUser(idUser);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
