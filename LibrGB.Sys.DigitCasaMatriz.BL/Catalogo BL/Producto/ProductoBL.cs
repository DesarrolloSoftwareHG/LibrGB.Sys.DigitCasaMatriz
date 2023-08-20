using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Producto;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class ProductoBL
    {
        ProductoDAL ObjProductoDAL = new ProductoDAL();
        // Se crea una instancia del objeto ProductoDAL y se asigna a la variable ObjProductoDAL

        public int GuardarProducto(ProductoEN pProductoGuardar)
        {
            // Este método recibe un objeto ProductoEN llamado pProductoGuardar como argumento.
            // Presumiblemente, ProductoEN es una clase que representa un proveedor con sus propiedades y métodos relacionados.

            return ObjProductoDAL.GuardarProducto(pProductoGuardar);
            // Llama al método GuardarProducto de ObjProductoDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el objeto pProductoGuardar como argumento.
            // El método GuardarProducto en el componente de acceso a datos se encarga de guardar el producto en la base de datos y retorna un valor entero, que posiblemente representa el ID del proveedor guardado o algún código de éxito o error.

            // Finalmente, el método retorna ese valor entero para que el cliente de este método (otra clase o componente) pueda saber el resultado de la operación de guardado del producto.
        }

        public int EliminarProducto(ProductoEN pProductoELiminar)
        {
            // Este método recibe un objeto ProductoEN llamado pProductoELiminar como argumento.
            // Presumiblemente, ProductoEN es una clase que representa un producto con sus propiedades y métodos relacionados.

            return ObjProductoDAL.EliminarProducto(pProductoELiminar);
            // Llama al método EliminarProducto de ObjProductoDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el objeto pProductoELiminar como argumento.
            // El método EliminarProducto en el componente de acceso a datos se encarga de eliminar el producto de la base de datos y retorna un valor entero, que posiblemente representa la cantidad de registros afectados o algún código de éxito o error.

            // Finalmente, el método retorna ese valor entero para que el cliente de este método (otra clase o componente) pueda saber el resultado de la operación de eliminación del producto.
        }

        public int ModificarProducto(ProductoEN pProductoModificar)
        {
            // Este método recibe un objeto ProductoEN llamado pProductoModificar como argumento.
            // Presumiblemente, ProductoEN es una clase que representa un producto con sus propiedades y métodos relacionados.

            return ObjProductoDAL.ModificarProducto(pProductoModificar);
            // Llama al método ModificarProducto de ObjProductoDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el objeto pProductoModificar como argumento.
            // El método ModificarProducto en el componente de acceso a datos se encarga de modificar los datos del producto en la base de datos y retorna un valor entero, que posiblemente representa la cantidad de registros afectados o algún código de éxito o error.

            // Finalmente, el método retorna ese valor entero para que el cliente de este método (otra clase o componente) pueda saber el resultado de la operación de modificación del producto.
        }

        public List<ProductoEN> ObtenerProducto()
        {
            // Este método no recibe argumentos.

            return ObjProductoDAL.ObtenerProducto();
            // Llama al método ObtenerProducto de ObjProductoDAL (presumiblemente una clase o componente de acceso a datos).
            // El método ObtenerProducto en el componente de acceso a datos se encarga de obtener una lista de productos desde la base de datos y retorna una lista de objetos ProductoEN.

            // Finalmente, el método retorna la lista de productos obtenida desde la capa de acceso a datos para que el cliente de este método (otra clase o componente) pueda obtener la lista de proveedores y trabajar con ella.
        }

        public ProductoEN ObtenerPorId(int? pId)
        {
            // Este método recibe un parámetro entero nullable (int?) llamado pId. Presumiblemente, este parámetro representa el ID del producto que se desea obtener.

            return ObjProductoDAL.ObtenerProductoPorId(pId);
            // Llama al método ObtenerProductoPorId de ObjProductoDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el parámetro pId.
            // El método ObtenerProductoPorId en el componente de acceso a datos se encarga de obtener los datos del producto con el ID proporcionado desde la base de datos y retorna un objeto ProveedorEN.

            // Finalmente, el método retorna el objeto ProductoEN obtenido desde la capa de acceso a datos para que el cliente de este método (otra clase o componente) pueda trabajar con la información del proveedor obtenido.
        }

        public List<ProductoEN> ObtenerProductoLike(string pCodigo)
        {
            // Este método recibe un parámetro string llamado pCodigo. Presumiblemente, este parámetro representa el nombre (o una parte del nombre) de los Productos que se desean obtener.

            return ObjProductoDAL.ObtenerProductosLike(pCodigo);
            // Llama al método ObtenerProductosLike de ObjProductoDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el parámetro pCodigo.
            // El método ObtenerProductosLike en el componente de acceso a datos se encarga de obtener una lista de productos desde la base de datos que coincidan con el Codigo (o una parte del nombre) proporcionado, y retorna una lista de objetos ProveedorEN.

            // Finalmente, el método retorna la lista de productos obtenida desde la capa de acceso a datos para que el cliente de este método (otra clase o componente) pueda trabajar con la lista de proveedores obtenida.
        }
    }
}
