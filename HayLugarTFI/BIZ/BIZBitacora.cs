using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public class BIZBitacora
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
        public static int Insert(DateTime fechaHora, string idUsuario, string accion, string detalle)
        {
            try
            {
                return DALBitacora.Insert(fechaHora, idUsuario, accion, detalle);
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
        public static DataSet Select(DateTime fechaDesde, DateTime fechaHasta, string idUsuario, int idPerfil) 
        {
            try
            {
                return DALBitacora.Select(fechaDesde, fechaHasta, idUsuario, idPerfil);
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
                return DALBitacora.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
