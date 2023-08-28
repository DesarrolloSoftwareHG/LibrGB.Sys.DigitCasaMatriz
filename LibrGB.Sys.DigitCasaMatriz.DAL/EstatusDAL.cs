using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------REFERENCIAS ----------
using System.Data.SqlClient;
using LibrGB.Sys.DigitCasaMatriz.EN;

namespace LibrGB.Sys.DigitCasaMatriz.DAL
{
    public class EstatusDAL
    {
        public List<EstatusEN> ObtenerEstatus()
        {
            // Crear una lista para almacenar los objetos de EstatusEN
            List<EstatusEN> listaEstatus = new List<EstatusEN>();

            // Crear un nuevo comando SQL utilizando el método ObtenerComando() de la clase ComunBD
            SqlCommand command = ComunBD.ObtenerComando();

            // Establecer el tipo de comando como Procedimiento Almacenado
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del Procedimiento Almacenado a ejecutar
            command.CommandText = "SPMostrarEstatus";

            // Ejecutar el comando y obtener un lector de datos (DataReader)
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Iterar a través de las filas del lector de datos
            while (reader.Read())
            {
                // Crear un objeto de EstatusEN para almacenar la información de la fila actual
                EstatusEN ObjEstatus = new EstatusEN();

                // Asignar los valores de las columnas de la fila actual a las propiedades del objeto
                ObjEstatus.Id = reader.GetInt32(0);
                ObjEstatus.Nombre = reader.GetString(1);
                ObjEstatus.Descripcion = reader.GetString(2);
                ObjEstatus.FechaCreacion = reader.GetDateTime(3);
                ObjEstatus.FechaModificacion = reader.GetDateTime(4);

                // Agregar el objeto de EstatusEN a la lista
                listaEstatus.Add(ObjEstatus);
            }

            // Devolver la lista de objetos de EstatusEN
            return listaEstatus;

        }

        public EstatusEN ObtenerEstatusPorId(int? pId)
        {
            // Crear un nuevo comando SQL utilizando el método ObtenerComando() de la clase ComunBD
            SqlCommand command = ComunBD.ObtenerComando();

            // Establecer el tipo de comando como Procedimiento Almacenado
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del Procedimiento Almacenado a ejecutar
            command.CommandText = "SPObtenerEstatusPorId";

            // Agregar un parámetro al comando para el Id del estatus a buscar
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecutar el comando y obtener un lector de datos (DataReader)
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crear un objeto de EstatusEN para almacenar la información
            EstatusEN estatus = new EstatusEN();

            // Verificar si el lector de datos contiene filas y leer la primera fila
            if (reader.Read())
            {
                // Asignar los valores de las columnas de la fila actual a las propiedades del objeto
                estatus.Id = reader.GetInt32(0);
                estatus.Nombre = reader.GetString(1);
                estatus.Descripcion = reader.GetString(2);
                estatus.FechaCreacion = reader.GetDateTime(3);
                estatus.FechaModificacion = reader.GetDateTime(4);
            }

            // Devolver el objeto de estatus encontrado (o un objeto vacío si no se encontró)
            return estatus;

        }
    }
}
