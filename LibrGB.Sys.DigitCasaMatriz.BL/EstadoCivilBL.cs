using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.UDM;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL
{
    public class EstadoCivilBL
    {
        UnidadDeMedidaDAL ObjUnidadDeMedidaDAL = new UnidadDeMedidaDAL();
        // Se crea una instancia del objeto UnidadDeMedidaDAL y se asigna a la variable ObjUnidadDeMedidaDAL

        public List<UnidadDeMedidaEN> ObtenerUnidadDeMedida()
        {
            return ObjUnidadDeMedidaDAL.ObtenerUDM();
            // Llama al método "ObtenerUDM" de ObjUnidadDeMedidaDAL y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerUnidadDeMedida" se encarga de obtener una lista de objetos UnidadDeMedidaEN de la base de datos.
        }

        public UnidadDeMedidaEN ObtenerUnidadDeMedidaPorId(int? pId)
        {
            return ObjUnidadDeMedidaDAL.ObtenerUDMPorId(pId);
            // Llama al método "ObtenerUDMPorId" de ObjUnidadDeMedidaDAL pasando el parámetro pId y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerUnidadDeMedidaPorId" se encarga de obtener una unidad de medida por su Id desde la base de datos.
            // Realiza la lógica necesaria para buscar y obtener la unidad de medida correspondiente al Id proporcionado
            // y devuelve un objeto UnidadDeMedidaEN con la información de la Unidad de medida encontrada. El parámetro pId es
            // de tipo int? (nullable), lo que significa que puede ser nulo.
        }
    }
}
