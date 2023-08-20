using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.UDM;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class UnidadDeMedidaBL
    {
        UnidadDeMedidaDAL ObjUDMDAL = new UnidadDeMedidaDAL();

        // Guarda una nueva unidad de medida en la base de datos.
        public int GuardarUDM(UnidadDeMedidaEN pUDMGuardar)
        {
            // Devuelve el resultado del método GuardarUDM de la instancia ObjUDMDAL,
            // que probablemente indica el éxito o el resultado de la operación de guardado en la base de datos.
            return ObjUDMDAL.GuardarUDM(pUDMGuardar);
        }

        // Elimina una unidad de medida de la base de datos.
        public int EliminarUDM(UnidadDeMedidaEN pUDMELiminar)
        {
            // Devuelve el resultado del método EliminarUDM de ObjUDMDAL,
            // que probablemente indica el éxito o el resultado de la operación de eliminación.
            return ObjUDMDAL.EliminarUDM(pUDMELiminar);
        }

        // Modifica una unidad de medida existente en la base de datos.
        public int ModificarUDM(UnidadDeMedidaEN pUDMModificar)
        {
            // Devuelve el resultado del método ModificarUDM de ObjUDMDAL,
            // que probablemente indica el éxito o el resultado de la operación de modificación.
            return ObjUDMDAL.ModificarUDM(pUDMModificar);
        }

        // Obtiene una lista de todas las unidades de medida disponibles en la base de datos.
        public List<UnidadDeMedidaEN> ObtenerUDM()
        {
            // Devuelve la lista de objetos UnidadDeMedidaEN obtenida del método ObtenerUDM de ObjUDMDAL.
            return ObjUDMDAL.ObtenerUDM();
        }

        // Obtiene los detalles de una unidad de medida específica utilizando su identificador.
        public UnidadDeMedidaEN ObtenerPorId(int? pId)
        {
            // Devuelve un solo objeto UnidadDeMedidaEN obtenido del método ObtenerUDMPorId de ObjUDMDAL.
            return ObjUDMDAL.ObtenerUDMPorId(pId);
        }

        // Busca unidades de medida que coinciden con un nombre dado.
        public List<UnidadDeMedidaEN> ObtenerUDMLike(string pNombre)
        {
            // Devuelve una lista de objetos UnidadDeMedidaEN obtenida del método ObtenerUDMLike de ObjUDMDAL,
            // que coinciden con el nombre proporcionado o son similares.
            return ObjUDMDAL.ObtenerUDMLike(pNombre);
        }
    }
}
