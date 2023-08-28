using LibrGB.Sys.DigitCasaMatriz.DAL;
using LibrGB.Sys.DigitCasaMatriz.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL
{
    public class GeneroBL
    {
        GeneroDAL ObjGeneroDAL = new GeneroDAL();

        public List<GeneroEN> ObtenerGenero()
        {
            return ObjGeneroDAL.ObtenerGenero();
        }

        public GeneroEN ObtenerGeneroPorId(int? pId)
        {
            return ObjGeneroDAL.ObtenerGeneroPorId(pId);
        }
    }
}