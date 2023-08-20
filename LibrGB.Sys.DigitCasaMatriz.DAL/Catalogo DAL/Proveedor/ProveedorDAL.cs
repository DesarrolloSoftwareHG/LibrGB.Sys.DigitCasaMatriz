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

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPGuardarProveedor";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Nombre", pProveedorGuardar.Nombre);
            // Agrega un parámetro con el nombre "@Nombre" y le asigna el valor de la propiedad "Nombre" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@Direccion", pProveedorGuardar.Direccion);
            // Agrega un parámetro con el nombre "@Direccion" y le asigna el valor de la propiedad "Direccion" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@NumeroTelefono", pProveedorGuardar.NumeroTelefono);
            // Agrega un parámetro con el nombre "@Telefono" y le asigna el valor de la propiedad "Telefono" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@NumeroCelular", pProveedorGuardar.NumeroCelular);
            // Agrega un parámetro con el nombre "@Celular" y le asigna el valor de la propiedad "Celular" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@CorreoElectronico", pProveedorGuardar.CorreoElectronico);
            // Agrega un parámetro con el nombre "@Correo_Electronico" y le asigna el valor de la propiedad "CorreoElectronico" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@SitioWeb", pProveedorGuardar.SitioWeb);
            // Agrega un parámetro con el nombre "@Sitio_Web" y le asigna el valor de la propiedad "SitioWeb" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@Descripcion", pProveedorGuardar.Descripcion);
            // Agrega un parámetro con el nombre "@Descripcion" y le asigna el valor de la propiedad "Descripcion" del objeto pProveedorGuardar.

            command.Parameters.AddWithValue("@FechaCreacion", pProveedorGuardar.FechaCreacion);
            // Agrega un parámetro con el nombre "@Fecha_De_Creacion" y le asigna el valor de la propiedad "FechaCreacion" del objeto pProveedorGuardar.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int ModificarProveedor(ProveedorEN pProveedorModificar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPModificarProveedor";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Id", pProveedorModificar.Id);
            // Agrega un parámetro con el nombre "@Id" y le asigna el valor de la propiedad "IdProveedor" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@Nombre", pProveedorModificar.Nombre);
            // Agrega un parámetro con el nombre "@Nombre" y le asigna el valor de la propiedad "Nombre" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@Direccion", pProveedorModificar.Direccion);
            // Agrega un parámetro con el nombre "@Direccion" y le asigna el valor de la propiedad "Direccion" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@NumeroTelefono", pProveedorModificar.NumeroTelefono);
            // Agrega un parámetro con el nombre "@Telefono" y le asigna el valor de la propiedad "Telefono" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@NumeroCelular", pProveedorModificar.NumeroCelular);
            // Agrega un parámetro con el nombre "@Celular" y le asigna el valor de la propiedad "Celular" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@CorreoElectronico", pProveedorModificar.CorreoElectronico);
            // Agrega un parámetro con el nombre "@Correo_Electronico" y le asigna el valor de la propiedad "CorreoElectronico" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@SitioWeb", pProveedorModificar.SitioWeb);
            // Agrega un parámetro con el nombre "@Sitio_Web" y le asigna el valor de la propiedad "SitioWeb" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@Descripcion", pProveedorModificar.Descripcion);
            // Agrega un parámetro con el nombre "@Descripcion" y le asigna el valor de la propiedad "Descripcion" del objeto pProveedorModificar.

            command.Parameters.AddWithValue("@FechaModificacion", pProveedorModificar.FechaModificacion);
            // Agrega un parámetro con el nombre "@Fecha_De_Modificacion" y le asigna el valor de la propiedad "FechaModificacion" del objeto pProveedorModificar.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int EliminarProveedor(ProveedorEN pProveedorEliminar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPEliminarProveedor";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Id", pProveedorEliminar.Id);
            // Agregar un parámetro llamado "@Id" con el valor de la propiedad IdCategoria del objeto pProveedorEliminar.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public List<ProveedorEN> ObtenerProveedor()
        {
            List<ProveedorEN> listaProveedor = new List<ProveedorEN>();
            // Crear una nueva lista de objetos de tipo ProveedorEN.

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPMostrarProveedor";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            // Leer los datos del SqlDataReader mientras haya registros disponibles en el resultado.
            while (reader.Read())
            {
                // Crear una nueva instancia de la clase ProveedorEN para almacenar los datos del Proveedor actual.
                ProveedorEN ObjProveedor = new ProveedorEN();

                // Leer los valores de las columnas en el Data Grid (SqlDataReader) y asignarlos a las propiedades del objeto ObjProveedor.

                ObjProveedor.Id = reader.GetInt32(0);
                // Leer el valor de la columna en la posición 0 (primer columna) y asignarlo a la propiedad IdProveedor del objeto.

                ObjProveedor.Nombre = reader.GetString(1);
                // Leer el valor de la columna en la posición 1 (segunda columna) y asignarlo a la propiedad Nombre del objeto.

                ObjProveedor.Direccion = reader.GetString(2);
                // Leer el valor de la columna en la posición 2 (tercera columna) y asignarlo a la propiedad Direccion del objeto.

                ObjProveedor.NumeroTelefono = reader.GetString(3);
                // Leer el valor de la columna en la posición 3 (cuarta columna) y asignarlo a la propiedad Telefono del objeto.

                ObjProveedor.NumeroCelular = reader.GetString(4);
                // Leer el valor de la columna en la posición 4 (quinta columna) y asignarlo a la propiedad Celular del objeto.

                ObjProveedor.CorreoElectronico = reader.GetString(5);
                // Leer el valor de la columna en la posición 5 (sexta columna) y asignarlo a la propiedad CorreoElectronico del objeto.

                ObjProveedor.SitioWeb = reader.GetString(6);
                // Leer el valor de la columna en la posición 6 (séptima columna) y asignarlo a la propiedad SitioWeb del objeto.

                ObjProveedor.Descripcion = reader.GetString(7);
                // Leer el valor de la columna en la posición 7 (octava columna) y asignarlo a la propiedad Descripcion del objeto.

                ObjProveedor.FechaCreacion = reader.GetDateTime(8);
                // Leer el valor de la columna en la posición 8 (novena columna) y asignarlo a la propiedad FechaCreacion del objeto.

                ObjProveedor.FechaModificacion = reader.GetDateTime(9);
                // Leer el valor de la columna en la posición 9 (décima columna) y asignarlo a la propiedad FechaModificacion del objeto.

                // Agregar el objeto ObjProveedor a la lista de proveedores llamada listaProveedor.
                listaProveedor.Add(ObjProveedor);
            }
            // Devolver la lista de Proveedores que contiene todos los objetos de la clase ProveedorEN con los datos leídos del SqlDataReader.
            return listaProveedor;
        }

        public ProveedorEN ObtenerProveedorPorId(int? pId)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Se obtiene un nuevo objeto SqlCommand utilizando el método ObtenerComando() del objeto ComunBD. Presumiblemente, esto es para obtener una instancia de SqlCommand configurada para utilizar una conexión de base de datos existente.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Se establece el tipo de comando de la consulta como un stored procedure.

            command.CommandText = "SPObtenerProveedorPorId";
            // Se establece el nombre del stored procedure a ejecutar como "SPObtenerProveedorPorId".

            command.Parameters.AddWithValue("@Id", pId);
            // Se agrega un parámetro con el nombre "@Id" y se le asigna el valor de la variable pId. Presumiblemente, este parámetro es utilizado en el stored procedure para filtrar los resultados según el ID del proveedor.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Se ejecuta el SqlCommand y se obtiene un SqlDataReader que contendrá los resultados de la consulta. Presumiblemente, el método EjecutarComandoReader se encarga de ejecutar la consulta y obtener los resultados en forma de SqlDataReader.

            ProveedorEN proveedor = new ProveedorEN();
            // Se crea una instancia del objeto ProveedorEN que presumiblemente es una clase que representa a un proveedor con sus propiedades y métodos relacionados.

            // Leer los datos del SqlDataReader. Si el SqlDataReader contiene al menos una fila, realiza lo siguiente:
            if (reader.Read())
            {
                // Leer y asignar los valores de las columnas del SqlDataReader a las propiedades del objeto ProveedorEN llamado "proveedor".

                proveedor.Id = reader.GetInt32(0);
                // Leer el valor de la columna en la posición 0 (primer columna) y asignarlo a la propiedad IdProveedor del objeto "proveedor".

                proveedor.Nombre = reader.GetString(1);
                // Leer el valor de la columna en la posición 1 (segunda columna) y asignarlo a la propiedad Nombre del objeto "proveedor".

                proveedor.Direccion = reader.GetString(2);
                // Leer el valor de la columna en la posición 2 (tercera columna) y asignarlo a la propiedad Direccion del objeto "proveedor".

                proveedor.NumeroTelefono = reader.GetString(3);
                // Leer el valor de la columna en la posición 3 (cuarta columna) y asignarlo a la propiedad Telefono del objeto "proveedor".

                proveedor.NumeroCelular = reader.GetString(4);
                // Leer el valor de la columna en la posición 4 (quinta columna) y asignarlo a la propiedad Celular del objeto "proveedor".

                proveedor.CorreoElectronico = reader.GetString(5);
                // Leer el valor de la columna en la posición 5 (sexta columna) y asignarlo a la propiedad CorreoElectronico del objeto "proveedor".

                proveedor.SitioWeb = reader.GetString(6);
                // Leer el valor de la columna en la posición 6 (séptima columna) y asignarlo a la propiedad SitioWeb del objeto "proveedor".

                proveedor.Descripcion = reader.GetString(7);
                // Leer el valor de la columna en la posición 7 (octava columna) y asignarlo a la propiedad Descripcion del objeto "proveedor".

                proveedor.FechaCreacion = reader.GetDateTime(8);
                // Leer el valor de la columna en la posición 8 (novena columna) y asignarlo a la propiedad FechaCreacion del objeto "proveedor".

                proveedor.FechaModificacion = reader.GetDateTime(9);
                // Leer el valor de la columna en la posición 9 (décima columna) y asignarlo a la propiedad FechaModificacion del objeto "proveedor".
            }

            // Se devuelve el objeto "proveedor" que contiene los valores leídos del SqlDataReader.
            return proveedor;
        }

        public List<ProveedorEN> ObtenerProveedoresLike(string pNombre)
        {
            List<ProveedorEN> listaProveedor = new List<ProveedorEN>();
            // Se crea una nueva lista de objetos ProveedorEN llamada listaProveedor. Presumiblemente, esta lista se utilizará para almacenar los resultados de la consulta.

            SqlCommand command = ComunBD.ObtenerComando();
            // Se obtiene un nuevo objeto SqlCommand utilizando el método ObtenerComando() del objeto ComunBD. Presumiblemente, esto es para obtener una instancia de SqlCommand configurada para utilizar una conexión de base de datos existente.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Se establece el tipo de comando de la consulta como un stored procedure.

            command.CommandText = "SPObtenerProveedorLike";
            // Se establece el nombre del stored procedure a ejecutar como "SPObtenerProveedoresLike".

            command.Parameters.AddWithValue("@Nombre", pNombre);
            // Se agrega un parámetro con el nombre "@Nombre" y se le asigna el valor de la variable pNombre. Presumiblemente, este parámetro se utiliza en el stored procedure para filtrar los resultados según el nombre del proveedor.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Se ejecuta el SqlCommand y se obtiene un SqlDataReader que contendrá los resultados de la consulta. Presumiblemente, el método EjecutarComandoReader se encarga de ejecutar la consulta y obtener los resultados en forma de SqlDataReader.

            // Leer los datos del SqlDataReader. El bucle se repetirá para cada fila en el SqlDataReader.
            while (reader.Read())
            {
                // Crear una nueva instancia del objeto ProveedorEN llamada "ObjProveedor".
                ProveedorEN ObjProveedor = new ProveedorEN();

                // Leer y asignar los valores de las columnas del SqlDataReader a las propiedades del objeto "ObjProveedor".

                ObjProveedor.Id = reader.GetInt32(0);
                // Leer el valor de la columna en la posición 0 (primer columna) y asignarlo a la propiedad IdProveedor del objeto "ObjProveedor".

                ObjProveedor.Nombre = reader.GetString(1);
                // Leer el valor de la columna en la posición 1 (segunda columna) y asignarlo a la propiedad Nombre del objeto "ObjProveedor".

                ObjProveedor.Direccion = reader.GetString(2);
                // Leer el valor de la columna en la posición 2 (tercera columna) y asignarlo a la propiedad Direccion del objeto "ObjProveedor".

                ObjProveedor.NumeroTelefono = reader.GetString(3);
                // Leer el valor de la columna en la posición 3 (cuarta columna) y asignarlo a la propiedad Telefono del objeto "ObjProveedor".

                ObjProveedor.NumeroCelular = reader.GetString(4);
                // Leer el valor de la columna en la posición 4 (quinta columna) y asignarlo a la propiedad Celular del objeto "ObjProveedor".

                ObjProveedor.CorreoElectronico = reader.GetString(5);
                // Leer el valor de la columna en la posición 5 (sexta columna) y asignarlo a la propiedad CorreoElectronico del objeto "ObjProveedor".

                ObjProveedor.SitioWeb = reader.GetString(6);
                // Leer el valor de la columna en la posición 6 (séptima columna) y asignarlo a la propiedad SitioWeb del objeto "ObjProveedor".

                ObjProveedor.Descripcion = reader.GetString(7);
                // Leer el valor de la columna en la posición 7 (octava columna) y asignarlo a la propiedad Descripcion del objeto "ObjProveedor".

                ObjProveedor.FechaCreacion = reader.GetDateTime(8);
                // Leer el valor de la columna en la posición 8 (novena columna) y asignarlo a la propiedad FechaCreacion del objeto "ObjProveedor".

                ObjProveedor.FechaModificacion = reader.GetDateTime(9);
                // Leer el valor de la columna en la posición 9 (décima columna) y asignarlo a la propiedad FechaModificacion del objeto "ObjProveedor".

                // Agregar el objeto "ObjProveedor" a la lista de proveedores llamada "listaProveedor".
                listaProveedor.Add(ObjProveedor);
            }
            // Devolver la lista de Proveedores que se ha llenado con los datos leídos del SqlDataReader.
            return listaProveedor;
        }
    }
}
