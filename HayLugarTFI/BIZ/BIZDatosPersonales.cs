using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZDatosPersonales
    {

        /// <summary>
        /// Inserta registros dentro de la tabla DatosPersonales.
        /// </summary>
        /// <param name="idUsr"></param>
        /// <param name="tipoDoc"></param>
        /// <param name="nroDoc"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="tipoTelefono"></param>
        /// <param name="aliasEmp"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static int Insert(string idUsr, string tipoDoc, string nroDoc, string email, string telefono, string tipoTelefono, string aliasEmp)
        {
            try
            {
                return DALDatosPersonales.Insert(idUsr, tipoDoc, nroDoc, email, telefono, tipoTelefono, aliasEmp);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Actualiza registros de la tabla DatosPersonales.
        /// </summary>
        /// <param name="nroReg"></param>
        /// <param name="idUsr"></param>
        /// <param name="tipoDoc"></param>
        /// <param name="nroDoc"></param>
        /// <param name="email"></param>
        /// <param name="telefono"></param>
        /// <param name="tipoTelefono"></param>
        /// <param name="aliasEmp"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Update(int nroReg, string idUsr, string tipoDoc, string nroDoc, string email, string telefono, string tipoTelefono, string aliasEmp)
        {
            try
            {
                DALDatosPersonales.Update(nroReg, idUsr, tipoDoc, nroDoc, email, telefono, tipoTelefono, aliasEmp);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Suprime un registro de la tabla DatosPersonales por una clave primaria(primary key).
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void Delete(int nroReg)
        {
            try
            {
                DALDatosPersonales.Delete(nroReg);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla DatosPersonales a través de una foreign key.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static void DeleteByIdUsr(string idUsr)
        {
            try
            {
                DALDatosPersonales.DeleteByIdUsr(idUsr);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona un registro desde la tabla DatosPersonales.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet Select(int nroReg)
        {
            return DALDatosPersonales.Select(nroReg);
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla DatosPersonales.
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
                return DALDatosPersonales.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla DatosPersonales a través de una foreign key.
        /// </summary>
        /// <param name="idUsr"></param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	23/09/2017 22:58:17
        /// </history>
        public static DataSet SelectByIdUsr(string idUsr)
        {
            try
            {
                return DALDatosPersonales.SelectByIdUsr(idUsr);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
