using LibrGB.Sys.DigitCasaMatriz.UI.Categoria;
using LibrGB.Sys.DigitCasaMatriz.UI.Producto;
using LibrGB.Sys.DigitCasaMatriz.UI.Proveedor;
using LibrGB.Sys.DigitCasaMatriz.UI.UnidadDeMedida;
using MahApps.Metro.Controls;
using System.Windows;

namespace LibrGB.Sys.DigitCasaMatriz.UI.Menu_Principal___Admin
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal_Admin.xaml
    /// </summary>
    public partial class MenuPrincipal_Admin : MetroWindow
    {
        public MenuPrincipal_Admin()
        {
            InitializeComponent();
        }

        private void Producto_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerProducto());
        }

        private void Categoria_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerCategoria());
        }

        private void Proveedor_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerProveedor());
        }

        private void UnidadDeMedida_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerUnidadDeMedida());
        }
    }
}
