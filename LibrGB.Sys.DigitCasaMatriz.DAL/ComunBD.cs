using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----REFERENCIAS----------
using System.Data;
using System.Data.SqlClient;

namespace LibrGB.Sys.DigitCasaMatriz.DAL
{
    public class ComunBD
    {
        //---Se coloca el link de conexion en una constante
        const string StrConexion = @"";
        //----Establecemos la conexion con SQL

        private static SqlConnection ObtenerConexion()
        {
            // Crear una instancia de la clase SqlConnection utilizando la cadena de conexión StrConexion
            SqlConnection connection = new SqlConnection(StrConexion);

            // Abrir la conexión a la base de datos
            connection.Open();

            // Devolver la conexión abierta
            return connection;
        }

        public static SqlCommand ObtenerComando()
        {
            // Crear una instancia de la clase SqlCommand
            SqlCommand command = new SqlCommand();

            // Establecer la conexión del comando utilizando el método ObtenerConexion()
            command.Connection = ObtenerConexion();

            // Devolver el comando creado
            return command;
        }

        public static int EjecutarComando(SqlCommand pComando)
        {
            // Ejecutar el comando y almacenar el resultado en la variable "resultado"
            int resultado = pComando.ExecuteNonQuery();

            // Cerrar la conexión asociada al comando
            pComando.Connection.Close();

            // Devolver el resultado obtenido
            return resultado;
        }

        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando)
        {
            // Ejecutar el comando y obtener un SqlDataReader
            SqlDataReader reader = pComando.ExecuteReader(CommandBehavior.CloseConnection);

            // Devolver el SqlDataReader
            return reader;
        }
    }
}
