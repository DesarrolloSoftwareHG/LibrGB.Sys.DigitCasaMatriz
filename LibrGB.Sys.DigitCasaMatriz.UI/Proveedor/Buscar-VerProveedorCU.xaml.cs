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
            // Llamamos el Metodo ActualizarGrid para que se ejecute al nomas inicie el Control de Usuario
        }

        public void ActualizarDataGrid()
        {
            // Se establece la fuente de datos del DataGridView (dgvMostrar_Categorias) como nula para limpiar los datos actuales.
            dgvMostrar_Proveedor.ItemsSource = null;

            // Se asigna la fuente de datos del DataGridView (dgvMostrar_Categorias) con la lista de categorías obtenidas a través de ObjCategoriaBL.ObtenerCategoria().
            dgvMostrar_Proveedor.ItemsSource = ObjProveedorBL.ObtenerProveedor();

        }

        ProveedorBL ObjProveedorBL = new ProveedorBL();
        // Crea una instancia de la clase CategoriaBL y la asigna a la variable ObjCategoriaBL.

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            // Se define la acción que se realizará, en este caso, se establece la acción como "Crear".
            var accion = (byte)AccionEnum.Crear;

            // Se crea una instancia del formulario _CategoriaAgregar pasando null como parámetro y la acción definida.
            _MantenimientoProveedor AgregFormulario = new _MantenimientoProveedor(null, accion);

            // Se muestra el formulario recién creado.
            AgregFormulario.Show();
        }

        private void btnModificarProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (dgvMostrar_Proveedor.SelectedItem != null)
            {
                // Si hay una fila seleccionada en el DataGridView (dgvMostrar_Categorias), continúa con el proceso de modificación.

                // Obtener la categoría seleccionada del enlace de datos del DataGridView.
                ProveedorEN proveedorSeleccionado = (ProveedorEN)dgvMostrar_Proveedor.SelectedItem;

                // Obtener el ID de la categoría seleccionada.
                int idProveedor = proveedorSeleccionado.Id;

                // Crear una nueva instancia del formulario de modificación de categoría (_CategoriaAgregar) y pasar el ID de la categoría seleccionada.
                _MantenimientoProveedor ModifProveedor = new _MantenimientoProveedor(idProveedor);

                // Mostrar el formulario de modificación de categoría.
                ModifProveedor.Show();
            }
            else
            {
                // Si no hay ninguna fila seleccionada en el DataGridView, mostrar un mensaje de error.
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnEliminarProveedor_Click(object sender, RoutedEventArgs e)
        {
            // Definir el valor de la acción como byte usando el enumerado AccionEnum
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (dgvMostrar_Proveedor.SelectedItem != null)
            {
                // Obtener el objeto seleccionado del DataGrid (cambia "Categoria" por el tipo correcto)
                ProveedorEN proveedorSeleccionado = (ProveedorEN)dgvMostrar_Proveedor.SelectedItem;

                // Obtener el valor de Id del objeto seleccionado (ajusta esto según la estructura de tus objetos)
                int idProveedor = proveedorSeleccionado.Id;

                // Crear una instancia de _CategoriaAgregar y pasar el Id y la acción
                _MantenimientoProveedor ElimProveedor = new _MantenimientoProveedor(idProveedor, pAccion);

                // Mostrar la ventana _CategoriaAgregar
                ElimProveedor.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnVerProveedor_Click(object sender, RoutedEventArgs e)
        {
            // Definir el valor de la acción como byte usando el enumerado AccionEnum
            byte pAccion = (byte)AccionEnum.Ver;

            if (dgvMostrar_Proveedor.SelectedItem != null)
            {
                // Obtener el objeto seleccionado del DataGrid (cambia "Categoria" por el tipo correcto)
                ProveedorEN proveedorSeleccionado = (ProveedorEN)dgvMostrar_Proveedor.SelectedItem;

                // Obtener el valor de Id del objeto seleccionado (ajusta esto según la estructura de tus objetos)
                int idProveedor = proveedorSeleccionado.Id;

                // Crear una instancia de _CategoriaAgregar y pasar el Id y la acción
                _MantenimientoProveedor VerProveedor = new _MantenimientoProveedor(idProveedor, pAccion);

                // Mostrar la ventana _CategoriaAgregar
                VerProveedor.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
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
            this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarProveedor_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
            //Llamamos el metodo ActualizarDataGrid para actualizar el DGV al precionarlo
        }
    }
}
