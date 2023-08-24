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
            // Llamamos el Metodo ActualizarGrid para que se ejecute al nomas inicie el Control de Usuario
        }

        public void ActualizarDataGrid()
        {
            // Se establece la fuente de datos del DataGridView (dgvMostrar_UDM) como nula para limpiar los datos actuales.
            dgvMostrar_UDM.ItemsSource = null;

            // Se asigna la fuente de datos del DataGridView (dgvMostrar_UDM) con la lista de UDM obtenidas a través de ObjUdmBL.ObtenerUnidadDeMedida().
            dgvMostrar_UDM.ItemsSource = ObjUdmBL.ObtenerUDM();

        }

        UnidadDeMedidaBL ObjUdmBL = new UnidadDeMedidaBL();
        // Crea una instancia de la clase UnidadDeMedidaBL y la asigna a la variable ObjUdmBL.

        private void btnAgregarUDM_Click(object sender, RoutedEventArgs e)
        {
            // Se define la acción que se realizará, en este caso, se establece la acción como "Crear".
            var accion = (byte)AccionEnum.Crear;

            // Se crea una instancia del formulario _AgregarUnidadDeMedida pasando null como parámetro y la acción definida.
            _AgregarUnidadDeMedida AgregFormulario = new _AgregarUnidadDeMedida(null, accion);

            // Se muestra el formulario recién creado.
            AgregFormulario.Show();
        }

        private void btnModificarUDM_Click(object sender, RoutedEventArgs e)
        {
            if (dgvMostrar_UDM.SelectedItem != null)
            {
                // Si hay una fila seleccionada en el DataGridView (dgvMostrar_UDM), continúa con el proceso de modificación.

                // Obtener la UDM seleccionada del enlace de datos del DataGridView.
                UnidadDeMedidaEN UDMSeleccionada = (UnidadDeMedidaEN)dgvMostrar_UDM.SelectedItem;

                // Obtener el ID de la UDM seleccionada.
                int idUDM = UDMSeleccionada.Id;

                // Crear una nueva instancia del formulario de modificación de UDM (_AgregarUnidadDeMedida) y pasar el ID de la UDM seleccionada.
                _AgregarUnidadDeMedida ModifUDM = new _AgregarUnidadDeMedida(idUDM);

                // Mostrar el formulario de modificación de UDM.
                ModifUDM.Show();
            }
            else
            {
                // Si no hay ninguna fila seleccionada en el DataGridView, mostrar un mensaje de error.
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnEliminarUDM_Click(object sender, RoutedEventArgs e)
        {
            // Definir el valor de la acción como byte usando el enumerado AccionEnum
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (dgvMostrar_UDM.SelectedItem != null)
            {
                // Obtener el objeto seleccionado del DataGrid (cambia "UDM" por el tipo correcto)
                UnidadDeMedidaEN UDMSeleccionada = (UnidadDeMedidaEN)dgvMostrar_UDM.SelectedItem;

                // Obtener el valor de Id del objeto seleccionado (ajusta esto según la estructura de tus objetos)
                int idUDM = UDMSeleccionada.Id;

                // Crear una instancia de _AgregarUnidadDeMedida y pasar el Id y la acción
                _AgregarUnidadDeMedida ElimUDM = new _AgregarUnidadDeMedida(idUDM, pAccion);

                // Mostrar la ventana _AgregarUnidadDeMedida
                ElimUDM.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnVerUDM_Click(object sender, RoutedEventArgs e)
        {
            // Definir el valor de la acción como byte usando el enumerado AccionEnum
            byte pAccion = (byte)AccionEnum.Ver;

            if (dgvMostrar_UDM.SelectedItem != null)
            {
                // Obtener el objeto seleccionado del DataGrid (cambia "UDM" por el tipo correcto)
                UnidadDeMedidaEN UDMSeleccionada = (UnidadDeMedidaEN)dgvMostrar_UDM.SelectedItem;

                // Obtener el valor de Id del objeto seleccionado (ajusta esto según la estructura de tus objetos)
                int idUDM = UDMSeleccionada.Id;

                // Crear una instancia de _CategoriaAgregar y pasar el Id y la acción
                _AgregarUnidadDeMedida VerCategoria = new _AgregarUnidadDeMedida(idUDM, pAccion);

                // Mostrar la ventana _CategoriaAgregar
                VerCategoria.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
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
            this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarUDM_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
            //Llamamos el metodo ActualizarDataGrid para actualizar el DGV al precionarlo
        }
    }
}
