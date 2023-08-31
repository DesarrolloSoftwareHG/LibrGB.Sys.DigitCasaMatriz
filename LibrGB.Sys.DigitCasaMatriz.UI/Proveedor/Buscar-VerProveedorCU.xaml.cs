using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;
using LibrGB.Sys.DigitCasaMatriz.UI.Categoria;
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

            ActualizarDataGrid();

        }

        public void ActualizarDataGrid()
        {
            dgvMostrar_Proveedor.ItemsSource = null;
            dgvMostrar_Proveedor.ItemsSource = ObjProveedorBL.ObtenerProveedor();

        }

        ProveedorBL ObjProveedorBL = new ProveedorBL();

        private bool proveedorFormAbierto = false;

        private void btnAgregarProveedor_Click_1(object sender, RoutedEventArgs e)
        {
            if (!proveedorFormAbierto)
            {
                proveedorFormAbierto = true;

                btnModificarProveedor.IsEnabled = false;
                btnEliminarProveedor.IsEnabled = false;
                btnVerProveedor.IsEnabled = false;

                var accion = (byte)AccionEnum.Crear;
                _MantenimientoProveedor AgregFormulario = new _MantenimientoProveedor(null, accion);

                AgregFormulario.Closed += (s, args) =>
                {
                    proveedorFormAbierto = false;
                    btnModificarProveedor.IsEnabled = true;
                    btnEliminarProveedor.IsEnabled = true;
                    btnVerProveedor.IsEnabled = true;
                };
                AgregFormulario.Show();
            }
            else
            {
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Proveedor Abiertas", "Alerta un Ventana en Ejecucion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnModificarProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (!proveedorFormAbierto)
            {
                if (dgvMostrar_Proveedor.SelectedItem != null)
                {
                    proveedorFormAbierto = true;

                    btnAgregarProveedor.IsEnabled = false;
                    btnEliminarProveedor.IsEnabled = false;
                    btnVerProveedor.IsEnabled = false;

                    ProveedorEN proveedorSeleccionado = (ProveedorEN)dgvMostrar_Proveedor.SelectedItem;
                    int idProveedor = proveedorSeleccionado.Id;

                    _MantenimientoProveedor ModifProveedor = new _MantenimientoProveedor(idProveedor);

                    ModifProveedor.Closed += (s, args) =>
                    {
                        proveedorFormAbierto = false;
                        btnAgregarProveedor.IsEnabled = true;
                        btnEliminarProveedor.IsEnabled = true;
                        btnVerProveedor.IsEnabled = true;
                    };
                    ModifProveedor.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Proveedor abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnEliminarProveedor_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (!proveedorFormAbierto)
            {

                if (dgvMostrar_Proveedor.SelectedItem != null)
                {
                    proveedorFormAbierto = true;

                    btnAgregarProveedor.IsEnabled = false;
                    btnModificarProveedor.IsEnabled = false;
                    btnVerProveedor.IsEnabled = false;

                    ProveedorEN proveedorSeleccionado = (ProveedorEN)dgvMostrar_Proveedor.SelectedItem;
                    int idProveedor = proveedorSeleccionado.Id;

                    _MantenimientoProveedor ElimProveedor = new _MantenimientoProveedor(idProveedor, pAccion);

                    ElimProveedor.Closed += (s, args) =>
                    {
                        proveedorFormAbierto = false;
                        btnAgregarProveedor.IsEnabled = true;
                        btnModificarProveedor.IsEnabled = true;
                        btnVerProveedor.IsEnabled = true;
                    };
                    ElimProveedor.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Categoría abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        private void btnVerProveedor_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Ver;

            if (!proveedorFormAbierto)
            {
                if (dgvMostrar_Proveedor.SelectedItem != null)
                {
                    proveedorFormAbierto = true;

                    btnAgregarProveedor.IsEnabled = false;
                    btnModificarProveedor.IsEnabled = false;
                    btnEliminarProveedor.IsEnabled = false;

                    ProveedorEN proveedorSeleccionado = (ProveedorEN)dgvMostrar_Proveedor.SelectedItem;
                    int idProveedor = proveedorSeleccionado.Id;

                    _MantenimientoProveedor VerProveedor = new _MantenimientoProveedor(idProveedor, pAccion);

                    VerProveedor.Closed += (s, args) =>
                    {
                        proveedorFormAbierto = false;
                        btnAgregarProveedor.IsEnabled = true;
                        btnModificarProveedor.IsEnabled = true;
                        btnEliminarProveedor.IsEnabled = true;
                    };
                    VerProveedor.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Proveedor abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBuscarProveedor_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();

            string nombre = txtBuscarProveedor.Text;

            if (!string.IsNullOrEmpty(nombre))
            {
                var proveedorBl = new ProveedorBL();

                var proveedores = proveedorBl.ObtenerProveedoresLike(nombre);

                dgvMostrar_Proveedor.ItemsSource = proveedores;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            var mantenimientoproveedorAbierta = Application.Current.Windows.OfType<_MantenimientoProveedor>().SingleOrDefault();

            if (mantenimientoproveedorAbierta != null)
            {
                mantenimientoproveedorAbierta.Close();
            }

            this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarProveedor_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
        }

    }
}
