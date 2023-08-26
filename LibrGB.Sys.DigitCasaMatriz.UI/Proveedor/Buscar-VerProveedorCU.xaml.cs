using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
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
            _MantenimientoProveedor AgregFormulario = new _MantenimientoCategoria(null, accion);

            // Se muestra el formulario recién creado.
            AgregFormulario.Show();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
