using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------REFERENCIAS--------
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;

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


            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPGuardarUnidadDeMedida";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@UDM", pUDMGuardar.UDM);
            // Agrega un parámetro llamado "@UnidadDeMedida" al objeto SqlCommand "command" y le asigna el valor de la propiedad "UnidadDeMedida" del objeto "pUDMGuardar". Este parámetro será utilizado en un comando SQL para insertar o actualizar datos en la base de datos.

            command.Parameters.AddWithValue("@IdEstatus", pUDMGuardar.Estatus.Id);
            // Agrega un parámetro llamado "@FechaCreacion" al objeto SqlCommand "command" y le asigna el valor de la propiedad "FechaCreacion" del objeto "pUDMGuardar". Este parámetro también será utilizado en el comando SQL para insertar o actualizar datos.

            command.Parameters.AddWithValue("@Descripcion", pUDMGuardar.Descripcion);
            // Agrega un parámetro llamado "@Descripcion" al objeto SqlCommand "command" y le asigna el valor de la propiedad "Descripcion" del objeto "pUDMGuardar". Este parámetro también será utilizado en el comando SQL para insertar o actualizar datos.

            command.Parameters.AddWithValue("@FechaCreacion", pUDMGuardar.FechaCreacion);

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int ModificarUDM(UnidadDeMedidaEN pUDModificar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPModificarUnidadDeMedida";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Id", pUDModificar.Id);
            // Agrega un parámetro llamado "@Id" al objeto SqlCommand "command" y le asigna el valor de la propiedad "IdUDM" del objeto "pUDMModificar". Este parámetro será utilizado en un comando SQL para insertar o actualizar datos en la base de datos.

            command.Parameters.AddWithValue("@UDM", pUDModificar.UDM);
            // Agrega un parámetro llamado "UnidadDeMedida" al objeto SqlCommand "command" y le asigna el valor de la propiedad "UnidadDeMedida" del objeto "pUDMModificar". Este parámetro será utilizado en un comando SQL para insertar o actualizar datos en la base de datos.

            command.Parameters.AddWithValue("@IdEstatus", pUDModificar.Estatus.Id);
            // Agrega un parámetro llamado "@FechaModificacion" al objeto SqlCommand "command" y le asigna el valor de la propiedad "FechaModificacion" del objeto "pUDMModificar". Este parámetro será utilizado en un comando SQL para insertar o actualizar datos en la base de datos.

            command.Parameters.AddWithValue("@Descripcion", pUDModificar.Descripcion);
            // Agrega un parámetro llamado "@Descripcion" al objeto SqlCommand "command" y le asigna el valor de la propiedad "Descripcion" del objeto "pUDMModificar". Este parámetro será utilizado en un comando SQL para insertar o actualizar datos en la base de datos.

            command.Parameters.AddWithValue("@FechaModificacion", pUDModificar.FechaModificacion);

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int EliminarUDM(UnidadDeMedidaEN pUDMEliminar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPEliminarUnidadDeMedida";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Id", pUDMEliminar.Id);
            // Agrega un parámetro llamado "@Id" al objeto SqlCommand "command" y le asigna el valor de la propiedad "IdUDM" del objeto "pUDMEliminar". Este parámetro será utilizado en un comando SQL para insertar o actualizar datos en la base de datos.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public List<UnidadDeMedidaEN> ObtenerUDM()
        {
            List<UnidadDeMedidaEN> listaUDM = new List<UnidadDeMedidaEN>();

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPMostrarUnidadDeMedida";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            while (reader.Read())
            {
                // Crea una nueva instancia del objeto UnidadDeMedidaEN para almacenar los datos de una fila leída del SqlDataReader.
                UnidadDeMedidaEN ObjUDM = new UnidadDeMedidaEN();

                // Asigna los valores de las columnas leídas del SqlDataReader a las propiedades del objeto UnidadDeMedidaEN.
                ObjUDM.Id = reader.GetInt32(0);
                ObjUDM.UDM = reader.GetString(1);
                ObjUDM.Estatus.Id = reader.GetByte(2);
                ObjUDM.Descripcion = reader.GetString(3);
                ObjUDM.FechaCreacion = reader.GetDateTime(4);
                ObjUDM.FechaModificacion = reader.GetDateTime(5);

                // Agrega el objeto ObjUDM a la lista de unidades de medida llamada listaUDM.
                listaUDM.Add(ObjUDM);
            }

            // Devuelve la lista de objetos UnidadDeMedidaEN que contiene los datos leídos del SqlDataReader.
            return listaUDM;

        }

        public UnidadDeMedidaEN ObtenerUDMPorId(int? pId)
        {
            // Crear un nuevo objeto SqlCommand utilizando el método ObtenerComando() que se encuentra en algún lugar del código.
            SqlCommand command = ComunBD.ObtenerComando();

            // Especificar el tipo de comando como StoredProcedure para indicar que se ejecutará un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Especificar el nombre del procedimiento almacenado a ejecutar.
            command.CommandText = "SPObtenerUnidadDeMedidaPorId";

            // Agregar un parámetro @Id al comando para pasar el valor del identificador pId.
            command.Parameters.AddWithValue("@Id", pId);

            // Crear un objeto SqlDataReader para leer los resultados del procedimiento almacenado.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crear una nueva instancia de UnidadDeMedidaEN para almacenar los datos del resultado del procedimiento almacenado.
            UnidadDeMedidaEN UDM = new UnidadDeMedidaEN();

            if (reader.Read())
            {
                // Asigna los valores de las columnas leídas del SqlDataReader a las propiedades del objeto UnidadDeMedidaEN.
                UDM.Id = reader.GetInt32(0);
                UDM.UDM = reader.GetString(1);
                UDM.Estatus.Id = reader.GetByte(2);
                UDM.Descripcion = reader.GetString(3);
                UDM.FechaCreacion = reader.GetDateTime(4);
                UDM.FechaModificacion = reader.GetDateTime(5);
            }

            // Devuelve el objeto UDM que contiene los valores leídos del SqlDataReader.
            return UDM;
        }

        public List<UnidadDeMedidaEN> ObtenerUDMLike(string pNombre)
        {
            List<UnidadDeMedidaEN> listaUDM = new List<UnidadDeMedidaEN>();

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPObtenerUnidadDeMedidaLike";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            command.Parameters.AddWithValue("@UDM", pNombre);

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            // Leer el resultado del SqlDataReader mientras haya más filas para leer.
            while (reader.Read())
            {
                // Crear una nueva instancia de UnidadDeMedidaEN para almacenar los datos de cada fila.
                UnidadDeMedidaEN ObjUDM = new UnidadDeMedidaEN();

                // Asignar los valores leídos desde el SqlDataReader a las propiedades del objeto ObjUDM.

                /// Asigna los valores de las columnas leídas del SqlDataReader a las propiedades del objeto UnidadDeMedidaEN.
                ObjUDM.Id = reader.GetInt32(0);
                ObjUDM.UDM = reader.GetString(1);
                ObjUDM.Estatus.Id = reader.GetByte(2);
                ObjUDM.Descripcion = reader.GetString(3);
                ObjUDM.FechaCreacion = reader.GetDateTime(4);
                ObjUDM.FechaModificacion = reader.GetDateTime(5);

                // Agregar el objeto ObjUDM a la lista listaUDM.
                listaUDM.Add(ObjUDM);
            }

            // Después de leer todas las filas y agregar los objetos a la lista, se devuelve la lista que contiene los datos leídos.
            return listaUDM;


        }
    }
}
