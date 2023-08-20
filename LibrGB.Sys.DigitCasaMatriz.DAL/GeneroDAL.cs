using LibrGB.Sys.DigitCasaMatriz.EN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.DAL
{
    public class GeneroDAL
    {
        public List<GeneroEN> ObtenerGenero()
        {
            List<GeneroEN> listaGenero = new List<GeneroEN>();
            // Crear una nueva lista de objetos de tipo GeneroEN.

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPMostrarGenero";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            while (reader.Read())
            {
                GeneroEN ObjGenero = new GeneroEN();
                // Crear una nueva instancia de la clase CategoriaEN para almacenar los datos de la categoría.

                //----- Nombres de los Campos en el Data Grid ------

                ObjGenero.Id = reader.GetInt32(0);
                // Asignar el valor entero del primer campo (índice 0) al Id de ObjCategoria.

                ObjGenero.Nombre = reader.GetString(1);
                // Asignar el valor de cadena del segundo campo (índice 1) al Nombre de ObjCategoria.

            }
            return listaGenero;
            // Devolver la lista de categorías.

        }

        public GeneroEN ObtenerGeneroPorId(int? pId)
        {
            // Crear un nuevo objeto SqlCommand utilizando el método ObtenerComando() que se encuentra en algún lugar del código.
            SqlCommand command = ComunBD.ObtenerComando();

            // Especificar el tipo de comando como StoredProcedure para indicar que se ejecutará un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del procedimiento almacenado a ejecutar.
            command.CommandText = "SPObtenerGeneroPorId";

            // Agregar un parámetro @Id al comando para pasar el valor del identificador pId.
            command.Parameters.AddWithValue("@Id", pId);

            // Crear un objeto SqlDataReader para leer los resultados del procedimiento almacenado.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crear una nueva instancia de UnidadDeMedidaEN para almacenar los datos del resultado del procedimiento almacenado.
            GeneroEN Genero = new GeneroEN();

            if (reader.Read())
            {
                // Si el SqlDataReader contiene al menos una fila, asigna los valores de las columnas a las propiedades del objeto UDM.
                Genero.Id = reader.GetInt32(0);
                Genero.Nombre = reader.GetString(1);

            }
            // Devuelve el objeto UDM que contiene los valores leídos del SqlDataReader.
            return Genero;
        }
    }
}