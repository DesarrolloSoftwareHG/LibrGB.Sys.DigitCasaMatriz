using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------ REFERENCIAS --------------
using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.UDM;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class UnidadDeMedidaBL
    {
        UnidadDeMedidaDAL ObjUDMDAL = new UnidadDeMedidaDAL();
        // Creamos la instancia de UnidadDeMedida y se le asigna el nombre de ObjUDMDAL

        // Guarda una nueva unidad de medida en la base de datos.
        public int GuardarUDM(UnidadDeMedidaEN pUDMGuardar)
        {
            return ObjUDMDAL.GuardarUDM(pUDMGuardar);
        }

        // Elimina una unidad de medida de la base de datos.
        public int EliminarUDM(UnidadDeMedidaEN pUDMELiminar)
        {
            return ObjUDMDAL.EliminarUDM(pUDMELiminar);
        }

        // Modifica una unidad de medida existente en la base de datos.
        public int ModificarUDM(UnidadDeMedidaEN pUDMModificar)
        {
            return ObjUDMDAL.ModificarUDM(pUDMModificar);
        }

        // Obtiene una lista de todas las unidades de medida disponibles en la base de datos.
        public List<UnidadDeMedidaEN> ObtenerUDM()
        {
            return ObjUDMDAL.ObtenerUDM();
        }

        // Obtiene los detalles de una unidad de medida específica utilizando su identificador.
        public UnidadDeMedidaEN ObtenerPorId(int? pId)
        {
            return ObjUDMDAL.ObtenerUDMPorId(pId);
        }

        // Busca unidades de medida que coinciden con un nombre dado.
        public List<UnidadDeMedidaEN> ObtenerUDMLike(string pNombre)
        {
            return ObjUDMDAL.ObtenerUDMLike(pNombre);
        }

    }
}
