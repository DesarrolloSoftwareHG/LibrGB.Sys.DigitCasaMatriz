using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static LibrGB.Sys.DigitCasaMatriz.EN.Acciones;

namespace LibrGB.Sys.DigitCasaMatriz.UI.Categoria
{
    /// <summary>
    /// Lógica de interacción para Buscar_VerCategoriaCU.xaml
    /// </summary>
    public partial class Buscar_VerCategoriaCU : UserControl
    {
        public Buscar_VerCategoriaCU()
        {
            InitializeComponent();
        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            var accion = (byte)AccionEnum.Crear;
            _CategoriaAgregar VerFormulario = new _CategoriaAgregar(null,accion);
            VerFormulario.Show();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
