using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrGB.Sys.DigitCasaMatriz.EN
{
    public class Acciones
    {
        /// <summary>
        /// Enumeración que representa las acciones posibles en un contexto determinado.
        /// </summary>

        public enum AccionEnum
        {
            Crear = 1,       // Valor de enum para la acción de "Crear" es 1
            Modificar = 2,   // Valor de enum para la acción de "Modificar" es 2
            Eliminar = 3,     // Valor de enum para la acción de "Eliminar" es 3
            Ver = 4     // Valor de enum para la acción de "Ver" es 4
        }
    }
}
