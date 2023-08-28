using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------REFERENCIAS---------------
using System.Data.SqlClient;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;

namespace LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Proveedor
{
    public class ProveedorDAL
    {
        public int GuardarProveedor(ProveedorEN pProveedorGuardar)
        {
            //----------- INICIO VALIDACION Nombre YA EXISTENTE ----------
            //Obtener todos los Proveedores
            var proveedores = ObtenerProveedor();

            //Expresion Lambda para buscar un Proveedor usando FirstOrDefault que obtiene el primer registro que coincida con el parametro pProveedorGuardar.Nombre
            var proveedor = proveedores.FirstOrDefault(c => c.Nombre == pProveedorGuardar.Nombre);

            //Validar si el Proveedor es NULL 
            if (proveedor != null)
            {
                return 0;
            }
            //----------- FINAL VALIDACION NOMBRE YA EXISTENTE ----------

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para guardar un proveedor.
            command.CommandText = "SPGuardarProveedor";

            // Agrega parámetros al comando para especificar los valores del proveedor a guardar.
            command.Parameters.AddWithValue("@Nombre", pProveedorGuardar.Nombre);
            command.Parameters.AddWithValue("@Direccion", pProveedorGuardar.Direccion);
            command.Parameters.AddWithValue("@NumeroTelefono", pProveedorGuardar.NumeroTelefono);
            command.Parameters.AddWithValue("@NumeroCelular", pProveedorGuardar.NumeroCelular);
            command.Parameters.AddWithValue("@CorreoElectronico", pProveedorGuardar.CorreoElectronico);
            command.Parameters.AddWithValue("@SitioWeb", pProveedorGuardar.SitioWeb);
            command.Parameters.AddWithValue("@Descripcion", pProveedorGuardar.Descripcion);
            command.Parameters.AddWithValue("@FechaCreacion", pProveedorGuardar.FechaCreacion);

            // Ejecuta el comando y devuelve el resultado de la ejecución.
            return ComunBD.EjecutarComando(command);

        }

        public int ModificarProveedor(ProveedorEN pProveedorModificar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para modificar un proveedor.
            command.CommandText = "SPModificarProveedor";

            // Agrega parámetros al comando para especificar los valores del proveedor a modificar.
            command.Parameters.AddWithValue("@Id", pProveedorModificar.Id);
            command.Parameters.AddWithValue("@Nombre", pProveedorModificar.Nombre);
            command.Parameters.AddWithValue("@Direccion", pProveedorModificar.Direccion);
            command.Parameters.AddWithValue("@NumeroTelefono", pProveedorModificar.NumeroTelefono);
            command.Parameters.AddWithValue("@NumeroCelular", pProveedorModificar.NumeroCelular);
            command.Parameters.AddWithValue("@CorreoElectronico", pProveedorModificar.CorreoElectronico);
            command.Parameters.AddWithValue("@SitioWeb", pProveedorModificar.SitioWeb);
            command.Parameters.AddWithValue("@Descripcion", pProveedorModificar.Descripcion);
            command.Parameters.AddWithValue("@FechaModificacion", pProveedorModificar.FechaModificacion);

            // Ejecuta el comando y devuelve el resultado de la ejecución.
            return ComunBD.EjecutarComando(command);
        }

        public int EliminarProveedor(ProveedorEN pProveedorEliminar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para eliminar un proveedor.
            command.CommandText = "SPEliminarProveedor";

            // Agrega un parámetro al comando para especificar el ID del proveedor a eliminar.
            command.Parameters.AddWithValue("@Id", pProveedorEliminar.Id);

            // Ejecuta el comando y devuelve el resultado de la ejecución.
            return ComunBD.EjecutarComando(command);

        }

        public List<ProveedorEN> ObtenerProveedor()
        {
            // Crea una lista para almacenar objetos de proveedor.
            List<ProveedorEN> listaProveedor = new List<ProveedorEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener la lista de proveedores.
            command.CommandText = "SPMostrarProveedor";

            // Ejecuta el comando y obtiene un lector de datos para obtener los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Itera a través de los resultados del lector de datos.
            while (reader.Read())
            {
                // Crea un objeto ProveedorEN para almacenar la información del proveedor actual.
                ProveedorEN ObjProveedor = new ProveedorEN();

                // Lee y asigna los valores del lector de datos al objeto ProveedorEN.
                ObjProveedor.Id = reader.GetInt32(0);
                ObjProveedor.Nombre = reader.GetString(1);
                ObjProveedor.Direccion = reader.GetString(2);
                ObjProveedor.NumeroTelefono = reader.GetString(3);
                ObjProveedor.NumeroCelular = reader.GetString(4);
                ObjProveedor.CorreoElectronico = reader.GetString(5);
                ObjProveedor.SitioWeb = reader.GetString(6);
                ObjProveedor.Descripcion = reader.GetString(7);
                ObjProveedor.FechaCreacion = reader.GetDateTime(8);
                ObjProveedor.FechaModificacion = reader.GetDateTime(9);

                // Agrega el objeto ProveedorEN a la lista de proveedores.
                listaProveedor.Add(ObjProveedor);
            }

            // Devuelve la lista de proveedores.
            return listaProveedor;
        }

        public ProveedorEN ObtenerProveedorPorId(int? pId)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener los detalles del proveedor por su ID.
            command.CommandText = "SPObtenerProveedorPorId";

            // Agrega el parámetro para el ID del proveedor a la consulta.
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecuta el comando y obtiene un lector de datos para obtener los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crea un objeto ProveedorEN para almacenar la información del proveedor encontrado.
            ProveedorEN proveedor = new ProveedorEN();

            // Lee los datos del proveedor del lector de datos si está disponible.
            if (reader.Read())
            {
                proveedor.Id = reader.GetInt32(0);
                proveedor.Nombre = reader.GetString(1);
                proveedor.Direccion = reader.GetString(2);
                proveedor.NumeroTelefono = reader.GetString(3);
                proveedor.NumeroCelular = reader.GetString(4);
                proveedor.CorreoElectronico = reader.GetString(5);
                proveedor.SitioWeb = reader.GetString(6);
                proveedor.Descripcion = reader.GetString(7);
                proveedor.FechaCreacion = reader.GetDateTime(8);
                proveedor.FechaModificacion = reader.GetDateTime(9);
            }

            // Devuelve el objeto ProveedorEN con los detalles del proveedor.
            return proveedor;
        }

        public List<ProveedorEN> ObtenerProveedoresLike(string pNombre)
        {
            // Crea una lista para almacenar los objetos ProveedorEN que se obtendrán de la base de datos.
            List<ProveedorEN> listaProveedor = new List<ProveedorEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener proveedores similares por su nombre.
            command.CommandText = "SPObtenerProveedorLike";

            // Agrega el parámetro para el nombre del proveedor a la consulta.
            command.Parameters.AddWithValue("@Nombre", pNombre);

            // Ejecuta el comando y obtiene un lector de datos para obtener los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Itera a través de los resultados del lector de datos y crea objetos ProveedorEN con la información obtenida.
            while (reader.Read())
            {
                ProveedorEN ObjProveedor = new ProveedorEN();
                ObjProveedor.Id = reader.GetInt32(0);
                ObjProveedor.Nombre = reader.GetString(1);
                ObjProveedor.Direccion = reader.GetString(2);
                ObjProveedor.NumeroTelefono = reader.GetString(3);
                ObjProveedor.NumeroCelular = reader.GetString(4);
                ObjProveedor.CorreoElectronico = reader.GetString(5);
                ObjProveedor.SitioWeb = reader.GetString(6);
                ObjProveedor.Descripcion = reader.GetString(7);
                ObjProveedor.FechaCreacion = reader.GetDateTime(8);
                ObjProveedor.FechaModificacion = reader.GetDateTime(9);

                // Agrega el objeto ProveedorEN a la lista de proveedores.
                listaProveedor.Add(ObjProveedor);
            }

            // Devuelve la lista de objetos ProveedorEN que coinciden con el nombre especificado.
            return listaProveedor;
        }
    }
}
