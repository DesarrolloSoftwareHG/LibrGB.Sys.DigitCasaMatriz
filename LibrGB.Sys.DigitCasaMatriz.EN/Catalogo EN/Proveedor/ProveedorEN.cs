using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor
{
    public class ProveedorEN
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? NumeroTelefono { get; set; }

        public string? NumeroCelular { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? SitioWeb { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

    }
}
