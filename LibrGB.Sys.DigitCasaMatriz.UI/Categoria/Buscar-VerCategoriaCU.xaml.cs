using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using System;
using System.Collections.Generic;
using System.Data;
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

            ActualizarDataGrid();
            // Llamamos el Metodo ActualizarGrid para que se ejecute al nomas inicie el Control de Usuario
        }

        public void ActualizarDataGrid()
        {
            // Se establece la fuente de datos del DataGridView (dgvMostrar_Categorias) como nula para limpiar los datos actuales.
            dgvMostrar_Categorias.ItemsSource = null;

            // Se asigna la fuente de datos del DataGridView (dgvMostrar_Categorias) con la lista de categorías obtenidas a través de ObjCategoriaBL.ObtenerCategoria().
            dgvMostrar_Categorias.ItemsSource = ObjCategoriaBL.ObtenerCategoria();

        }

        CategoriaBL ObjCategoriaBL = new CategoriaBL();
        // Crea una instancia de la clase CategoriaBL y la asigna a la variable ObjCategoriaBL.

        private bool categoriaFormAbierto = false;

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (!categoriaFormAbierto)
            {
                categoriaFormAbierto = true;

                btnModificarCategoria.IsEnabled = false;
                btnEliminarCategoria.IsEnabled = false;
                btnVerCategoria.IsEnabled = false;

                var accion = (byte)AccionEnum.Crear;
                _MantenimientoCategoria AgregFormulario = new _MantenimientoCategoria(null, accion);

                AgregFormulario.Closed += (s, args) =>
                {
                    categoriaFormAbierto = false; // Actualizar el estado cuando se cierre la ventana
                    btnModificarCategoria.IsEnabled = true; // Restaurar el estado de los botones
                    btnEliminarCategoria.IsEnabled = true;
                    btnVerCategoria.IsEnabled = true;
                };

                AgregFormulario.Show();
            }
            else
            {
                MessageBox.Show("No puedes Tener 2 Ventanas de Mantenimiento Categoria Abiertas", "Alerta un Ventana en Ejecucion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void btnModificarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (!categoriaFormAbierto)
            {
                if (dgvMostrar_Categorias.SelectedItem != null)
                {
                    categoriaFormAbierto = true;

                    // Deshabilitar otros botones mientras se modifica una categoría
                    btnAgregarCategoria.IsEnabled = false;
                    btnEliminarCategoria.IsEnabled = false;
                    btnVerCategoria.IsEnabled = false;

                    CategoriaEN categoriaSeleccionada = (CategoriaEN)dgvMostrar_Categorias.SelectedItem;
                    int idCategoria = categoriaSeleccionada.Id;

                    _MantenimientoCategoria ModifCategoria = new _MantenimientoCategoria(idCategoria);

                    ModifCategoria.Closed += (s, args) =>
                    {
                        categoriaFormAbierto = false; // Actualizar el estado cuando se cierre la ventana
                        btnAgregarCategoria.IsEnabled = true; // Restaurar el estado de los botones
                        btnEliminarCategoria.IsEnabled = true;
                        btnVerCategoria.IsEnabled = true;
                    };

                    ModifCategoria.Show();
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


        private void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (!categoriaFormAbierto)
            {
                if (dgvMostrar_Categorias.SelectedItem != null)
                {
                    categoriaFormAbierto = true;

                    btnAgregarCategoria.IsEnabled = false;
                    btnModificarCategoria.IsEnabled = false;
                    btnVerCategoria.IsEnabled = false;

                    CategoriaEN categoriaSeleccionada = (CategoriaEN)dgvMostrar_Categorias.SelectedItem;
                    int idCategoria = categoriaSeleccionada.Id;

                    _MantenimientoCategoria ElimCategoria = new _MantenimientoCategoria(idCategoria, pAccion);

                    ElimCategoria.Closed += (s, args) =>
                    {
                        categoriaFormAbierto = false;
                        btnAgregarCategoria.IsEnabled = true;
                        btnModificarCategoria.IsEnabled = true;
                        btnVerCategoria.IsEnabled = true;
                    };

                    ElimCategoria.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Categoría abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnVerCategoria_Click(object sender, RoutedEventArgs e)
        {
            byte pAccion = (byte)AccionEnum.Ver;

            if (!categoriaFormAbierto)
            {
                if (dgvMostrar_Categorias.SelectedItem != null)
                {
                    categoriaFormAbierto = true;

                    btnAgregarCategoria.IsEnabled = false;
                    btnModificarCategoria.IsEnabled = false;
                    btnEliminarCategoria.IsEnabled = false;

                    CategoriaEN categoriaSeleccionada = (CategoriaEN)dgvMostrar_Categorias.SelectedItem;
                    int idCategoria = categoriaSeleccionada.Id;

                    _MantenimientoCategoria VerCategoria = new _MantenimientoCategoria(idCategoria, pAccion);

                    VerCategoria.Closed += (s, args) =>
                    {
                        categoriaFormAbierto = false;
                        btnAgregarCategoria.IsEnabled = true;
                        btnModificarCategoria.IsEnabled = true;
                        btnEliminarCategoria.IsEnabled = true;
                    };

                    VerCategoria.Show();
                }
                else
                {
                    MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                ActualizarDataGrid();
            }
            else
            {
                MessageBox.Show("No puedes tener 2 Ventanas de Mantenimiento Categoría abiertas al mismo tiempo", "Alerta de Ventana en Ejecución", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBuscarCategoria_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();

            string nombre = txtBuscarCategoria.Text;

            if (!string.IsNullOrEmpty(nombre))
            {
                var categoriaBl = new CategoriaBL();

                var categorias = categoriaBl.ObtenerCategoriasLike(nombre);

                dgvMostrar_Categorias.ItemsSource = categorias;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si hay una instancia de _MantenimientoCategoria abierta
            var mantenimientoCategoriaAbierta = Application.Current.Windows.OfType<_MantenimientoCategoria>().SingleOrDefault();

            if (mantenimientoCategoriaAbierta != null)
            {
                mantenimientoCategoriaAbierta.Close(); // Cerrar la ventana abierta
            }

            this.Visibility = Visibility.Collapsed; this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarCategoria_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
            //Llamamos el metodo ActualizarDataGrid para actualizar el DGV al precionarlo
        }
    }
}
