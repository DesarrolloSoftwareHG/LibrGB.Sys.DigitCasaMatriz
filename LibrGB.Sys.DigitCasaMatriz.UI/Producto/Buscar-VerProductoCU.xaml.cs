using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Producto;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using LibrGB.Sys.DigitCasaMatriz.UI.UnidaDeMedida;
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

namespace LibrGB.Sys.DigitCasaMatriz.UI.Producto
{
    /// <summary>
    /// Lógica de interacción para Buscar_VerProductoCU.xaml
    /// </summary>
    public partial class Buscar_VerProductoCU : UserControl
    {
        public Buscar_VerProductoCU()
        {
            InitializeComponent();

            ActualizarDataGrid();
        }

        public void ActualizarDataGrid()
        {
            dgvMostrar_Producto.ItemsSource = null;

            dgvMostrar_Producto.ItemsSource = ObjProductoBL.ObtenerProducto();

        }

        ProductoBL ObjProductoBL = new ProductoBL();

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var accion = (byte)AccionEnum.Crear;

            _MantenimientoProducto AgregFormulario = new _MantenimientoProducto(null, accion);

            AgregFormulario.Show();
        }

        private void btnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dgvMostrar_Producto.SelectedItem != null)
            {
                ProductoEN ProductoSeleccionado = (ProductoEN)dgvMostrar_Producto.SelectedItem;

                int idProducto = ProductoSeleccionado.Id;

                _MantenimientoProducto ModiFormulario = new _MantenimientoProducto(idProducto);

                // Mostrar el formulario de modificación de UDM.
                ModiFormulario.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (dgvMostrar_Producto.SelectedItem != null)
            {
                ProductoEN ProductoSeleccionado = (ProductoEN)dgvMostrar_Producto.SelectedItem;

                int idProducto = ProductoSeleccionado.Id;

                _MantenimientoProducto ElimFormulario = new _MantenimientoProducto(idProducto, pAccion);

                ElimFormulario.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnVerProducto_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Ver;

            if (dgvMostrar_Producto.SelectedItem != null)
            {
                ProductoEN ProductoSeleccionado = (ProductoEN)dgvMostrar_Producto.SelectedItem;

                int idProducto = ProductoSeleccionado.Id;

                _MantenimientoProducto VerProducto = new _MantenimientoProducto(idProducto, pAccion);

                VerProducto.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnBuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();

            string codigo = txtBuscarProducto.Text;

            if (!string.IsNullOrEmpty(codigo))
            {
                var ProductoBl = new ProductoBL();

                var Producto = ProductoBl.ObtenerProductoLike(codigo);

                dgvMostrar_Producto.ItemsSource = Producto;
            }
        }


        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarProducto_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
        }
    }
}
