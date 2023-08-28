using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------- REFERENCIAS ------------
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

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para guardar un nuevo producto.
            command.CommandText = "SPGuardarProducto";

            // Agrega parámetros al comando con los valores del producto a guardar.
            command.Parameters.AddWithValue("@Nombre", pProductoGuardar.Nombre);
            command.Parameters.AddWithValue("@Codigo", pProductoGuardar.Codigo);
            command.Parameters.AddWithValue("@IdEstatus", pProductoGuardar.Estatus.Id);
            command.Parameters.AddWithValue("@Precio", pProductoGuardar.Precio);
            command.Parameters.AddWithValue("@IdUDM", pProductoGuardar.UDM.Id);
            command.Parameters.AddWithValue("@IdCategoria", pProductoGuardar.Categoria.Id);
            command.Parameters.AddWithValue("@IdProveedor", pProductoGuardar.Proveedor.Id);
            command.Parameters.AddWithValue("@Descripcion", pProductoGuardar.Descripcion);
            command.Parameters.AddWithValue("@FechaCreacion", pProductoGuardar.FechaCreacion);

            // Ejecuta el comando y devuelve el resultado de la operación de guardar el producto.
            return ComunBD.EjecutarComando(command);
        }

        public int ModificarProducto(ProductoEN pProductoModificar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para modificar un producto existente.
            command.CommandText = "SPModificarProducto";

            // Agrega parámetros al comando con los valores del producto a modificar.
            command.Parameters.AddWithValue("@Nombre", pProductoModificar.Nombre);
            command.Parameters.AddWithValue("@Codigo", pProductoModificar.Codigo);
            command.Parameters.AddWithValue("@IdEstatus", pProductoModificar.Estatus.Id);
            command.Parameters.AddWithValue("@Precio", pProductoModificar.Precio);
            command.Parameters.AddWithValue("@IdUDM", pProductoModificar.UDM.Id);
            command.Parameters.AddWithValue("@IdCategoria", pProductoModificar.Categoria.Id);
            command.Parameters.AddWithValue("@IdProveedor", pProductoModificar.Proveedor.Id);
            command.Parameters.AddWithValue("@Descripcion", pProductoModificar.Descripcion);
            command.Parameters.AddWithValue("@FechaModificacion", pProductoModificar.FechaModificacion);

            // Ejecuta el comando y devuelve el resultado de la operación de modificación del producto.
            return ComunBD.EjecutarComando(command);
        }

        public int EliminarProducto(ProductoEN pProductoEliminar)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para eliminar un producto existente.
            command.CommandText = "SPEliminarProducto";

            // Agrega un parámetro al comando con el ID del producto a eliminar.
            command.Parameters.AddWithValue("@Id", pProductoEliminar.Id);

            // Ejecuta el comando y devuelve el resultado de la operación de eliminación del producto.
            return ComunBD.EjecutarComando(command);

        }

        public List<ProductoEN> ObtenerProducto()
        {
            // Crea una nueva lista para almacenar los objetos de productos obtenidos.
            List<ProductoEN> listaProducto = new List<ProductoEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para mostrar los productos.
            command.CommandText = "SPMostrarProducto";

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Lee cada fila de resultados del lector de datos.
            while (reader.Read())
            {
                // Crea un nuevo objeto ProductoEN para almacenar los datos del producto.
                ProductoEN ObjProducto = new ProductoEN();

                // Asigna los valores de las columnas leídas a las propiedades del objeto ProductoEN.
                ObjProducto.Id = reader.GetInt32(0);
                ObjProducto.Nombre = reader.GetString(1);
                ObjProducto.Codigo = reader.GetString(2);

                // Crea un nuevo objeto EstatusEN y asigna sus valores.
                ObjProducto.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(11),
                    Nombre = reader.GetString(12)
                };

                ObjProducto.Precio = reader.GetDecimal(4);

                // Crea un nuevo objeto UnidadDeMedidaEN y asigna sus valores.
                ObjProducto.UDM = new UnidadDeMedidaEN
                {
                    Id = reader.GetInt32(13),
                    UDM = reader.GetString(14)
                };

                // Crea un nuevo objeto CategoriaEN y asigna sus valores.
                ObjProducto.Categoria = new CategoriaEN
                {
                    Id = reader.GetInt32(15),
                    Nombre = reader.GetString(16)
                };

                // Crea un nuevo objeto ProveedorEN y asigna sus valores.
                ObjProducto.Proveedor = new ProveedorEN
                {
                    Id = reader.GetInt32(17),
                    Nombre = reader.GetString(18)
                };

                ObjProducto.Descripcion = reader.GetString(8);
                ObjProducto.FechaCreacion = reader.GetDateTime(9);
                ObjProducto.FechaModificacion = reader.GetDateTime(10);

                // Agrega el objeto ProductoEN a la lista de productos llamada listaProducto.
                listaProducto.Add(ObjProducto);
            }

            // Devuelve la lista de productos obtenida de la base de datos.
            return listaProducto;

        }

        public ProductoEN ObtenerProductoPorId(int? pId)
        {
            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener un producto por su identificador.
            command.CommandText = "SPObtenerProductoPorId";

            // Agrega un parámetro al comando para especificar el ID del producto que se va a buscar.
            command.Parameters.AddWithValue("@Id", pId);

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Crea un nuevo objeto ProductoEN para almacenar los datos del producto.
            ProductoEN producto = new ProductoEN();

            // Lee los datos del lector de datos si hay una fila disponible.
            if (reader.Read())
            {
                // Asigna los valores de las columnas leídas a las propiedades del objeto ProductoEN.
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Codigo = reader.GetString(2);

                // Crea un nuevo objeto EstatusEN y asigna sus valores.
                producto.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(11),
                    Nombre = reader.GetString(12)
                };

                producto.Precio = reader.GetDecimal(4);

                // Crea un nuevo objeto UnidadDeMedidaEN y asigna sus valores.
                producto.UDM = new UnidadDeMedidaEN
                {
                    Id = reader.GetInt32(13),
                    UDM = reader.GetString(14)
                };

                // Crea un nuevo objeto CategoriaEN y asigna sus valores.
                producto.Categoria = new CategoriaEN
                {
                    Id = reader.GetInt32(15),
                    Nombre = reader.GetString(16)
                };

                // Crea un nuevo objeto ProveedorEN y asigna sus valores.
                producto.Proveedor = new ProveedorEN
                {
                    Id = reader.GetInt32(17),
                    Nombre = reader.GetString(18)
                };

                producto.Descripcion = reader.GetString(8);
                producto.FechaCreacion = reader.GetDateTime(9);
                producto.FechaModificacion = reader.GetDateTime(10);
            }

            // Devuelve el objeto ProductoEN que contiene los datos obtenidos.
            return producto;
        }

        public List<ProductoEN> ObtenerProductosLike(string pCodigo)
        {
            // Crea una nueva lista de objetos ProductoEN para almacenar los productos obtenidos.
            List<ProductoEN> listaProducto = new List<ProductoEN>();

            // Crea un nuevo comando SQL utilizando la conexión de la base de datos.
            SqlCommand command = ComunBD.ObtenerComando();

            // Establece el tipo de comando como una llamada a un procedimiento almacenado.
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Define el nombre del procedimiento almacenado que se utilizará para obtener productos similares por código.
            command.CommandText = "SPObtenerProductoLike";

            // Agrega un parámetro al comando para especificar el código por el cual se buscarán productos similares.
            command.Parameters.AddWithValue("@Codigo", pCodigo);

            // Ejecuta el comando y obtiene un lector de datos para leer los resultados.
            SqlDataReader reader = ComunBD.EjecutarComandoReader(command);

            // Lee cada fila del lector de datos si hay resultados disponibles.
            while (reader.Read())
            {
                // Crea un nuevo objeto ProductoEN para almacenar los datos del producto.
                ProductoEN ObjProducto = new ProductoEN();

                // Asigna los valores de las columnas leídas a las propiedades del objeto ProductoEN.
                ObjProducto.Id = reader.GetInt32(0);
                ObjProducto.Nombre = reader.GetString(1);
                ObjProducto.Codigo = reader.GetString(2);

                // Crea un nuevo objeto EstatusEN y asigna sus valores.
                ObjProducto.Estatus = new EstatusEN
                {
                    Id = reader.GetInt32(11),
                    Nombre = reader.GetString(12)
                };

                ObjProducto.Precio = reader.GetDecimal(4);

                // Crea un nuevo objeto UnidadDeMedidaEN y asigna sus valores.
                ObjProducto.UDM = new UnidadDeMedidaEN
                {
                    Id = reader.GetInt32(13),
                    UDM = reader.GetString(14)
                };

                // Crea un nuevo objeto CategoriaEN y asigna sus valores.
                ObjProducto.Categoria = new CategoriaEN
                {
                    Id = reader.GetInt32(15),
                    Nombre = reader.GetString(16)
                };

                // Crea un nuevo objeto ProveedorEN y asigna sus valores.
                ObjProducto.Proveedor = new ProveedorEN
                {
                    Id = reader.GetInt32(17),
                    Nombre = reader.GetString(18)
                };

                ObjProducto.Descripcion = reader.GetString(8);
                ObjProducto.FechaCreacion = reader.GetDateTime(9);
                ObjProducto.FechaModificacion = reader.GetDateTime(10);

                // Agrega el objeto ProductoEN a la lista de productos.
                listaProducto.Add(ObjProducto);
            }

            // Devuelve la lista de productos obtenida.
            return listaProducto;
        }
    }
}
