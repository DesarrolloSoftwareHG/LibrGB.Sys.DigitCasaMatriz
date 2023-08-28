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

        private bool productoFormAbierto = false;

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!productoFormAbierto)
            {
                productoFormAbierto = true;

                btnModificarProducto.IsEnabled = false;
                btnEliminarProducto.IsEnabled = false;
                btnVerProducto.IsEnabled = false;

                var accion = (byte)AccionEnum.Crear;
                _MantenimientoProducto AgregFormulario = new _MantenimientoProducto(null, accion);

                AgregFormulario.Closed += (s, args) =>
                {
                    productoFormAbierto = false; // Actualizar el estado cuando se cierre la ventana
                    btnModificarProducto.IsEnabled = true; // Restaurar el estado de los botones
                    btnEliminarProducto.IsEnabled = true;
                    btnVerProducto.IsEnabled = true;
                };
                AgregFormulario.Show();
            }
            else
            {
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Producto Abiertas", "Alerta un Ventana en Ejecucion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!productoFormAbierto)
            {
                if (dgvMostrar_Producto.SelectedItem != null)
                {
                    productoFormAbierto = true;

                    // Deshabilitar otros botones mientras se modifica una categoría
                    btnAgregarProducto.IsEnabled = false;
                    btnEliminarProducto.IsEnabled = false;
                    btnVerProducto.IsEnabled = false;

                    ProductoEN ProductoSeleccionado = (ProductoEN)dgvMostrar_Producto.SelectedItem;
                    int idProducto = ProductoSeleccionado.Id;

                    _MantenimientoProducto ModiFormulario = new _MantenimientoProducto(idProducto);

                    ModiFormulario.Closed += (s, args) =>
                    {
                        productoFormAbierto = false; // Actualizar el estado cuando se cierre la ventana
                        btnAgregarProducto.IsEnabled = true; // Restaurar el estado de los botones
                        btnEliminarProducto.IsEnabled = true;
                        btnVerProducto.IsEnabled = true;
                    };
                    ModiFormulario.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Categoría abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
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
