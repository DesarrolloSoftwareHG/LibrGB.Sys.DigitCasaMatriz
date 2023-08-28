using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Proveedor;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class ProveedorBL
    {
        ProveedorDAL ObjProveedorDAL = new ProveedorDAL();
        // Se crea una instancia del objeto ProveedorDAL y se asigna a la variable ObjProveedorDAL

        // Guarda un nuevo proveedor en la base de datos.
        public int GuardarProveedor(ProveedorEN pProveedorGuardar)
        {
            return ObjProveedorDAL.GuardarProveedor(pProveedorGuardar);
        }

        // Elimina un proveedor de la base de datos.
        public int EliminarProveedor(ProveedorEN pProveedorELiminar)
        {
            return ObjProveedorDAL.EliminarProveedor(pProveedorELiminar);
        }

        // Modifica un proveedor existente en la base de datos.
        public int ModificarProveedor(ProveedorEN pProveedorModificar)
        {
            return ObjProveedorDAL.ModificarProveedor(pProveedorModificar);
        }

        // Obtiene una lista de todos los proveedores disponibles en la base de datos.
        public List<ProveedorEN> ObtenerProveedor()
        {
            return ObjProveedorDAL.ObtenerProveedor();
        }

        // Obtiene los detalles de un proveedor específico utilizando su identificador.
        public ProveedorEN ObtenerPorId(int? pId)
        {
            return ObjProveedorDAL.ObtenerProveedorPorId(pId);
        }

        // Busca proveedores que coinciden con un nombre dado.
        public List<ProveedorEN> ObtenerProveedoresLike(string pNombre)
        {
            return ObjProveedorDAL.ObtenerProveedoresLike(pNombre);
        }

    }
}
