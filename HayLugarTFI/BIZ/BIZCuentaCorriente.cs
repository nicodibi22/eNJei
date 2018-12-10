using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZCuentaCorriente
    {
        /// <summary>
        /// Inserta registros dentro de la tabla CuentaCorriente.
        /// </summary>
        /// <param name="idUsr"></param>
        /// <param name="saldo"></param>
        /// <param name="fechaUltimaOperacion"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static int Insert(string idUsr, decimal saldo, DateTime fechaUltimaOperacion)
        {
            try
            {
                return DALCuentaCorriente.Insert(idUsr, saldo, fechaUltimaOperacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateSaldo(int nroCuenta, decimal saldo)
        {
            try
            {
                DALCuentaCorriente.UpdateSaldo(nroCuenta, saldo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza registros de la tabla CuentaCorriente.
        /// </summary>
        /// <param name="nroCuenta"></param>
        /// <param name="idUsr"></param>
        /// <param name="saldo"></param>
        /// <param name="fechaUltimaOperacion"></param>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static void Update(int nroCuenta, string idUsr, decimal saldo, DateTime fechaUltimaOperacion)
        {
            try
            {
                DALCuentaCorriente.Update(nroCuenta, idUsr, saldo, fechaUltimaOperacion);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Selecciona un registro desde la tabla CuentaCorriente.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static DataSet Select(string idUsr)
        {
            try
            {
                return DALCuentaCorriente.Select(idUsr);
            }
            catch (Exception)
            {

                throw;
            }        }

        /// <summary>
        /// Selecciona todos los registros de la tabla CuentaCorriente.
        /// </summary>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[JEISOLO]	25/11/2017 12:24:36
        /// </history>
        public static DataSet SelectAll()
        {
            try
            {
                return DALCuentaCorriente.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectUsersSinCtaCte()
        {
            try
            {
                return DALCuentaCorriente.SelectUsersSinCtaCte();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
