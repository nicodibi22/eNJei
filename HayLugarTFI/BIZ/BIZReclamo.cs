using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BIZ
{
    public static class BIZReclamo
    {
        
        public static int Insert(int idReserva, string patente, string idUsuario, int idTipoReclamo, string detalle)
        {
            try
            {
                return DALReclamo.Insert(idReserva, patente, idUsuario, idTipoReclamo, detalle);
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public static int Update(int idReclamo, string pathImagen)
        {
            try
            {
                return DALReclamo.Update(idReclamo, pathImagen);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int UpdateStatus(int idReclamo, int idEstadoReclamo)
        {
            try
            {
                return DALReclamo.UpdateStatus(idReclamo, idEstadoReclamo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataSet SelectByIdUser(string usuarioId)
        {
            try
            {
                return DALReclamo.SelectByIdUser(usuarioId);
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
                return DALReclamo.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
