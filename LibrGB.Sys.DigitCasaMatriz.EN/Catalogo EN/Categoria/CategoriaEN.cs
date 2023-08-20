using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria
{
    public class CategoriaEN
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}
