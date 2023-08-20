using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;

namespace LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Producto
{
    public class ProductoEN
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Codigo { get; set; }

        public EstatusEN Estatus { get; set; }

        public decimal Precio { get; set; }

        public UnidadDeMedidaEN UDM { get; set; }

        public CategoriaEN Categoria { get; set; }

        public ProveedorEN Proveedor { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

    }
}
