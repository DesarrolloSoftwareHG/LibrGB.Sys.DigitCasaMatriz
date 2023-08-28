using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Producto;
using LibrGB.Sys.DigitCasaMatriz.EN;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;

namespace LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Producto
{
    public class ProductoDAL
    {
        public int GuardarProducto(ProductoEN pProductoGuardar)
        {
            //----------- INICIO VALIDACION Nombre YA EXISTENTE ----------

            //Obtener todos los Productos
            var productos = ObtenerProducto();

            //Expresion Lambda para buscar un producto usando FirstOrDefault que obtiene el primer registro que coincida con el parametro pProductoGuardar.Codigo
            var producto = productos.FirstOrDefault(c => c.Codigo == pProductoGuardar.Codigo);

            //Validar si el producto es NULL 
            if (producto != null)
            {
                return 0;
            }

            //----------- FINAL VALIDACION NOMBRE YA EXISTENTE ----------

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPGuardarProducto";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            // Agrega los parámetros necesarios para el procedimiento almacenado, utilizando el objeto pProductoGuardar.
            command.Parameters.AddWithValue("@Nombre", pProductoGuardar.Nombre); // Nombre del producto.

            command.Parameters.AddWithValue("@Codigo", pProductoGuardar.Codigo); // Código del producto.

            command.Parameters.AddWithValue("@IdEstatus", pProductoGuardar.Estatus.Id); // ID del estado del producto.

            command.Parameters.AddWithValue("@Precio", pProductoGuardar.Precio); // Precio del producto.

            command.Parameters.AddWithValue("@IdUDM", pProductoGuardar.UDM.Id); // ID de la Unidad de Medida del producto.

            command.Parameters.AddWithValue("@IdCategoria", pProductoGuardar.Categoria.Id); // ID de la categoría del producto.

            command.Parameters.AddWithValue("@IdProveedor", pProductoGuardar.Proveedor.Id); // ID del proveedor del producto.

            command.Parameters.AddWithValue("@Descripcion", pProductoGuardar.Descripcion); // Descripción del producto.

            command.Parameters.AddWithValue("@FechaCreacion", pProductoGuardar.FechaCreacion); // Fecha de creación del producto.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int ModificarProducto(ProductoEN pProductoModificar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPModificarProducto";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            // Agrega los parámetros necesarios para el procedimiento almacenado, utilizando el objeto pProductoGuardar.
            command.Parameters.AddWithValue("@Nombre", pProductoModificar.Nombre); // Nombre del producto.

            command.Parameters.AddWithValue("@Codigo", pProductoModificar.Codigo); // Código del producto.

            command.Parameters.AddWithValue("@IdEstatus", pProductoModificar.Estatus.Id); // ID del estado del producto.

            command.Parameters.AddWithValue("@Precio", pProductoModificar.Precio); // Precio del producto.

            command.Parameters.AddWithValue("@IdUDM", pProductoModificar.UDM.Id); // ID de la Unidad de Medida del producto.

            command.Parameters.AddWithValue("@IdCategoria", pProductoModificar.Categoria.Id); // ID de la categoría del producto.

            command.Parameters.AddWithValue("@IdProveedor", pProductoModificar.Proveedor.Id); // ID del proveedor del producto.

            command.Parameters.AddWithValue("@Descripcion", pProductoModificar.Descripcion); // Descripción del producto.

            command.Parameters.AddWithValue("@FechaModificacion", pProductoModificar.FechaModificacion); // Fecha de modificacion del producto.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public int EliminarProducto(ProductoEN pProductoEliminar)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPEliminarProducto";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            //---------------------- TRAEMOS LOS PARAMETROS Y DESPUES DEL . VA EL NOMBRE DEL ATRIBUTO DECLARADO EN LA "EN"---------------------------

            command.Parameters.AddWithValue("@Id", pProductoEliminar.Id);
            // Agregar un parámetro llamado "@Id" con el valor de la propiedad Id del objeto pProductoEliminar.

            return ComunBD.EjecutarComando(command);
            // Ejecutar el comando a través del método EjecutarComando() de la clase ComunBD y devolver el resultado.

        }

        public List<ProductoEN> ObtenerProducto()
        {
            List<ProductoEN> listaProducto = new List<ProductoEN>();
            // Crear una nueva lista de objetos de tipo ProductoEN.

            SqlCommand command = ComunBD.ObtenerComando();
            // Obtener un SqlCommand a través del método ObtenerComando() de la clase ComunBD.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Establecer el tipo de comando como un procedimiento almacenado.

            command.CommandText = "SPMostrarProducto";
            // Establecer el nombre del procedimiento almacenado a ejecutar.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Ejecutar el comando y obtener un SqlDataReader a través del método EjecutarComandoReader() de la clase ComunBD.

            // Leer los datos del SqlDataReader mientras haya registros disponibles en el resultado.
            while (reader.Read())
            {
                // Crear una nueva instancia de la clase ProductoEN para almacenar los datos del Producoto actual.
                ProductoEN ObjProducto = new ProductoEN();

                // Leer los valores de las columnas en el Data Grid (SqlDataReader) y asignarlos a las propiedades del objeto ObjProducto.

                ObjProducto.Id = reader.GetInt32(0);

                ObjProducto.Nombre = reader.GetString(1);

                ObjProducto.Codigo = reader.GetString(2);

                ObjProducto.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(11),
                    Nombre = reader.GetString(12)
                };

                ObjProducto.Precio = reader.GetDecimal(4);

                ObjProducto.UDM = new UnidadDeMedidaEN
                {
                    Id = reader.GetInt32(13),
                    UDM = reader.GetString(14)
                };

                ObjProducto.Categoria = new CategoriaEN
                {
                    Id = reader.GetInt32(15),
                    Nombre = reader.GetString(16)
                };

                ObjProducto.Proveedor = new ProveedorEN
                {
                    Id = reader.GetInt32(17),
                    Nombre = reader.GetString(18)
                };

                ObjProducto.Descripcion = reader.GetString(8);

                ObjProducto.FechaCreacion = reader.GetDateTime(9);

                ObjProducto.FechaModificacion = reader.GetDateTime(10);

                // Agregar el objeto ObjProducto a la lista de productos llamada listaProducto.
                listaProducto.Add(ObjProducto);
            }
            // Devolver la lista de Producto que contiene todos los objetos de la clase ProductoEN con los datos leídos del SqlDataReader.
            return listaProducto;
        }

        public ProductoEN ObtenerProductoPorId(int? pId)
        {
            SqlCommand command = ComunBD.ObtenerComando();
            // Se obtiene un nuevo objeto SqlCommand utilizando el método ObtenerComando() del objeto ComunBD. Presumiblemente, esto es para obtener una instancia de SqlCommand configurada para utilizar una conexión de base de datos existente.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Se establece el tipo de comando de la consulta como un stored procedure.

            command.CommandText = "SPObtenerProductoPorId";
            // Se establece el nombre del stored procedure a ejecutar como "SPObtenerProductoPorId".

            command.Parameters.AddWithValue("@Id", pId);
            // Se agrega un parámetro con el nombre "@Id" y se le asigna el valor de la variable pId. Presumiblemente, este parámetro es utilizado en el stored procedure para filtrar los resultados según el ID del proveedor.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Se ejecuta el SqlCommand y se obtiene un SqlDataReader que contendrá los resultados de la consulta. Presumiblemente, el método EjecutarComandoReader se encarga de ejecutar la consulta y obtener los resultados en forma de SqlDataReader.

            ProductoEN producto = new ProductoEN();
            // Se crea una instancia del objeto ProductoEN que presumiblemente es una clase que representa a un producto con sus propiedades y métodos relacionados.

            // Leer los datos del SqlDataReader. Si el SqlDataReader contiene al menos una fila, realiza lo siguiente:
            if (reader.Read())
            {
                // Leer y asignar los valores de las columnas del SqlDataReader a las propiedades del objeto ProveedorEN llamado "proveedor".

                producto.Id = reader.GetInt32(0);

                producto.Nombre = reader.GetString(1);

                producto.Codigo = reader.GetString(2);

                producto.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(3),
                    Nombre = reader.GetString(4)
                };

                producto.Precio = reader.GetDecimal(5);

                producto.UDM = new UnidadDeMedidaEN
                {
                    Id = reader.GetInt32(6),
                    UDM = reader.GetString(7)
                };

                producto.Categoria = new CategoriaEN
                {
                    Id = reader.GetInt32(8),
                    Nombre = reader.GetString(9)
                };

                producto.Proveedor = new ProveedorEN
                {
                    Id = reader.GetInt32(10),
                    Nombre = reader.GetString(11)
                };

                producto.Descripcion = reader.GetString(12);

                producto.FechaCreacion = reader.GetDateTime(13);

                producto.FechaModificacion = reader.GetDateTime(14);
            }

            // Se devuelve el objeto "proveedor" que contiene los valores leídos del SqlDataReader.
            return producto;
        }

        public List<ProductoEN> ObtenerProductosLike(string pCodigo)
        {
            List<ProductoEN> listaProducto = new List<ProductoEN>();
            // Se crea una nueva lista de objetos ProductoEN llamada listaProducto. Presumiblemente, esta lista se utilizará para almacenar los resultados de la consulta.

            SqlCommand command = ComunBD.ObtenerComando();
            // Se obtiene un nuevo objeto SqlCommand utilizando el método ObtenerComando() del objeto ComunBD. Presumiblemente, esto es para obtener una instancia de SqlCommand configurada para utilizar una conexión de base de datos existente.

            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Se establece el tipo de comando de la consulta como un stored procedure.

            command.CommandText = "SPObtenerProductoLike";
            // Se establece el nombre del stored procedure a ejecutar como "SPObtenerProductoLike".

            command.Parameters.AddWithValue("@Codigo", pCodigo);
            // Se agrega un parámetro con el nombre "@Codigo" y se le asigna el valor de la variable pCodigo. Presumiblemente, este parámetro se utiliza en el stored procedure para filtrar los resultados según el nombre del proveedor.

            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);
            // Se ejecuta el SqlCommand y se obtiene un SqlDataReader que contendrá los resultados de la consulta. Presumiblemente, el método EjecutarComandoReader se encarga de ejecutar la consulta y obtener los resultados en forma de SqlDataReader.

            // Leer los datos del SqlDataReader. El bucle se repetirá para cada fila en el SqlDataReader.
            while (reader.Read())
            {
                // Crear una nueva instancia del objeto ProveedorEN llamada "ObjProducto".
                ProductoEN ObjProducto = new ProductoEN();

                // Leer y asignar los valores de las columnas del SqlDataReader a las propiedades del objeto "ObjProveedor".

                ObjProducto.Id = reader.GetInt32(0);

                ObjProducto.Nombre = reader.GetString(1);

                ObjProducto.Codigo = reader.GetString(2);

                ObjProducto.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(3),
                    Nombre = reader.GetString(4)
                };

                ObjProducto.Precio = reader.GetDecimal(5);

                ObjProducto.UDM = new UnidadDeMedidaEN
                {
                    Id = reader.GetInt32(6),
                    UDM = reader.GetString(7)
                };

                ObjProducto.Categoria = new CategoriaEN
                {
                    Id = reader.GetInt32(8),
                    Nombre = reader.GetString(9)
                };

                ObjProducto.Proveedor = new ProveedorEN
                {
                    Id = reader.GetInt32(10),
                    Nombre = reader.GetString(11)
                };

                ObjProducto.Descripcion = reader.GetString(12);

                ObjProducto.FechaCreacion = reader.GetDateTime(13);

                ObjProducto.FechaModificacion = reader.GetDateTime(14);

                // Agregar el objeto "ObjProducto" a la lista de Productos llamada "listaProducto".
                listaProducto.Add(ObjProducto);
            }
            // Devolver la lista de Proveedores que se ha llenado con los datos leídos del SqlDataReader.
            return listaProducto;
        }
    }
}
