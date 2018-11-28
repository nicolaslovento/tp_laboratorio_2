using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Contructor static. 
        /// Se conecta a la base de datos y se crea a variable de tipo SqlCommand.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.conexion);

            comando = new SqlCommand();
        }

        /// <summary>
        /// Agrega un paquete a la BD. 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
            comando.CommandText = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES ('{0}','{1}','{2}')",p.DireccionEntrega,p.TrackingID,"Lo Vento");
            bool retorno = false;
            try
            {
                PaqueteDAO.conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {

            }

            finally { conexion.Close(); }
            

            return retorno;
            
        }

        


    }
}
