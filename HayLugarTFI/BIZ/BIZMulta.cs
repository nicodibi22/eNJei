using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZMulta
    {
        /// <summary>
        /// Inserta registros dentro de la tabla Multa.
        /// </summary>
        /// <param name="idTipoInfraccion"></param>
        /// <param name="idTarifa"></param>
        /// <param name="idUsuario"></param>
        /// <param name="rutaFotoMulta"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(int idTipoInfraccion, int idTarifa, string idUsuario, string rutaFotoMulta)
        {
            try
            {
                return DALMulta.Insert(idTipoInfraccion, idTarifa, idUsuario, rutaFotoMulta);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Actualiza registros de la tabla Multa.
        /// </summary>
        /// <param name="idMulta"></param>
        /// <param name="idTipoInfraccion"></param>
        /// <param name="idTarifa"></param>
        /// <param name="idUsuario"></param>
        /// <param name="rutaFotoMulta"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int idMulta, int idTipoInfraccion, int idTarifa, string idUsuario, string rutaFotoMulta)
        {
            try
            {
                DALMulta.Update(idMulta, idTipoInfraccion, idTarifa, idUsuario, rutaFotoMulta);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Suprime un registro de la tabla Multa por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int idMulta)
        {
            try
            {
                DALMulta.Delete(idMulta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Multa a través de una foreign key.
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
                DALMulta.DeleteByIdTarifa(idTarifa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla Multa.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int idMulta)
        {
            try
            {
                return DALMulta.Select(idMulta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Multa.
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
               return DALMulta.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Multa a través de una foreign key.
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
                return DALMulta.SelectByIdTarifa(idTarifa);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
