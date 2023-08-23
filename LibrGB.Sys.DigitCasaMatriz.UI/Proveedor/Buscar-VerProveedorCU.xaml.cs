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

namespace LibrGB.Sys.DigitCasaMatriz.UI.Proveedor
{
    /// <summary>
    /// Lógica de interacción para Buscar_VerProveedorCU.xaml
    /// </summary>
    public partial class Buscar_VerProveedorCU : UserControl
    {
        public Buscar_VerProveedorCU()
        {
            InitializeComponent();
        }

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            _ProveedorAgregar AgregarProveedor = new _ProveedorAgregar();
            AgregarProveedor.Show();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
