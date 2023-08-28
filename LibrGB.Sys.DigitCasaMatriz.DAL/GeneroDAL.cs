using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------- REFERENCIAS ---------
using System.Data.SqlClient;
using LibrGB.Sys.DigitCasaMatriz.EN;

namespace LibrGB.Sys.DigitCasaMatriz.DAL
{
    public class GeneroDAL
    {
        public List<GeneroEN> ObtenerGenero()
        {
            // Crear una lista para almacenar los objetos de GeneroEN
            List<GeneroEN> listaGenero = new List<GeneroEN>();

            // Crear un nuevo comando SQL utilizando el método ObtenerComando() de la clase ComunBD
            SqlCommand command = ComunBD.ObtenerComando();

            // Establecer el tipo de comando como Procedimiento Almacenado
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del Procedimiento Almacenado a ejecutar
            command.CommandText = "SPMostrarGenero";

            // Ejecutar el comando y obtener un lector de datos (DataReader)
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Iterar a través de las filas del lector de datos
            while (reader.Read())
            {
                // Crear un objeto de GeneroEN para almacenar la información de la fila actual
                GeneroEN ObjGenero = new GeneroEN();

                // Asignar los valores de las columnas de la fila actual a las propiedades del objeto
                ObjGenero.Id = reader.GetInt32(0);
                ObjGenero.Nombre = reader.GetString(1);

                // Agregar el objeto de GeneroEN a la lista
                listaGenero.Add(ObjGenero);
            }

            // Devolver la lista de objetos de GeneroEN
            return listaGenero;

        }

        public GeneroEN ObtenerGeneroPorId(int? pId)
        {
            // Crear un nuevo comando SQL utilizando el método ObtenerComando() de la clase ComunBD
            SqlCommand command = ComunBD.ObtenerComando();

            // Establecer el tipo de comando como Procedimiento Almacenado
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del Procedimiento Almacenado a ejecutar
            command.CommandText = "SPObtenerGeneroPorId";

            // Agregar el parámetro @Id al comando con el valor proporcionado (pId)
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecutar el comando y obtener un lector de datos (DataReader)
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crear un objeto de GeneroEN para almacenar la información del género encontrado
            GeneroEN Genero = new GeneroEN();

            // Verificar si hay datos en el lector de datos y leer la primera fila si está disponible
            if (reader.Read())
            {
                // Asignar los valores de las columnas de la fila actual a las propiedades del objeto
                Genero.Id = reader.GetInt32(0);
                Genero.Nombre = reader.GetString(1);
            }

            // Devolver el objeto de GeneroEN con la información del género encontrado
            return Genero;

        }
    }
}