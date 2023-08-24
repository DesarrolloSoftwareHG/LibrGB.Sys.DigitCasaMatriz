using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using static LibrGB.Sys.DigitCasaMatriz.EN.Acciones;

namespace LibrGB.Sys.DigitCasaMatriz.UI.Categoria
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoCategoria.xaml
    /// </summary>
    public partial class _MantenimientoCategoria : MetroWindow
    {
        public _MantenimientoCategoria(int? pId = null, byte? pAccion = null)
        {
            InitializeComponent();

            ActualizarDataGrid();
            // Llamamos al Metedo para actualizar el DataGrid

            if (pId != null)
            {
                SetCategoria(pId, pAccion);
                // Llama al método SetCategoria para establecer la categoría según el pId y pAccion proporcionados.
            }

            if (pAccion == (byte)AccionEnum.Crear)
            {
                // Si la acción es "Crear" (AccionEnum.Crear), se realiza lo siguiente:

                // Se limpian los campos de entrada de texto y selección.
                txtNombreCategoria.Text = ""; // Limpia el campo de nombre de categoría.
                txtCodigoCategoria.Text = ""; // Limpia el campo de código de categoría.
                txtDescripcionCategoria.Text = ""; // Limpia el campo de descripción de categoría.

                // Se establece la fecha de creación y modificación a la fecha y hora actual.
                dtFechaCreacion.SelectedDate = DateTime.Now; // Establece la fecha de creación actual.
                dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaCreacion.IsEnabled = false;

                dtFechaModificacion.SelectedDate = DateTime.Now; // Establece la fecha de modificación actual.
                dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaModificacion.IsEnabled = false;

                // Se ocultan los botones de eliminar y modificar categoría.
                btnEliminarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de eliminar categoría.
                btnModificarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de modificar categoría.
            }
        }


        public void SetCategoria(int? pId, byte? pAccion)
        {
            var categoriaBl = new CategoriaBL();
            // Se crea una instancia del objeto CategoriaBL y se asigna a la variable categoriaBl.

            var categoria = categoriaBl.ObtenerPorId(pId);
            //Obtener la categoria por Id

            if (categoria != null)
            {
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    // Si la acción es "Eliminar" (AccionEnum.Ver), se realiza lo siguiente:

                    // Se establece el contenido de la etiqueta de título a "Visualizacion Categoria".
                    lblNameForm.Content = "Visualizacion Categoria";

                    // Se muestra el identificador de la categoría en el campo de texto.
                    txtIdCategoria.Text = Convert.ToString(categoria.Id);

                    // Se establece el nombre de la categoría en el campo de texto y se deshabilita la edición.
                    txtNombreCategoria.Text = categoria.Nombre;
                    txtNombreCategoria.IsEnabled = false;

                    // Se establece el código de la categoría en el campo de texto y se deshabilita la edición.
                    txtCodigoCategoria.Text = categoria.Codigo;
                    txtCodigoCategoria.IsEnabled = false;

                    // Se establece la descripción de la categoría en el campo de texto y se deshabilita la edición.
                    txtDescripcionCategoria.Text = categoria.Descripcion;
                    txtDescripcionCategoria.IsEnabled = false;

                    // Se establecen las fechas de creación y modificación en los campos de fecha.
                    dtFechaCreacion.SelectedDate = categoria.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = categoria.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se ocultan los botones de agregar y modificar categoría.
                    btnAgregarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de agregar categoría.
                    btnModificarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de modificar categoría.
                    btnEliminarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de Eliminar categoría.
                }
                else if (pAccion == (byte)AccionEnum.Eliminar)
                {
                    // Si la acción es "Eliminar" (AccionEnum.Eliminar), se realiza lo siguiente:

                    // Se establece el contenido de la etiqueta de título a "Eliminar Categoria".
                    lblNameForm.Content = "Eliminar Categoria";

                    // Se muestra el identificador de la categoría en el campo de texto.
                    txtIdCategoria.Text = Convert.ToString(categoria.Id);

                    // Se establece el nombre de la categoría en el campo de texto y se deshabilita la edición.
                    txtNombreCategoria.Text = categoria.Nombre;
                    txtNombreCategoria.IsEnabled = false;

                    // Se establece el código de la categoría en el campo de texto y se deshabilita la edición.
                    txtCodigoCategoria.Text = categoria.Codigo;
                    txtCodigoCategoria.IsEnabled = false;

                    // Se establece la descripción de la categoría en el campo de texto y se deshabilita la edición.
                    txtDescripcionCategoria.Text = categoria.Descripcion;
                    txtDescripcionCategoria.IsEnabled = false;

                    // Se establecen las fechas de creación y modificación en los campos de fecha.
                    dtFechaCreacion.SelectedDate = categoria.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = categoria.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se ocultan los botones de agregar y modificar categoría.
                    btnAgregarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de agregar categoría.
                    btnModificarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de modificar categoría.
                }
                else
                {
                    // En caso contrario (acción de Modificación), se realiza lo siguiente:

                    // Se establece el contenido de la etiqueta de título a "Modificar Categoria".
                    lblNameForm.Content = "Modificar Categoria";

                    // Se muestra el identificador de la categoría en el campo de texto.
                    txtIdCategoria.Text = Convert.ToString(categoria.Id);

                    // Se establece el nombre de la categoría en el campo de texto.
                    txtNombreCategoria.Text = categoria.Nombre;

                    // Se establece el código de la categoría en el campo de texto.
                    txtCodigoCategoria.Text = categoria.Codigo;

                    // Se establece la fecha de creación en el campo de fecha.
                    dtFechaCreacion.SelectedDate = categoria.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se establece la fecha de modificación en el campo de fecha.
                    dtFechaModificacion.SelectedDate = DateTime.Now;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se establece la descripción de la categoría en el campo de texto.
                    txtDescripcionCategoria.Text = categoria.Descripcion;

                    // Se ocultan los botones de agregar y eliminar categoría.
                    btnAgregarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de agregar categoría.
                    btnEliminarCategoria.Visibility = Visibility.Collapsed; // Oculta el botón de eliminar categoría.
                }

            }
        }


        CategoriaBL ObjCategoriaBL = new CategoriaBL();
        // Crea una instancia de la clase CategoriaBL y la asigna a la variable ObjCategoriaBL.
        // CategoriaBL es una clase que se encarga de la lógica de negocio relacionada con las categorías.

        Buscar_VerCategoriaCU formCategoria = new Buscar_VerCategoriaCU();
        // Crea una instancia del formulario Buscar_VerCategoriaCU y la asigna a la variable formCategoria.
        // _Categorias es el nombre del formulario que se está instanciando.

        public void ActualizarDataGrid()
        {
            // Se establece la fuente de datos del control DataGrid en la vista formCategoria a null para limpiar los datos actuales.
            formCategoria.dgvMostrar_Categorias.ItemsSource = null;

            // Se establece la fuente de datos del control DataGrid en la vista formCategoria con la lista de categorías obtenida desde ObjCategoriaBL.ObtenerCategoria().
            formCategoria.dgvMostrar_Categorias.ItemsSource = ObjCategoriaBL.ObtenerCategoria();

        }

        private void btnAgregarCategoria_Click(object sender, RoutedEventArgs e)
        {
            var ObjCategoria = new CategoriaEN
            {
                Nombre = txtNombreCategoria.Text,
                Codigo = txtCodigoCategoria.Text,
                Descripcion = txtDescripcionCategoria.Text,
                FechaCreacion = DateTime.Now,
            };

            if (ObjCategoria.Nombre != "" && ObjCategoria.Codigo != "" && ObjCategoria.Descripcion != "")
            {
                // Se verifica si el campo 'Nombre' en ObjCategoria contiene números utilizando una expresión regular.
                if (Regex.IsMatch(ObjCategoria.Nombre, @"\d"))
                {
                    // Si se encuentra algún número en el campo 'Nombre', se muestra un mensaje de error al usuario.
                    MessageBox.Show("El campo 'Nombre' no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    // Se establece el enfoque en el cuadro de texto txtNombreCategoria para que el usuario pueda corregir el error.
                    txtNombreCategoria.Focus();


                    // Se detiene la ejecución del código actual.
                    return;
                }

                // Se verifica si el campo 'Código' en ObjCategoria contiene letras utilizando una expresión regular.
                if (Regex.IsMatch(ObjCategoria.Codigo, "[a-zA-Z]"))
                {
                    // Si se encuentra alguna letra en el campo 'Código', se muestra un mensaje de error al usuario.
                    MessageBox.Show("El campo 'Código' no debe contener letras", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    // Se establece el enfoque en el cuadro de texto txtCodigoCategoria para que el usuario pueda corregir el error.
                    txtCodigoCategoria.Focus();

                    // Se detiene la ejecución del código actual.
                    return;
                }

                // Se verifica si la longitud del campo 'Código' en ObjCategoria no es igual a 10 o si contiene algún caracter que no sea un dígito.
                if (ObjCategoria.Codigo.Length != 10 || !ObjCategoria.Codigo.All(char.IsDigit))
                {
                    // Si la condición se cumple, se muestra un mensaje de error al usuario.
                    MessageBox.Show("El campo 'Código' debe contener exactamente 10 dígitos", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    // Se establece el enfoque en el cuadro de texto txtCodigoCategoria para que el usuario pueda corregir el error.
                    txtCodigoCategoria.Focus();

                    // Se hace visible el control lblNameForm, que parece estar relacionado con la validación.
                    lblNameForm.Visibility = Visibility.Visible;

                    // Se detiene la ejecución del código actual.
                    return;
                }

                var ObjCategoriaBL = new CategoriaBL();
                // Se crea una instancia del objeto 'CategoriaBL' y se asigna a la variable 'ObjCategoriaBL'

                var result = ObjCategoriaBL.GuardarCategoria(ObjCategoria);
                // Se llama al método 'GuardarCategoria' del objeto 'ObjCategoriaBL', pasando el objeto 'ObjCategoria' como argumento para guardar la categoría

                // Se verifica si el resultado de la operación es igual a 0, lo que podría indicar que el código de categoría ya existe en la base de datos.
                if (result == 0)
                {
                    // Si la condición se cumple, se muestra un mensaje de error al usuario.
                    MessageBox.Show("Código de Categoría ya existe", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    // Se establece el enfoque en el cuadro de texto txtCodigoCategoria para que el usuario pueda corregir el error.
                    txtCodigoCategoria.Focus();
                    lblAlert.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    // Si la condición no se cumple, se muestra un mensaje de éxito al usuario.
                    MessageBox.Show("Categoría agregada con éxito", "Guardado Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Se llama al método ActualizarDataGrid() para actualizar los datos en la cuadrícula.
                    ActualizarDataGrid();

                    // Se cierra la ventana actual.
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Uno o más campos están vacíos", "Valores Vacíos Detectados", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                // Se muestra un mensaje indicando que uno o más campos están vacíos si alguna de las propiedades del objeto 'ObjCategoria' está vacía

                ActualizarDataGrid();
                // Se llama a la función 'ActualizarDataGrid' para actualizar los datos en la cuadrícula

                return;
                // Se cierra la ventana actual
            }
        }

        private void btnModificarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CategoriaModificar = new CategoriaEN
                {
                    Id = Convert.ToInt32(txtIdCategoria.Text),
                    Nombre = txtNombreCategoria.Text,
                    Codigo = txtCodigoCategoria.Text,
                    Descripcion = txtDescripcionCategoria.Text,
                    FechaModificacion = DateTime.Now
                };

                if (CategoriaModificar != null)
                {
                    var pCategoriaBL = new CategoriaBL();

                    pCategoriaBL.ModificarCategoria(CategoriaModificar);

                    var pCategoriaActulizada = pCategoriaBL.ObtenerCategoria();

                    formCategoria.dgvMostrar_Categorias.ItemsSource = null;

                    formCategoria.dgvMostrar_Categorias.ItemsSource = pCategoriaActulizada;

                    MessageBox.Show("Categoria Modificada Con Exito", "Modificacion Categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    ActualizarDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado en: " + ex);
            }
            Close();
        }

        private void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            var EliminarCategoria = new CategoriaEN
            {
                Id = int.Parse(txtIdCategoria.Text)
            };

            if (EliminarCategoria != null)
            {
                var pCategoria = new CategoriaBL();

                pCategoria.EliminarCategoria(EliminarCategoria);

                var CategoriaActualizada = pCategoria.ObtenerCategoria();

                formCategoria.dgvMostrar_Categorias.ItemsSource = null;

                formCategoria.dgvMostrar_Categorias.ItemsSource = CategoriaActualizada;

                MessageBox.Show("Categoria Eliminada Con Exito", "Eliminar Categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            Close();
        }
    }
}
