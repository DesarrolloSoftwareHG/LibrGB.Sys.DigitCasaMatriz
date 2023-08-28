using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------- REFERENCIAS ------------
using LibrGB.Sys.DigitCasaMatriz.DAL.CatalogoDAL.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;

namespace LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL
{
    public class CategoriaBL
    {
        CategoriaDAL ObjCategoriaDAL = new CategoriaDAL();
        // Se crea la instancia CategoriaDAL y se le asigna el nombre de ObjCategoriaDAL

        // Guarda una nueva categoría en la base de datos.
        public int GuardarCategoria(CategoriaEN pCategoriaGuardar)
        {
            return ObjCategoriaDAL.GuardarCategoria(pCategoriaGuardar);
        }

        // Elimina una categoría de la base de datos.
        public int EliminarCategoria(CategoriaEN pCategoriaELiminar)
        {
            return ObjCategoriaDAL.EliminarCategoria(pCategoriaELiminar);
        }

        // Modifica una categoría existente en la base de datos.
        public int ModificarCategoria(CategoriaEN pcategoriaModificar)
        {
            return ObjCategoriaDAL.ModificarCategoria(pcategoriaModificar);
        }

        // Obtiene una lista de todas las categorías disponibles en la base de datos.
        public List<CategoriaEN> ObtenerCategoria()
        {
            return ObjCategoriaDAL.ObtenerCategoria();
        }

        // Obtiene los detalles de una categoría específica utilizando su identificador.
        public CategoriaEN ObtenerPorId(int? pId)
        {
            return ObjCategoriaDAL.ObtenerCategoriaPorId(pId);
        }

        // Busca categorías que coinciden con un nombre dado.
        public List<CategoriaEN> ObtenerCategoriasLike(string pNombre)
        {
            return ObjCategoriaDAL.ObtenerCategoriasLike(pNombre);
        }

    }
}
