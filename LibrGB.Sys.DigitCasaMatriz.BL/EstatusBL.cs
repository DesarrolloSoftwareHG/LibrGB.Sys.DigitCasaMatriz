using LibrGB.Sys.DigitCasaMatriz.DAL;
using LibrGB.Sys.DigitCasaMatriz.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL
{
    public class EstatusBL
    {
        EstatusDAL ObjEstatusDAL = new EstatusDAL();
        // Se crea una instancia del objeto EstatusDAL y se asigna a la variable ObjEstatusDAL

        public List<EstatusEN> ObtenerEstatus()
        {
            return ObjEstatusDAL.ObtenerEstatus();
            // Llama al método "ObtenerEstatus" de ObjEstatusDAL y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerEstatus" se encarga de obtener una lista de objetos EstatusEN de la base de datos.
        }

        public EstatusEN ObtenerEstatusPorId(int? pId)
        {
            return ObjEstatusDAL.ObtenerEstatusPorId(pId);
            // Llama al método "ObtenerEstatusPorId" de ObjEstatusDAL pasando el parámetro pId y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerEstatusPorId" se encarga de obtener una unidad de medida por su Id desde la base de datos.
            // Realiza la lógica necesaria para buscar y obtener el estatus correspondiente al Id proporcionado
            // y devuelve un objeto EstatusEN con la información del estatus encontrado. El parámetro pId es
            // de tipo int? (nullable), lo que significa que puede ser nulo.
        }
    }
}