using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZVehiculo
    {
        public static int Insert(string userId, string marca, string modelo, string patente)
        {
            try
            {
                return DALVehiculo.Insert(userId, marca, modelo, patente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(decimal idVehiculo, string userId, string marca, string modelo, string patente)
        {
            try
            {
                DALVehiculo.Update(idVehiculo, userId, marca, modelo, patente);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void Delete(decimal idVehiculo)
        {
            try
            {
                DALVehiculo.Delete(idVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet Select(decimal idVehiculo)
        {
            try
            {
                return DALVehiculo.Select(idVehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectAll()
        {
            try
            {
                return DALVehiculo.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectByIdUsr(string idUsr)
        {
            try
            {
                return DALVehiculo.SelectByIdUsr(idUsr);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
