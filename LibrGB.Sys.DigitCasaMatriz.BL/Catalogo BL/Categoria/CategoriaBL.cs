using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class CategoriaBL
    {
        CategoriaDAL ObjCategoriaDAL = new CategoriaDAL();
        // Se crea una instancia del objeto CategoriaDAL y se asigna a la variable ObjCategoriaDAL

        public int GuardarCategoria(CategoriaEN pCategoriaGuardar)
        {
            return ObjCategoriaDAL.GuardarCategoria(pCategoriaGuardar);
            // Llama al método "GuardarCategoria" de ObjCategoriaDAL pasando el objeto pCategoriaGuardar como argumento y devuelve el resultado.

            // Comentario adicional: 
            // El método "GuardarCategoria" se encarga de guardar la categoría pCategoriaGuardar en la base de datos.
            // El valor devuelto indica el resultado de la operación de guardado, por ejemplo, el número de filas afectadas.
        }

        public int EliminarCategoria(CategoriaEN pCategoriaELiminar)
        {
            return ObjCategoriaDAL.EliminarCategoria(pCategoriaELiminar);
            // Llama al método "EliminarCategoria" de ObjCategoriaDAL pasando el objeto pCategoriaELiminar como argumento y devuelve el resultado.

            // Comentario adicional:
            // El método "EliminarCategoria" se encarga de eliminar la categoría pCategoriaELiminar de la base de datos.
        }

        public int ModificarCategoria(CategoriaEN pcategoriaModificar)
        {
            return ObjCategoriaDAL.ModificarCategoria(pcategoriaModificar);
            // Llama al método "ModificarCategoria" de ObjCategoriaDAL pasando el objeto pcategoriaModificar como argumento y devuelve el resultado.

            // Comentario adicional:
            // El método "ModificarCategoria" se encarga de modificar la categoría pcategoriaModificar en la base de datos.
        }

        public List<CategoriaEN> ObtenerCategoria()
        {
            return ObjCategoriaDAL.ObtenerCategoria();
            // Llama al método "ObtenerCategoria" de ObjCategoriaDAL y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerCategoria" se encarga de obtener una lista de objetos CategoriaEN de la base de datos.
        }

        public CategoriaEN ObtenerPorId(int? pId)
        {
            return ObjCategoriaDAL.ObtenerCategoriaPorId(pId);
            // Llama al método "ObtenerCategoriaPorId" de ObjCategoriaDAL pasando el parámetro pId y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerPorId" se encarga de obtener una categoría por su Id desde la base de datos.
            // Realiza la lógica necesaria para buscar y obtener la categoría correspondiente al Id proporcionado
            // y devuelve un objeto CategoriaEN con la información de la categoría encontrada. El parámetro pId es
            // de tipo int? (nullable), lo que significa que puede ser nulo.
        }

        public List<CategoriaEN> ObtenerCategoriasLike(string pNombre)
        {
            return ObjCategoriaDAL.ObtenerCategoriasLike(pNombre);
            // Llama al método "ObtenerCategoriasLike" de ObjCategoriaDAL pasando el parámetro pNombre y devuelve el resultado.

            // Comentario adicional:
            // El método "ObtenerCategoriasLike" se encarga de obtener una lista de objetos CategoriaEN que coincidan con un patrón de nombre proporcionado.
            // Realiza la lógica necesaria para buscar y obtener las categorías cuyo nombre coincide parcialmente con el valor proporcionado en pNombre,
            // y devuelve una lista que contiene objetos CategoriaEN con la información correspondiente de cada categoría encontrada.
        }
    }
}
