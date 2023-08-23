using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
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
        }

        CategoriaBL ObjCategoriaBL = new CategoriaBL();

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            // Se define la acción que se realizará, en este caso, se establece la acción como "Crear".
            var accion = (byte)AccionEnum.Crear;

            // Se crea una instancia del formulario _CategoriaAgregar pasando null como parámetro y la acción definida.
            _CategoriaAgregar VerFormulario = new _CategoriaAgregar(null, accion);

            // Se muestra el formulario recién creado.
            VerFormulario.Show();

        }

        public void ActualizarDataGrid()
        {
            dgvMostrar_Categorias.ItemsSource = null;

            dgvMostrar_Categorias.ItemsSource = ObjCategoriaBL.ObtenerCategoria();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
