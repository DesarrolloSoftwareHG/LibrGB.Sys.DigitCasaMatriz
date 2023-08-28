using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------- REFERENCIAS -----------
using LibrGB.Sys.DigitCasaMatriz.DAL;
using LibrGB.Sys.DigitCasaMatriz.EN;

namespace LibrGB.Sys.DigitCasaMatriz.BL
{
    public class EstatusBL
    {
        EstatusDAL ObjEstatusDAL = new EstatusDAL();
        // Se crea una instancia del objeto EstatusDAL y se asigna a la variable ObjEstatusDAL

        // Obtiene una lista de todos los estatus disponibles en la base de datos.
        public List<EstatusEN> ObtenerEstatus()
        {
            return ObjEstatusDAL.ObtenerEstatus();
        }

        // Obtiene los detalles de un estatus específico utilizando su identificador.
        public EstatusEN ObtenerEstatusPorId(int? pId)
        {
            return ObjEstatusDAL.ObtenerEstatusPorId(pId);
        }

    }
}