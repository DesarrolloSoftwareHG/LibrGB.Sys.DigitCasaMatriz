using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------- REFERENCIAS ----------
using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Producto;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Producto;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class ProductoBL
    {
        ProductoDAL ObjProductoDAL = new ProductoDAL();
        // Creamos la instancia de ProductoDAL y le asignamos el nombre de ObjProductoDAL

        // Guarda un nuevo producto en la base de datos.
        public int GuardarProducto(ProductoEN pProductoGuardar)
        {
            return ObjProductoDAL.GuardarProducto(pProductoGuardar);
        }

        // Elimina un producto de la base de datos.
        public int EliminarProducto(ProductoEN pProductoELiminar)
        {
            return ObjProductoDAL.EliminarProducto(pProductoELiminar);
        }

        // Modifica un producto existente en la base de datos.
        public int ModificarProducto(ProductoEN pProductoModificar)
        {
            return ObjProductoDAL.ModificarProducto(pProductoModificar);
        }

        // Obtiene una lista de todos los productos disponibles en la base de datos.
        public List<ProductoEN> ObtenerProducto()
        {
            return ObjProductoDAL.ObtenerProducto();
        }

        // Obtiene los detalles de un producto específico utilizando su identificador.
        public ProductoEN ObtenerPorId(int? pId)
        {
            return ObjProductoDAL.ObtenerProductoPorId(pId);
        }

        // Busca productos que coinciden con un código dado.
        public List<ProductoEN> ObtenerProductoLike(string pCodigo)
        {
            return ObjProductoDAL.ObtenerProductosLike(pCodigo);
        }

    }
}
