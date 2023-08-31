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

            CargarComboEstatus();

            if (pId != null)
            {
                SetUnidadDeMedida(pId, pAccion);
            }

            if (pAccion == (byte)AccionEnum.Crear)
            {
                txtNombreUDM.Text = "";
                cbxEstatusUDM.SelectedItem = cbxEstatusUDM.Items[0];
                txtDescripcionUDM.Text = "";

                dtFechaCreacion.SelectedDate = DateTime.Now;
                dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaCreacion.IsEnabled = false;

                dtFechaModificacion.SelectedDate = DateTime.Now;
                dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaModificacion.IsEnabled = false;

                btnEliminarUDM.Visibility = Visibility.Collapsed;
                btnModificarUDM.Visibility = Visibility.Collapsed;
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

            var UDM = UdmBl.ObtenerPorId(pId);

            if (UDM != null)
            {
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    lblNameForm.Content = "Visualizacion Unidad De Medida";

                    txtIdUDM.Text = Convert.ToString(UDM.Id);

                    txtNombreUDM.Text = UDM.UDM;
                    txtNombreUDM.IsEnabled = false;

                    cbxEstatusUDM.SelectedValue = UDM.Estatus.Id;
                    cbxEstatusUDM.DisplayMemberPath = "Nombre";
                    cbxEstatusUDM.SelectedValuePath = "Id";
                    cbxEstatusUDM.IsEnabled = false;

                    txtDescripcionUDM.Text = UDM.Descripcion;
                    txtDescripcionUDM.IsEnabled = false;

                    dtFechaCreacion.SelectedDate = UDM.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = UDM.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    btnAgregarUDM.Visibility = Visibility.Collapsed;
                    btnModificarUDM.Visibility = Visibility.Collapsed;
                    btnEliminarUDM.Visibility = Visibility.Collapsed;
                }
                else if (pAccion == (byte)AccionEnum.Eliminar)
                {
                    lblNameForm.Content = "Eliminar Unidad De Medida";

                    txtIdUDM.Text = Convert.ToString(UDM.Id);

                    txtNombreUDM.Text = UDM.UDM;
                    txtNombreUDM.IsEnabled = false;

                    cbxEstatusUDM.SelectedValue = UDM.Estatus.Id;
                    cbxEstatusUDM.DisplayMemberPath = "Nombre";
                    cbxEstatusUDM.SelectedValuePath = "Id";
                    cbxEstatusUDM.IsEnabled = false;

                    txtDescripcionUDM.Text = UDM.Descripcion;
                    txtDescripcionUDM.IsEnabled = false;

                    dtFechaCreacion.SelectedDate = UDM.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = UDM.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    btnAgregarUDM.Visibility = Visibility.Collapsed;
                    btnModificarUDM.Visibility = Visibility.Collapsed;
                }
                else
                {
                    lblNameForm.Content = "Modificar Unidad De Medida";

                    txtIdUDM.Text = Convert.ToString(UDM.Id);

                    txtNombreUDM.Text = UDM.UDM;

                    cbxEstatusUDM.SelectedValue = UDM.Estatus.Id;
                    cbxEstatusUDM.DisplayMemberPath = "Nombre";
                    cbxEstatusUDM.SelectedValuePath = "Id";

                    txtDescripcionUDM.Text = UDM.Descripcion;

                    dtFechaCreacion.SelectedDate = UDM.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;

                    dtFechaModificacion.SelectedDate = DateTime.Now;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;

                    btnAgregarUDM.Visibility = Visibility.Collapsed;
                    btnEliminarUDM.Visibility = Visibility.Collapsed;
                }

            }
        }


        UnidadDeMedidaBL ObjUdmBL = new UnidadDeMedidaBL();

        Buscar_VerUnidadDeMedidaCU formUDM = new Buscar_VerUnidadDeMedidaCU();


        public void ActualizarDataGrid()
        {
            formUDM.dgvMostrar_UDM.ItemsSource = null;

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

                if (UdmModificar.UDM != "" && UdmModificar.Descripcion != "")
                {
                    // Se verifica si el campo 'UDM' en ObjUDM contiene números utilizando una expresión regular.
                    if (Regex.IsMatch(UdmModificar.UDM, @"\d"))
                    {
                        // Si se encuentra algún número en el campo 'UDM', se muestra un mensaje de error al usuario.
                        MessageBox.Show("El campo 'Unidad De Medida' no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        // Se establece el enfoque en el cuadro de texto txtNombreUDM para que el usuario pueda corregir el error.
                        txtNombreUDM.Focus();

                        // Se detiene la ejecución del código actual.
                        return;
                    }

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
