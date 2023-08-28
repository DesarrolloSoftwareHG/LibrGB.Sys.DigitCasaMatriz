using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------- REFERENCIAS ---------
using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.UDM;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;

namespace LibrGB.Sys.DigitCasaMatriz.BL
{
    public class EstadoCivilBL
    {
        UnidadDeMedidaDAL ObjUnidadDeMedidaDAL = new UnidadDeMedidaDAL();

        public List<UnidadDeMedidaEN> ObtenerUnidadDeMedida()
        {
            return ObjUnidadDeMedidaDAL.ObtenerUDM();
        }

        public UnidadDeMedidaEN ObtenerUnidadDeMedidaPorId(int? pId)
        {
            return ObjUnidadDeMedidaDAL.ObtenerUDMPorId(pId);
        }
    }
}
