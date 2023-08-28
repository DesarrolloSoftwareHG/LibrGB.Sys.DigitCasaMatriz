using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------REFERENCIAS--------
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using LibrGB.Sys.DigitCasaMatriz.EN;

namespace LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.UDM
{
    public class UnidadDeMedidaDAL
    {
        public int GuardarUDM(UnidadDeMedidaEN pUDMGuardar)
        {
            //----------- INICIO VALIDACION CODIGO YA EXISTENTE ----------
            var UnidadDeMedidas = ObtenerUDM();

            var UDM = UnidadDeMedidas.FirstOrDefault(c => c.UDM == pUDMGuardar.UDM);
            //Validar si la categoria es NULL 
            if (UDM != null)
            {
                return 0;
            }
            //----------- FINAL VALIDACION CODIGO YA EXISTENTE ----------

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para guardar la Unidad de Medida.
            command.CommandText = "SPGuardarUnidadDeMedida";

            // Agrega los parámetros necesarios para la creación de la Unidad de Medida.
            command.Parameters.AddWithValue("@UDM", pUDMGuardar.UDM);
            command.Parameters.AddWithValue("@IdEstatus", pUDMGuardar.Estatus.Id);
            command.Parameters.AddWithValue("@Descripcion", pUDMGuardar.Descripcion);
            command.Parameters.AddWithValue("@FechaCreacion", pUDMGuardar.FechaCreacion);

            // Ejecuta el comando y devuelve el resultado.
            return ComunBD.EjecutarComando(command);
        }

        public int ModificarUDM(UnidadDeMedidaEN pUDModificar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para modificar la Unidad de Medida.
            command.CommandText = "SPModificarUnidadDeMedida";

            // Agrega los parámetros necesarios para la modificación.
            command.Parameters.AddWithValue("@Id", pUDModificar.Id);
            command.Parameters.AddWithValue("@UDM", pUDModificar.UDM);
            command.Parameters.AddWithValue("@IdEstatus", pUDModificar.Estatus.Id);
            command.Parameters.AddWithValue("@Descripcion", pUDModificar.Descripcion);
            command.Parameters.AddWithValue("@FechaModificacion", pUDModificar.FechaModificacion);

            // Ejecuta el comando y devuelve el resultado.
            return ComunBD.EjecutarComando(command);

        }

        public int EliminarUDM(UnidadDeMedidaEN pUDMEliminar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para eliminar la Unidad de Medida.
            command.CommandText = "SPEliminarUnidadDeMedida";

            // Agrega el parámetro de ID a la consulta.
            command.Parameters.AddWithValue("@Id", pUDMEliminar.Id);

            // Ejecuta el comando y devuelve el resultado.
            return ComunBD.EjecutarComando(command);

        }

        public List<UnidadDeMedidaEN> ObtenerUDM()
        {
            // Crea una lista para almacenar las Unidades de Medida.
            List<UnidadDeMedidaEN> listaUDM = new List<UnidadDeMedidaEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para mostrar las Unidades de Medida.
            command.CommandText = "SPMostrarUnidadDeMedida";

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Lee los resultados del lector de datos.
            while (reader.Read())
            {
                // Crea una instancia de UnidadDeMedidaEN para almacenar los datos de cada Unidad de Medida.
                UnidadDeMedidaEN ObjUDM = new UnidadDeMedidaEN();

                // Asigna los valores de los campos obtenidos del lector de datos a las propiedades de la UnidadDeMedidaEN.
                ObjUDM.Id = reader.GetInt32(0);
                ObjUDM.UDM = reader.GetString(1);

                // Crea una instancia de EstatusEN y asigna los valores correspondientes a las propiedades.
                ObjUDM.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(6),
                    Nombre = reader.GetString(7)
                };

                ObjUDM.Descripcion = reader.GetString(3);
                ObjUDM.FechaCreacion = reader.GetDateTime(4);
                ObjUDM.FechaModificacion = reader.GetDateTime(5);

                // Agrega la Unidad de Medida a la lista.
                listaUDM.Add(ObjUDM);
            }

            // Devuelve la lista de Unidades de Medida.
            return listaUDM;

        }

        public UnidadDeMedidaEN ObtenerUDMPorId(int? pId)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener la UnidadDeMedida por su ID.
            command.CommandText = "SPObtenerUnidadDeMedidaPorId";

            // Agrega un parámetro al comando para especificar el ID de la UnidadDeMedida que se está buscando.
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crea una instancia de UnidadDeMedidaEN para almacenar los datos.
            UnidadDeMedidaEN UDM = new UnidadDeMedidaEN();

            // Verifica si hay resultados en el lector de datos.
            if (reader.Read())
            {
                // Asigna los valores de los campos obtenidos del lector de datos a las propiedades de la UnidadDeMedidaEN.
                UDM.Id = reader.GetInt32(0);
                UDM.UDM = reader.GetString(1);
                UDM.Descripcion = reader.GetString(3);
                UDM.FechaCreacion = reader.GetDateTime(4);
                UDM.FechaModificacion = reader.GetDateTime(5);

                // Crea una instancia de EstatusEN y asigna los valores correspondientes a las propiedades.
                UDM.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(6),
                    Nombre = reader.GetString(7)
                };
            }

            // Devuelve la UnidadDeMedidaEN obtenida.
            return UDM;

        }

        public List<UnidadDeMedidaEN> ObtenerUDMLike(string pNombre)
        {
            // Crea una nueva lista para almacenar las UnidadesDeMedida obtenidas.
            List<UnidadDeMedidaEN> listaUDM = new List<UnidadDeMedidaEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener las UnidadesDeMedida que coinciden con el nombre proporcionado.
            command.CommandText = "SPObtenerUnidadDeMedidaLike";

            // Agrega un parámetro al comando para especificar el nombre de la UnidadDeMedida que se está buscando.
            command.Parameters.AddWithValue("@UDM", pNombre);

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Itera a través de los resultados del lector de datos.
            while (reader.Read())
            {
                // Crea una nueva instancia de UnidadDeMedidaEN para almacenar los datos.
                UnidadDeMedidaEN ObjUDM = new UnidadDeMedidaEN();

                // Asigna los valores de los campos obtenidos del lector de datos a las propiedades de la UnidadDeMedidaEN.
                ObjUDM.Id = reader.GetInt32(0);
                ObjUDM.UDM = reader.GetString(1);
                ObjUDM.Descripcion = reader.GetString(3);
                ObjUDM.FechaCreacion = reader.GetDateTime(4);
                ObjUDM.FechaModificacion = reader.GetDateTime(5);

                // Crea una instancia de EstatusEN y asigna los valores correspondientes a las propiedades.
                ObjUDM.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(6),
                    Nombre = reader.GetString(7)
                };

                // Agrega la UnidadDeMedidaEN a la lista.
                listaUDM.Add(ObjUDM);
            }

            // Devuelve la lista de UnidadesDeMedida obtenidas.
            return listaUDM;

        }
    }
}
