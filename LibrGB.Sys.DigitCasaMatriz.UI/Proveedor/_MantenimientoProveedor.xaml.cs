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
using System.Windows.Shapes;
using static LibrGB.Sys.DigitCasaMatriz.EN.Acciones;
using MahApps.Metro.Controls;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;
using System.Text.RegularExpressions;

namespace LibrGB.Sys.DigitCasaMatriz.UI.Proveedor
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoProveedor.xaml
    /// </summary>
    public partial class _MantenimientoProveedor : MetroWindow
    {
        public _MantenimientoProveedor(int? pId = null, byte? pAccion = null)
        {
            InitializeComponent();

            ActualizarDataGrid();

            if (pId != null)
            {
                SetProveedor(pId, pAccion);
            }

            if (pAccion == (byte)AccionEnum.Crear)
            {
                txtNombreProveedor.Text = "";
                txtDireccionProveedor.Text = "";
                txtNumeroTelefono.Text = "";
                txtNumeroCelular.Text = "";
                txtCorreoProveedor.Text = "";
                txtSitioWebProveedor.Text = "";
                txtDescripcionProveedor.Text = "";

                dtFechaCreacionProveedor.SelectedDate = DateTime.Now;
                dtFechaCreacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaCreacionProveedor.IsEnabled = false;

                dtFechaModificacionProveedor.SelectedDate = DateTime.Now;
                dtFechaModificacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaModificacionProveedor.IsEnabled = false;

                btnEliminarProveedor.Visibility = Visibility.Collapsed;
                btnModificarProveedor.Visibility = Visibility.Collapsed;
            }
        }

        public void SetProveedor(int? pId, byte? pAccion)
        {
            var proveedorBl = new ProveedorBL();

            var proveedor = proveedorBl.ObtenerPorId(pId);

            if (proveedor != null)
            {
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    lblNameForm.Content = "Visualizacion Proveedor";

                    txtIdProveedor.Text = Convert.ToString(proveedor.Id);

                    txtNombreProveedor.Text = proveedor.Nombre;
                    txtNombreProveedor.IsEnabled = false;

                    txtDireccionProveedor.Text = proveedor.Direccion;
                    txtDireccionProveedor.IsEnabled = false;

                    txtNumeroTelefono.Text = proveedor.NumeroTelefono;
                    txtNumeroTelefono.IsEnabled = false;

                    txtNumeroCelular.Text = proveedor.NumeroCelular;
                    txtNumeroCelular.IsEnabled = false;

                    txtCorreoProveedor.Text = proveedor.CorreoElectronico;
                    txtCorreoProveedor.IsEnabled = false;

                    txtSitioWebProveedor.Text = proveedor.SitioWeb;
                    txtSitioWebProveedor.IsEnabled = false;

                    txtDescripcionProveedor.Text = proveedor.Descripcion;
                    txtDescripcionProveedor.IsEnabled = false;

                    dtFechaCreacionProveedor.SelectedDate = proveedor.FechaCreacion;
                    dtFechaCreacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaCreacionProveedor.IsEnabled = false;

                    dtFechaModificacionProveedor.SelectedDate = proveedor.FechaModificacion;
                    dtFechaModificacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaModificacionProveedor.IsEnabled = false;

                    btnAgregarProveedor.Visibility = Visibility.Collapsed;
                    btnModificarProveedor.Visibility = Visibility.Collapsed;
                    btnEliminarProveedor.Visibility = Visibility.Collapsed;
                }
                else if (pAccion == (byte)AccionEnum.Eliminar)
                {
                    lblNameForm.Content = "Eliminar Proveedor";

                    txtIdProveedor.Text = Convert.ToString(proveedor.Id);

                    txtNombreProveedor.Text = proveedor.Nombre;
                    txtNombreProveedor.IsEnabled = false;

                    txtDireccionProveedor.Text = proveedor.Direccion;
                    txtDireccionProveedor.IsEnabled = false;

                    txtNumeroTelefono.Text = proveedor.NumeroTelefono;
                    txtNumeroTelefono.IsEnabled = false;

                    txtNumeroCelular.Text = proveedor.NumeroCelular;
                    txtNumeroCelular.IsEnabled = false;

                    txtCorreoProveedor.Text = proveedor.CorreoElectronico;
                    txtCorreoProveedor.IsEnabled = false;

                    txtSitioWebProveedor.Text = proveedor.SitioWeb;
                    txtSitioWebProveedor.IsEnabled = false;

                    txtDescripcionProveedor.Text = proveedor.Descripcion;
                    txtDescripcionProveedor.IsEnabled = false;

                    dtFechaCreacionProveedor.SelectedDate = proveedor.FechaCreacion;
                    dtFechaCreacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaCreacionProveedor.IsEnabled = false;

                    dtFechaModificacionProveedor.SelectedDate = proveedor.FechaModificacion;
                    dtFechaModificacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaModificacionProveedor.IsEnabled = false;

                    btnAgregarProveedor.Visibility = Visibility.Collapsed;
                    btnModificarProveedor.Visibility = Visibility.Collapsed;
                }
                else
                {
                    lblNameForm.Content = "Modificar Proveedor";

                    txtIdProveedor.Text = Convert.ToString(proveedor.Id);

                    txtNombreProveedor.Text = proveedor.Nombre;

                    txtDireccionProveedor.Text = proveedor.Direccion;

                    txtNumeroTelefono.Text = proveedor.NumeroTelefono;

                    txtNumeroCelular.Text = proveedor.NumeroCelular;

                    txtCorreoProveedor.Text = proveedor.CorreoElectronico;

                    txtSitioWebProveedor.Text = proveedor.SitioWeb;

                    txtDescripcionProveedor.Text = proveedor.Descripcion;

                    dtFechaCreacionProveedor.SelectedDate = proveedor.FechaCreacion;
                    dtFechaCreacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaCreacionProveedor.IsEnabled = false;

                    dtFechaModificacionProveedor.SelectedDate = DateTime.Now;
                    dtFechaModificacionProveedor.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaModificacionProveedor.IsEnabled = false;

                    btnAgregarProveedor.Visibility = Visibility.Collapsed;
                    btnEliminarProveedor.Visibility = Visibility.Collapsed;
                }

            }
        }


        ProveedorBL ObjProveedorBL = new ProveedorBL();

        Buscar_VerProveedorCU formProveedor = new Buscar_VerProveedorCU();


        public void ActualizarDataGrid()
        {
            formProveedor.dgvMostrar_Proveedor.ItemsSource = null;

            formProveedor.dgvMostrar_Proveedor.ItemsSource = ObjProveedorBL.ObtenerProveedor();

        }

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            var ObjProveedor = new ProveedorEN
            {
                Nombre = txtNombreProveedor.Text,
                Direccion = txtDireccionProveedor.Text,
                NumeroTelefono = txtNumeroTelefono.Text,
                NumeroCelular = txtNumeroCelular.Text,
                CorreoElectronico = txtCorreoProveedor.Text,
                SitioWeb = txtSitioWebProveedor.Text,
                Descripcion = txtDescripcionProveedor.Text,
                FechaCreacion = DateTime.Now,
            };

            if (ObjProveedor.Nombre != "" && ObjProveedor.Direccion != "" && ObjProveedor.NumeroTelefono != "" && ObjProveedor.CorreoElectronico !="" && ObjProveedor.Direccion != "")
            {
                if (Regex.IsMatch(ObjProveedor.Nombre, @"\d"))
                {
                    MessageBox.Show("El campo Nombre no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtNombreProveedor.Focus();

                    return;
                }

                if (Regex.IsMatch(ObjProveedor.NumeroTelefono, "[a-zA-Z]"))
                {
                    MessageBox.Show("El campo 'Número de Teléfono' no debe contener letras", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtNumeroTelefono.Focus();
                    return;
                }

                if (ObjProveedor.NumeroTelefono.Length != 8 || !ObjProveedor.NumeroTelefono.All(char.IsDigit))
                {
                    MessageBox.Show("El campo 'Número de Teléfono' debe contener exactamente 8 dígitos numéricos", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtNumeroTelefono.Focus();
                    lblNameForm.Visibility = Visibility.Visible;
                    return;
                }

                var ObjProveedorBL = new ProveedorBL();

                var result = ObjProveedorBL.GuardarProveedor(ObjProveedor);

                if (result == 0)
                {
                    MessageBox.Show("Nombre de Proveedor ya existe", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtNombreProveedor.Focus();
                    lblAlert.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    MessageBox.Show("Proveedor agregado con éxito", "Guardado Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);

                    ActualizarDataGrid();

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Uno o más campos están vacíos", "Valores Vacíos Detectados", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                ActualizarDataGrid();

                return;
            }


        }

        private void btnModificarProveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ProveedorModificar = new ProveedorEN
                {
                    Id = Convert.ToInt32(txtIdProveedor.Text),
                    Nombre = txtNombreProveedor.Text,
                    Direccion = txtDireccionProveedor.Text,
                    NumeroTelefono = txtNumeroTelefono.Text,
                    NumeroCelular = txtNumeroCelular.Text,
                    CorreoElectronico = txtCorreoProveedor.Text,
                    SitioWeb = txtSitioWebProveedor.Text,
                    Descripcion = txtDescripcionProveedor.Text,
                    FechaModificacion = DateTime.Now
                };

                if (ProveedorModificar.Nombre != "" && ProveedorModificar.Direccion != "" && ProveedorModificar.NumeroTelefono != "" && ProveedorModificar.CorreoElectronico != "" && ProveedorModificar.Direccion != "")
                {
                    if (Regex.IsMatch(ProveedorModificar.Nombre, @"\d"))
                    {
                        MessageBox.Show("El campo Nombre no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        txtNombreProveedor.Focus();

                        return;
                    }

                    if (Regex.IsMatch(ProveedorModificar.NumeroTelefono, "[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo 'Número de Teléfono' no debe contener letras", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        txtNumeroTelefono.Focus();
                        return;
                    }

                    if (ProveedorModificar.NumeroTelefono.Length != 8 || !ProveedorModificar.NumeroTelefono.All(char.IsDigit))
                    {
                        MessageBox.Show("El campo 'Número de Teléfono' debe contener exactamente 8 dígitos numéricos", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        txtNumeroTelefono.Focus();
                        lblNameForm.Visibility = Visibility.Visible;
                        return;
                    }

                    if (ProveedorModificar != null)
                    {
                        var pProveedorBL = new ProveedorBL();

                        pProveedorBL.ModificarProveedor(ProveedorModificar);

                        var pProveedorActulizado = pProveedorBL.ObtenerProveedor();

                        formProveedor.dgvMostrar_Proveedor.ItemsSource = null;

                        formProveedor.dgvMostrar_Proveedor.ItemsSource = pProveedorActulizado;

                        MessageBox.Show("Proveedor Modificado Con Exito", "Modificacion Proveedor", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        ActualizarDataGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Uno o más campos están vacíos", "Valores Vacíos Detectados", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    ActualizarDataGrid();

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado en: " + ex);
            }
            Close();

        }

        private void btnEliminarProveedor_Click(object sender, RoutedEventArgs e)
        {
            var EliminarProveedor = new ProveedorEN
            {
                Id = int.Parse(txtIdProveedor.Text)
            };

            if (EliminarProveedor != null)
            {
                var pProveedor = new ProveedorBL();

                pProveedor.EliminarProveedor(EliminarProveedor);

                var ProveedorActualizado = pProveedor.ObtenerProveedor();

                formProveedor.dgvMostrar_Proveedor.ItemsSource = null;

                formProveedor.dgvMostrar_Proveedor.ItemsSource = ProveedorActualizado;

                MessageBox.Show("Proveedor Eliminado Con Exito", "Eliminar Proveedor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            Close();
        }
    }
}
