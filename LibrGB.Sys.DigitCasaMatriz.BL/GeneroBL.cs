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
        // Se crea una instancia del objeto GeneroDAL y se asigna a la variable ObjGeneroDAL

        public List<GeneroEN> ObtenerGenero()
        {
            return ObjGeneroDAL.ObtenerGenero();
            // Llama al método "ObtenerGenero" de ObjGeneroDAL y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerGenero" se encarga de obtener una lista de objetos GeneroEN de la base de datos.
        }

        public GeneroEN ObtenerGeneroPorId(int? pId)
        {
            return ObjGeneroDAL.ObtenerGeneroPorId(pId);
            // Llama al método "ObtenerGeneroPorId" de ObjGeneroDAL pasando el parámetro pId y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerGeneroPorId" se encarga de obtener un genero por su Id desde la base de datos.
            // Realiza la lógica necesaria para buscar y obtener el genero correspondiente al Id proporcionado
            // y devuelve un objeto GeneroEN con la información del Genero encontrado. El parámetro pId es
            // de tipo int? (nullable), lo que significa que puede ser nulo.
        }
    }
}