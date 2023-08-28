using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------- REFERENCIAS -----------
using System.Data.SqlClient;
using LibrGB.Sys.DigitCasaMatriz.EN;

namespace LibrGB.Sys.DigitCasaMatriz.DAL
{
    public class EstadoCivilDAL
    {
        public List<EstadoCivilEN> ObtenerEstadoCivil()
        {
            // Crear una lista para almacenar los objetos de estado civil
            List<EstadoCivilEN> listaEstadoCivil = new List<EstadoCivilEN>();

            // Crear un comando SQL utilizando el método ObtenerComando() de la clase ComunBD
            SqlCommand command = ComunBD.ObtenerComando();

            // Establecer el tipo de comando como Procedimiento Almacenado
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del Procedimiento Almacenado a ejecutar
            command.CommandText = "SPMostrarEstadoCivil";

            // Ejecutar el comando y obtener un lector de datos (DataReader)
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Iterar a través de los resultados del lector de datos
            while (reader.Read())
            {
                // Crear un objeto de EstadoCivilEN para almacenar la información
                EstadoCivilEN ObjEstadoCivil = new EstadoCivilEN();

                // Asignar los valores de las columnas de la fila actual a las propiedades del objeto
                ObjEstadoCivil.Id = reader.GetInt32(0);
                ObjEstadoCivil.Nombre = reader.GetString(1);

                // Agregar el objeto de estado civil a la lista
                listaEstadoCivil.Add(ObjEstadoCivil);
            }

            // Devolver la lista completa de estados civiles
            return listaEstadoCivil;
        }

        public EstadoCivilEN ObtenerEstadoCivilPorId(int? pId)
        {
            // Crear un nuevo comando SQL utilizando el método ObtenerComando() de la clase ComunBD
            SqlCommand command = ComunBD.ObtenerComando();

            // Establecer el tipo de comando como Procedimiento Almacenado
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del Procedimiento Almacenado a ejecutar
            command.CommandText = "SPObtenerEstadoCivilPorId";

            // Agregar un parámetro al comando para el Id del estado civil a buscar
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecutar el comando y obtener un lector de datos (DataReader)
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crear un objeto de EstadoCivilEN para almacenar la información
            EstadoCivilEN estadoCivil = new EstadoCivilEN();

            // Verificar si el lector de datos contiene filas y leer la primera fila
            if (reader.Read())
            {
                // Asignar los valores de las columnas de la fila actual a las propiedades del objeto
                estadoCivil.Id = reader.GetInt32(0);
                estadoCivil.Nombre = reader.GetString(1);
            }

            // Devolver el objeto de estado civil encontrado (o un objeto vacío si no se encontró)
            return estadoCivil;

        }
    }
}
