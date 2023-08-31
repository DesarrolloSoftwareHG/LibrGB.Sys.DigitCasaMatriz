using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
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

namespace LibrGB.Sys.DigitCasaMatriz.UI.UnidaDeMedida
{
    /// <summary>
    /// Lógica de interacción para Buscar_VerUnidadDeMedidaCU.xaml
    /// </summary>
    public partial class Buscar_VerUnidadDeMedidaCU : UserControl
    {
        public Buscar_VerUnidadDeMedidaCU()
        {
            InitializeComponent();

            ActualizarDataGrid();

        }

        public void ActualizarDataGrid()
        {
            dgvMostrar_UDM.ItemsSource = null;
            dgvMostrar_UDM.ItemsSource = ObjUdmBL.ObtenerUDM();

        }

        UnidadDeMedidaBL ObjUdmBL = new UnidadDeMedidaBL();

        private bool UDMFormAbierto = false;

        private void btnAgregarUDM_Click(object sender, RoutedEventArgs e)
        {
            if (!UDMFormAbierto)
            {
                UDMFormAbierto = true;

                btnModificarUDM.IsEnabled = false;
                btnEliminarUDM.IsEnabled = false;
                btnVerUDM.IsEnabled = false;

                var accion = (byte)AccionEnum.Crear;
                _MantenimientoUnidadDeMedida AgregFormulario = new _MantenimientoUnidadDeMedida(null, accion);

                AgregFormulario.Closed += (s, args) =>
                {
                    UDMFormAbierto = false;
                    btnModificarUDM.IsEnabled = true;
                    btnEliminarUDM.IsEnabled = true;
                    btnVerUDM.IsEnabled = true;
                };
                AgregFormulario.Show();
            }
            else
            {
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Unidad de Medida Abiertas", "Alerta un Ventana en Ejecucion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnModificarUDM_Click(object sender, RoutedEventArgs e)
        {
            if (!UDMFormAbierto)
            {
                if (dgvMostrar_UDM.SelectedItem != null)
                {
                    UDMFormAbierto = true;

                    btnAgregarUDM.IsEnabled = false;
                    btnEliminarUDM.IsEnabled = false;
                    btnVerUDM.IsEnabled = false;

                    UnidadDeMedidaEN UDMSeleccionada = (UnidadDeMedidaEN)dgvMostrar_UDM.SelectedItem;
                    int idUDM = UDMSeleccionada.Id;

                    _MantenimientoUnidadDeMedida ModifUDM = new _MantenimientoUnidadDeMedida(idUDM);

                    ModifUDM.Closed += (s, args) =>
                    {
                        UDMFormAbierto = false;
                        btnAgregarUDM.IsEnabled = true;
                        btnEliminarUDM.IsEnabled = true;
                        btnVerUDM.IsEnabled = true;
                    };
                    ModifUDM.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Unidad de Medida abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnEliminarUDM_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (!UDMFormAbierto)
            {
                if (dgvMostrar_UDM.SelectedItem != null)
                {
                    UDMFormAbierto = true;

                    btnAgregarUDM.IsEnabled = false;
                    btnModificarUDM.IsEnabled = false;
                    btnVerUDM.IsEnabled = false;

                    UnidadDeMedidaEN UDMSeleccionada = (UnidadDeMedidaEN)dgvMostrar_UDM.SelectedItem;
                    int idUDM = UDMSeleccionada.Id;

                    _MantenimientoUnidadDeMedida ElimUDM = new _MantenimientoUnidadDeMedida(idUDM, pAccion);

                    ElimUDM.Closed += (s, args) =>
                    {
                        UDMFormAbierto = false;
                        btnAgregarUDM.IsEnabled = true;
                        btnModificarUDM.IsEnabled = true;
                        btnVerUDM.IsEnabled = true;
                    };
                    ElimUDM.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Unidad de Medida abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnVerUDM_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Ver;

            if (!UDMFormAbierto)
            {
                if (dgvMostrar_UDM.SelectedItem != null)
                {
                    UDMFormAbierto = true;

                    btnAgregarUDM.IsEnabled = false;
                    btnModificarUDM.IsEnabled = false;
                    btnEliminarUDM.IsEnabled = false;

                    UnidadDeMedidaEN UDMSeleccionada = (UnidadDeMedidaEN)dgvMostrar_UDM.SelectedItem;
                    int idUDM = UDMSeleccionada.Id;

                    _MantenimientoUnidadDeMedida VerUDM = new _MantenimientoUnidadDeMedida(idUDM, pAccion);

                    VerUDM.Closed += (s, args) =>
                    {
                        UDMFormAbierto = false;
                        btnAgregarUDM.IsEnabled = true;
                        btnModificarUDM.IsEnabled = true;
                        btnEliminarUDM.IsEnabled = true;
                    };
                    VerUDM.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Unidad de Medida abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBuscarUDM_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();

            string nombre = txtBuscarUDM.Text;

            if (!string.IsNullOrEmpty(nombre))
            {
                var UDMBl = new UnidadDeMedidaBL();

                var UDM = UDMBl.ObtenerUDMLike(nombre);

                dgvMostrar_UDM.ItemsSource = UDM;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            var mantenimientoUDMAbierta = Application.Current.Windows.OfType<_MantenimientoUnidadDeMedida>().SingleOrDefault();

            if (mantenimientoUDMAbierta != null)
            {
                mantenimientoUDMAbierta.Close();
            }

            this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarUDM_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
        }
    }
}
