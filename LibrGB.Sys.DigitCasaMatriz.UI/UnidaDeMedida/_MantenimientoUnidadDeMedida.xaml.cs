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
using LibrGB.Sys.DigitCasaMatriz.BL;
using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using LibrGB.Sys.DigitCasaMatriz.UI.Categoria;
using MahApps.Metro.Controls;
using static LibrGB.Sys.DigitCasaMatriz.EN.Acciones;
using LibrGB.Sys.DigitCasaMatriz.EN;

namespace LibrGB.Sys.DigitCasaMatriz.UI.UnidaDeMedida
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoUnidadDeMedida.xaml
    /// </summary>
    public partial class _MantenimientoUnidadDeMedida : MetroWindow
    {
        public _MantenimientoUnidadDeMedida(int? pId = null, byte? pAccion = null)
        {
            InitializeComponent();

            ActualizarDataGrid();
            // Llamamos al Metedo para actualizar el DataGrid

            CargarComboEstatus();
            // Llamamos el metodo CargarComboEstatus para que se cargen los Estatus del Cbx

            if (pId != null)
            {
                SetUnidadDeMedida(pId, pAccion);
                // Llama al método SetUnidadDeMedida para establecer la UDM según el pId y pAccion proporcionados.
            }

            if (pAccion == (byte)AccionEnum.Crear)
            {
                // Si la acción es "Crear" (AccionEnum.Crear), se realiza lo siguiente:

                // Se limpian los campos de entrada de texto y selección.
                txtNombreUDM.Text = ""; // Limpia el campo de nombre de categoría.
                cbxEstatusUDM.SelectedItem = ""; // Limpia el campo de código de categoría.
                txtDescripcionUDM.Text = ""; // Limpia el campo de descripción de categoría.

                // Se establece la fecha de creación y modificación a la fecha y hora actual.
                dtFechaCreacion.SelectedDate = DateTime.Now; // Establece la fecha de creación actual.
                dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaCreacion.IsEnabled = false;

                dtFechaModificacion.SelectedDate = DateTime.Now; // Establece la fecha de modificación actual.
                dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaModificacion.IsEnabled = false;

                // Se ocultan los botones de eliminar y modificar UDM.
                btnEliminarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de eliminar UDM.
                btnModificarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de modificar UDM.
            }
        }

        private void CargarComboEstatus()
        {
            var estatusBl = new EstatusBL();
            var estatus = estatusBl.ObtenerEstatus();

            cbxEstatusUDM.ItemsSource = estatus;

            cbxEstatusUDM.DisplayMemberPath = "Nombre";
            cbxEstatusUDM.SelectedValuePath = "Id";
        }

        public void SetUnidadDeMedida(int? pId, byte? pAccion)
        {
            var UdmBl = new UnidadDeMedidaBL();
            // Se crea una instancia del objeto UnidadDeMedidaBL y se asigna a la variable UdmBl.

            var UDM = UdmBl.ObtenerPorId(pId);
            //Obtener la UDM por Id

            if (UDM != null)
            {
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    // Si la acción es "Eliminar" (AccionEnum.Ver), se realiza lo siguiente:

                    // Se establece el contenido de la etiqueta de título a "Visualizacion Unidad De Medida".
                    lblNameForm.Content = "Visualizacion Unidad De Medida";

                    // Se muestra el identificador de la UDM en el campo de texto.
                    txtIdUDM.Text = Convert.ToString(UDM.Id);

                    // Se establece el nombre de la UDM en el campo de texto y se deshabilita la edición.
                    txtNombreUDM.Text = UDM.UDM;
                    txtNombreUDM.IsEnabled = false;

                    // Se establece el Estatus de la UDM en el campo del cbx y se deshabilita la edición.
                    //cbxEstatusUDM.SelectedValue = UDM.Estatus;
                    cbxEstatusUDM.SelectedValue = UDM.Estatus.Id;
                    cbxEstatusUDM.DisplayMemberPath = "Nombre";
                    cbxEstatusUDM.SelectedValuePath = "Id";
                    cbxEstatusUDM.IsEnabled = false;

                    // Se establece la descripción de la UDM en el campo de texto y se deshabilita la edición.
                    txtDescripcionUDM.Text = UDM.Descripcion;
                    txtDescripcionUDM.IsEnabled = false;

                    // Se establecen las fechas de creación y modificación en los campos de fecha.
                    dtFechaCreacion.SelectedDate = UDM.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = UDM.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se ocultan los botones de agregar , modificar y ver UDM.
                    btnAgregarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de agregar categoría.
                    btnModificarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de modificar categoría.
                    btnEliminarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de Eliminar categoría.
                }
                else if (pAccion == (byte)AccionEnum.Eliminar)
                {
                    // Si la acción es "Eliminar" (AccionEnum.Eliminar), se realiza lo siguiente:

                    // Se establece el contenido de la etiqueta de título a "Eliminar Unidad De Medida".
                    lblNameForm.Content = "Eliminar Unidad De Medida";

                    // Se muestra el identificador de la UDM en el campo de texto.
                    txtIdUDM.Text = Convert.ToString(UDM.Id);

                    // Se establece el nombre de la UDM en el campo de texto y se deshabilita la edición.
                    txtNombreUDM.Text = UDM.UDM;
                    txtNombreUDM.IsEnabled = false;

                    // Se establece el Estatus de la UDM en el campo de texto y se deshabilita la edición.
                    cbxEstatusUDM.SelectedValue = UDM.Estatus.Id;
                    cbxEstatusUDM.DisplayMemberPath = "Nombre";
                    cbxEstatusUDM.SelectedValuePath = "Id";
                    cbxEstatusUDM.IsEnabled = false;

                    // Se establece la descripción de la UDM en el campo de texto y se deshabilita la edición.
                    txtDescripcionUDM.Text = UDM.Descripcion;
                    txtDescripcionUDM.IsEnabled = false;

                    // Se establecen las fechas de creación y modificación en los campos de fecha.
                    dtFechaCreacion.SelectedDate = UDM.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = UDM.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se ocultan los botones de agregar y modificar UDM.
                    btnAgregarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de agregar UDM.
                    btnModificarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de modificar UDM.
                }
                else
                {
                    // En caso contrario (acción de Modificación), se realiza lo siguiente:

                    // Se establece el contenido de la etiqueta de título a "Modificar Modificar Unidad De Medida".
                    lblNameForm.Content = "Modificar Unidad De Medida";

                    // Se muestra el identificador de la UDM en el campo de texto.
                    txtIdUDM.Text = Convert.ToString(UDM.Id);

                    // Se establece el nombre de la UDM en el campo de texto.
                    txtNombreUDM.Text = UDM.UDM;

                    // Se establece el Estatus de la UDM en el campo de texto.
                    cbxEstatusUDM.SelectedValue = UDM.Estatus.Id;
                    cbxEstatusUDM.DisplayMemberPath = "Nombre";
                    cbxEstatusUDM.SelectedValuePath = "Id";

                    // Se establece la descripción de la UDM en el campo de texto.
                    txtDescripcionUDM.Text = UDM.Descripcion;

                    // Se establece la fecha de creación en el campo de fecha.
                    dtFechaCreacion.SelectedDate = UDM.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se establece la fecha de modificación en el campo de fecha.
                    dtFechaModificacion.SelectedDate = DateTime.Now;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    // Se ocultan los botones de agregar y eliminar UDM.
                    btnAgregarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de agregar UDM.
                    btnEliminarUDM.Visibility = Visibility.Collapsed; // Oculta el botón de eliminar UDM.
                }

            }
        }


        UnidadDeMedidaBL ObjUdmBL = new UnidadDeMedidaBL();
        // Crea una instancia de la clase UnidadDeMedidaBL y la asigna a la variable ObjUdmBL.
        // UnidadDeMedidaBL es una clase que se encarga de la lógica de negocio relacionada con las UnidadDeMedida.

        Buscar_VerUnidadDeMedidaCU formUDM = new Buscar_VerUnidadDeMedidaCU();
        // Crea una instancia del formulario Buscar_VerUnidadDeMedidaCU y la asigna a la variable formUDM.
        // Buscar_VerUnidadDeMedidaCU es el nombre del formulario que se está instanciando.


        public void ActualizarDataGrid()
        {
            // Se establece la fuente de datos del control DataGrid en la vista formUDM a null para limpiar los datos actuales.
            formUDM.dgvMostrar_UDM.ItemsSource = null;

            // Se establece la fuente de datos del control DataGrid en la vista formUDM con la lista de UDM obtenida desde ObjUdmBL.ObtenerUDM().
            formUDM.dgvMostrar_UDM.ItemsSource = ObjUdmBL.ObtenerUDM();

        }

        private void btnAgregarUDM_Click(object sender, RoutedEventArgs e)
        {
            var ObjUDM = new UnidadDeMedidaEN
            {
                UDM = txtNombreUDM.Text,
                Estatus = new EstatusEN
                {
                    Id = Convert.ToInt32(cbxEstatusUDM.SelectedValue)
                },
                Descripcion = txtDescripcionUDM.Text,
                FechaCreacion = DateTime.Now,
            };

            if (ObjUDM.UDM != "" && ObjUDM.Descripcion != "")
            {
                // Se verifica si el campo 'UDM' en ObjUDM contiene números utilizando una expresión regular.
                if (Regex.IsMatch(ObjUDM.UDM, @"\d"))
                {
                    // Si se encuentra algún número en el campo 'UDM', se muestra un mensaje de error al usuario.
                    MessageBox.Show("El campo 'Unidad De Medida' no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    // Se establece el enfoque en el cuadro de texto txtNombreUDM para que el usuario pueda corregir el error.
                    txtNombreUDM.Focus();

                    // Se detiene la ejecución del código actual.
                    return;
                }

                var ObjUdmBL = new UnidadDeMedidaBL();
                // Se crea una instancia del objeto 'UnidadDeMedidaBL' y se asigna a la variable 'ObjUdmBL'

                var result = ObjUdmBL.GuardarUDM(ObjUDM);
                // Se llama al método 'GuardarUDM' del objeto 'ObjUdmBL', pasando el objeto 'ObjUDM' como argumento para guardar la UDM

                // Se verifica si el resultado de la operación es igual a 0, lo que podría indicar que el Nombre de UDM ya existe en la base de datos.
                if (result == 0)
                {
                    // Si la condición se cumple, se muestra un mensaje de error al usuario.
                    MessageBox.Show("Nombre de la Unidad De Medida ya existente", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    // Se establece el enfoque en el cuadro de texto txtNombreUDM para que el usuario pueda corregir el error.
                    txtNombreUDM.Focus();
                    lblAlerta.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    // Si la condición no se cumple, se muestra un mensaje de éxito al usuario.
                    MessageBox.Show("Unidad de Medida agregada con éxito", "Guardado Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Se llama al método ActualizarDataGrid() para actualizar los datos en la cuadrícula.
                    ActualizarDataGrid();

                    // Se cierra la ventana actual.
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Uno o más campos están vacíos", "Valores Vacíos Detectados", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                // Se muestra un mensaje indicando que uno o más campos están vacíos si alguna de las propiedades del objeto 'ObjUDM' está vacía

                ActualizarDataGrid();
                // Se llama a la función 'ActualizarDataGrid' para actualizar los datos en la cuadrícula

                return;
                // Se cierra la ventana actual
            }

        }

        private void btnModificarUDM_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var UdmModificar = new UnidadDeMedidaEN
                {
                    Id = Convert.ToInt32(txtIdUDM.Text),
                    UDM = txtNombreUDM.Text,
                    Estatus = new EstatusEN
                    {
                        Id = Convert.ToInt32(cbxEstatusUDM.SelectedValue)
                    },
                    Descripcion = txtDescripcionUDM.Text,
                    FechaModificacion = DateTime.Now
                };

                if (UdmModificar != null)
                {
                    var pUdnBL = new UnidadDeMedidaBL();

                    pUdnBL.ModificarUDM(UdmModificar);

                    var pUdmActulizada = pUdnBL.ObtenerUDM();

                    formUDM.dgvMostrar_UDM.ItemsSource = null;

                    formUDM.dgvMostrar_UDM.ItemsSource = pUdmActulizada;

                    MessageBox.Show("Unidad De Medida Modificada Con Exito", "Modificacion Unidad de Medida", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    ActualizarDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado en: " + ex);
            }
            Close();
        }

        private void btnEliminarUDM_Click(object sender, RoutedEventArgs e)
        {
            var EliminarUDM = new UnidadDeMedidaEN
            {
                Id = int.Parse(txtIdUDM.Text)
            };

            if (EliminarUDM != null)
            {
                var pUDM = new UnidadDeMedidaBL();

                pUDM.EliminarUDM(EliminarUDM);

                var UdmActualizada = pUDM.ObtenerUDM();

                formUDM.dgvMostrar_UDM.ItemsSource = null;

                formUDM.dgvMostrar_UDM.ItemsSource = UdmActualizada;

                MessageBox.Show("Unidad de Medida Eliminada Con Exito", "Eliminar Unidad De Medida", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            Close();
        }
    }
}
