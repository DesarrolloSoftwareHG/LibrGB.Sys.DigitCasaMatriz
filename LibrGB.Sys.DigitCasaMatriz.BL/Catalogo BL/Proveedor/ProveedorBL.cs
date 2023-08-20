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

        public int GuardarProveedor(ProveedorEN pProveedorGuardar)
        {
            // Este método recibe un objeto ProveedorEN llamado pProveedorGuardar como argumento.
            // Presumiblemente, ProveedorEN es una clase que representa un proveedor con sus propiedades y métodos relacionados.

            return ObjProveedorDAL.GuardarProveedor(pProveedorGuardar);
            // Llama al método GuardarProveedor de ObjProveedorDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el objeto pProveedorGuardar como argumento.
            // El método GuardarProveedor en el componente de acceso a datos se encarga de guardar el proveedor en la base de datos y retorna un valor entero, que posiblemente representa el ID del proveedor guardado o algún código de éxito o error.

            // Finalmente, el método retorna ese valor entero para que el cliente de este método (otra clase o componente) pueda saber el resultado de la operación de guardado del proveedor.
        }

        public int EliminarProveedor(ProveedorEN pProveedorELiminar)
        {
            // Este método recibe un objeto ProveedorEN llamado pProveedorELiminar como argumento.
            // Presumiblemente, ProveedorEN es una clase que representa un proveedor con sus propiedades y métodos relacionados.

            return ObjProveedorDAL.EliminarProveedor(pProveedorELiminar);
            // Llama al método EliminarProveedor de ObjProveedorDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el objeto pProveedorELiminar como argumento.
            // El método EliminarProveedor en el componente de acceso a datos se encarga de eliminar el proveedor de la base de datos y retorna un valor entero, que posiblemente representa la cantidad de registros afectados o algún código de éxito o error.

            // Finalmente, el método retorna ese valor entero para que el cliente de este método (otra clase o componente) pueda saber el resultado de la operación de eliminación del proveedor.
        }

        public int ModificarProveedor(ProveedorEN pProveedorModificar)
        {
            // Este método recibe un objeto ProveedorEN llamado pProveedorModificar como argumento.
            // Presumiblemente, ProveedorEN es una clase que representa un proveedor con sus propiedades y métodos relacionados.

            return ObjProveedorDAL.ModificarProveedor(pProveedorModificar);
            // Llama al método ModificarProveedor de ObjProveedorDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el objeto pProveedorModificar como argumento.
            // El método ModificarProveedor en el componente de acceso a datos se encarga de modificar los datos del proveedor en la base de datos y retorna un valor entero, que posiblemente representa la cantidad de registros afectados o algún código de éxito o error.

            // Finalmente, el método retorna ese valor entero para que el cliente de este método (otra clase o componente) pueda saber el resultado de la operación de modificación del proveedor.
        }

        public List<ProveedorEN> ObtenerProveedor()
        {
            // Este método no recibe argumentos.

            return ObjProveedorDAL.ObtenerProveedor();
            // Llama al método ObtenerProveedor de ObjProveedorDAL (presumiblemente una clase o componente de acceso a datos).
            // El método ObtenerProveedor en el componente de acceso a datos se encarga de obtener una lista de proveedores desde la base de datos y retorna una lista de objetos ProveedorEN.

            // Finalmente, el método retorna la lista de proveedores obtenida desde la capa de acceso a datos para que el cliente de este método (otra clase o componente) pueda obtener la lista de proveedores y trabajar con ella.
        }

        public ProveedorEN ObtenerPorId(int? pId)
        {
            // Este método recibe un parámetro entero nullable (int?) llamado pId. Presumiblemente, este parámetro representa el ID del proveedor que se desea obtener.

            return ObjProveedorDAL.ObtenerProveedorPorId(pId);
            // Llama al método ObtenerProveedorPorId de ObjProveedorDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el parámetro pId.
            // El método ObtenerProveedorPorId en el componente de acceso a datos se encarga de obtener los datos del proveedor con el ID proporcionado desde la base de datos y retorna un objeto ProveedorEN.

            // Finalmente, el método retorna el objeto ProveedorEN obtenido desde la capa de acceso a datos para que el cliente de este método (otra clase o componente) pueda trabajar con la información del proveedor obtenido.
        }

        public List<ProveedorEN> ObtenerProveedoresLike(string pNombre)
        {
            // Este método recibe un parámetro string llamado pNombre. Presumiblemente, este parámetro representa el nombre (o una parte del nombre) de los proveedores que se desean obtener.

            return ObjProveedorDAL.ObtenerProveedoresLike(pNombre);
            // Llama al método ObtenerProveedoresLike de ObjProveedorDAL (presumiblemente una clase o componente de acceso a datos) y le pasa el parámetro pNombre.
            // El método ObtenerProveedoresLike en el componente de acceso a datos se encarga de obtener una lista de proveedores desde la base de datos que coincidan con el nombre (o una parte del nombre) proporcionado, y retorna una lista de objetos ProveedorEN.

            // Finalmente, el método retorna la lista de proveedores obtenida desde la capa de acceso a datos para que el cliente de este método (otra clase o componente) pueda trabajar con la lista de proveedores obtenida.
        }
    }
}
