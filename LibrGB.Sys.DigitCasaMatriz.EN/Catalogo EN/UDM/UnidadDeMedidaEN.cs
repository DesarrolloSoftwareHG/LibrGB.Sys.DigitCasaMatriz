using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM
{
    public class UnidadDeMedidaEN
    {
        public int Id { get; set; }

        public string? UDM { get; set; }

        public EstatusEN Estatus { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}
