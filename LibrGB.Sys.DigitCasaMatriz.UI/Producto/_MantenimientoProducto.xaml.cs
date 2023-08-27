using System;
using System.Collections.Generic;
using System.IO;
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
using LibrGB.Sys.DigitCasaMatriz.EN;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Categoria;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Producto;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.Proveedor;
using LibrGB.Sys.DigitCasaMatriz.EN.Catalogo.UDM;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;
using static LibrGB.Sys.DigitCasaMatriz.EN.Acciones;
using BarcodeStandard;

namespace LibrGB.Sys.DigitCasaMatriz.UI.Producto
{
    /// <summary>
    /// Lógica de interacción para _MantenimientoProducto.xaml
    /// </summary>
    public partial class _MantenimientoProducto : MetroWindow
    {
        public _MantenimientoProducto(int? pId = null, byte? pAccion = null)
        {
            InitializeComponent();

            btnGuardaImg.Visibility = Visibility.Collapsed;

            ActualizarDataGrid();

            CargarComboCategoria();

            CargarComboProveedor();

            CargarComboUnidadDeMedida();

            CargarComboEstatus();

            if (pId != null)
            {
                SetProducto(pId, pAccion);
            }

            if (pAccion == (byte)AccionEnum.Crear)
            {
                txtNombreProducto.Text = "";
                txtCodigoProducto.Text = "";
                cbxCategoriaProducto.SelectedItem = "";
                cbxProveedorProducto.SelectedItem = "";
                txtPrecioProducto.Text = "";
                cbxUnidadDeMedidaProducto.SelectedItem = "";
                cbxEstatusProducto.SelectedItem = "";
                txtDescripcionProducto.Text = "";

                dtFechaCreacion.SelectedDate = DateTime.Now;
                dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaCreacion.IsEnabled = false;

                dtFechaModificacion.SelectedDate = DateTime.Now;
                dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                dtFechaModificacion.IsEnabled = false;

                btnEliminarProducto.Visibility = Visibility.Collapsed;
                btnModificarProducto.Visibility = Visibility.Collapsed;
            }
        }

        private void CargarComboCategoria()
        {
            var categoriaBl = new CategoriaBL();
            var categoria = categoriaBl.ObtenerCategoria();

            cbxCategoriaProducto.ItemsSource = categoria;

            cbxCategoriaProducto.DisplayMemberPath = "Nombre";
            cbxCategoriaProducto.SelectedValuePath = "Id";
        }

        private void CargarComboProveedor()
        {
            var proveedorBl = new ProveedorBL();
            var proveedor = proveedorBl.ObtenerProveedor();

            cbxProveedorProducto.ItemsSource = proveedor;

            cbxProveedorProducto.DisplayMemberPath = "Nombre";
            cbxCategoriaProducto.SelectedValuePath = "Id";
        }

        private void CargarComboUnidadDeMedida()
        {
            var UDMBl = new UnidadDeMedidaBL();
            var UnidadDeMedida = UDMBl.ObtenerUDM();

            cbxUnidadDeMedidaProducto.ItemsSource = UnidadDeMedida;

            cbxUnidadDeMedidaProducto.DisplayMemberPath = "Nombre";
            cbxUnidadDeMedidaProducto.SelectedValuePath = "Id";
        }

        private void CargarComboEstatus()
        {
            var estatusBl = new EstatusBL();
            var estatus = estatusBl.ObtenerEstatus();

            cbxEstatusProducto.ItemsSource = estatus;

            cbxEstatusProducto.DisplayMemberPath = "Nombre";
            cbxEstatusProducto.SelectedValuePath = "Id";
        }

        public void SetProducto(int? pId, byte? pAccion)
        {
            var productoBl = new ProductoBL();

            var producto = productoBl.ObtenerPorId(pId);

            if (producto != null)
            {
                if (pAccion == (byte)AccionEnum.Ver)
                {
                    lblNameForm.Content = "Visualizacion del Producto";

                    txtIdProducto.Text = Convert.ToString(producto.Id);

                    txtNombreProducto.Text = producto.Nombre;
                    txtNombreProducto.IsEnabled = false;

                    txtCodigoProducto.Text = producto.Codigo;
                    txtCodigoProducto.IsEnabled = false;

                    cbxCategoriaProducto.SelectedValue = producto.Categoria.Id;
                    cbxCategoriaProducto.DisplayMemberPath = "Nombre";
                    cbxCategoriaProducto.SelectedValuePath = "Id";
                    cbxCategoriaProducto.IsEnabled = false;

                    cbxProveedorProducto.SelectedValue = producto.Proveedor.Id;
                    cbxProveedorProducto.DisplayMemberPath = "Nombre";
                    cbxProveedorProducto.SelectedValuePath = "Id";
                    cbxProveedorProducto.IsEnabled = false;

                    txtPrecioProducto.Text = producto.Precio.ToString("0.00");
                    txtPrecioProducto.IsEnabled = false;

                    cbxUnidadDeMedidaProducto.SelectedValue = producto.UDM.Id;
                    cbxUnidadDeMedidaProducto.DisplayMemberPath = "Nombre";
                    cbxUnidadDeMedidaProducto.SelectedValuePath = "Id";
                    cbxUnidadDeMedidaProducto.IsEnabled = false;

                    cbxEstatusProducto.SelectedValue = producto.Estatus.Id;
                    cbxEstatusProducto.DisplayMemberPath = "Nombre";
                    cbxEstatusProducto.SelectedValuePath = "Id";
                    cbxEstatusProducto.IsEnabled = false;

                    txtDescripcionProducto.Text = producto.Descripcion;
                    txtDescripcionProducto.IsEnabled = false;

                    dtFechaCreacion.SelectedDate = producto.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaCreacion.IsEnabled = false;

                    dtFechaModificacion.SelectedDate = producto.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaModificacion.IsEnabled = false;

                    btnAgregarProducto.Visibility = Visibility.Collapsed;
                    btnModificarProducto.Visibility = Visibility.Collapsed;
                    btnEliminarProducto.Visibility = Visibility.Collapsed;
                }
                else if (pAccion == (byte)AccionEnum.Eliminar)
                {
                    lblNameForm.Content = "Eliminar el Producto";

                    txtIdProducto.Text = Convert.ToString(producto.Id);

                    txtNombreProducto.Text = producto.Nombre;
                    txtNombreProducto.IsEnabled = false;

                    txtCodigoProducto.Text = producto.Codigo;
                    txtCodigoProducto.IsEnabled = false;

                    cbxCategoriaProducto.SelectedValue = producto.Categoria.Id;
                    cbxCategoriaProducto.DisplayMemberPath = "Nombre";
                    cbxCategoriaProducto.SelectedValuePath = "Id";
                    cbxCategoriaProducto.IsEnabled = false;

                    cbxProveedorProducto.SelectedValue = producto.Proveedor.Id;
                    cbxProveedorProducto.DisplayMemberPath = "Nombre";
                    cbxProveedorProducto.SelectedValuePath = "Id";
                    cbxProveedorProducto.IsEnabled = false;

                    txtPrecioProducto.Text = producto.Precio.ToString("0.00");
                    txtPrecioProducto.IsEnabled = false;

                    cbxUnidadDeMedidaProducto.SelectedValue = producto.UDM.Id;
                    cbxUnidadDeMedidaProducto.DisplayMemberPath = "Nombre";
                    cbxUnidadDeMedidaProducto.SelectedValuePath = "Id";
                    cbxUnidadDeMedidaProducto.IsEnabled = false;

                    cbxEstatusProducto.SelectedValue = producto.Estatus.Id;
                    cbxEstatusProducto.DisplayMemberPath = "Nombre";
                    cbxEstatusProducto.SelectedValuePath = "Id";
                    cbxEstatusProducto.IsEnabled = false;

                    txtDescripcionProducto.Text = producto.Descripcion;
                    txtDescripcionProducto.IsEnabled = false;

                    dtFechaCreacion.SelectedDate = producto.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaCreacion.IsEnabled = false;

                    dtFechaModificacion.SelectedDate = producto.FechaModificacion;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaModificacion.IsEnabled = false;

                    btnAgregarProducto.Visibility = Visibility.Collapsed;
                    btnModificarProducto.Visibility = Visibility.Collapsed;
                }
                else
                {
                    lblNameForm.Content = "Modificacion del Producto";

                    txtIdProducto.Text = Convert.ToString(producto.Id);

                    txtNombreProducto.Text = producto.Nombre;

                    txtCodigoProducto.Text = producto.Codigo;
                    txtCodigoProducto.IsEnabled = false;

                    cbxCategoriaProducto.SelectedValue = producto.Categoria.Id;
                    cbxCategoriaProducto.DisplayMemberPath = "Nombre";
                    cbxCategoriaProducto.SelectedValuePath = "Id";

                    cbxProveedorProducto.SelectedValue = producto.Proveedor.Id;
                    cbxProveedorProducto.DisplayMemberPath = "Nombre";
                    cbxProveedorProducto.SelectedValuePath = "Id";

                    txtPrecioProducto.Text = producto.Precio.ToString("0.00");

                    cbxUnidadDeMedidaProducto.SelectedValue = producto.UDM.Id;
                    cbxUnidadDeMedidaProducto.DisplayMemberPath = "Nombre";
                    cbxUnidadDeMedidaProducto.SelectedValuePath = "Id";

                    cbxEstatusProducto.SelectedValue = producto.Estatus.Id;
                    cbxEstatusProducto.DisplayMemberPath = "Nombre";
                    cbxEstatusProducto.SelectedValuePath = "Id";

                    txtDescripcionProducto.Text = producto.Descripcion;

                    dtFechaCreacion.SelectedDate = producto.FechaCreacion;
                    dtFechaCreacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaCreacion.IsEnabled = false;

                    dtFechaModificacion.SelectedDate = DateTime.Now;
                    dtFechaModificacion.SelectedDateFormat = DatePickerFormat.Long;
                    dtFechaModificacion.IsEnabled = false;

                    btnAgregarProducto.Visibility = Visibility.Collapsed;
                    btnModificarProducto.Visibility = Visibility.Collapsed;
                }

            }
        }

        ProductoBL ObjProductBL = new ProductoBL();

        Buscar_VerProductoCU formProducto = new Buscar_VerProductoCU();

        public void ActualizarDataGrid()
        {
            formProducto.dgvMostrar_Producto.ItemsSource = null;

            formProducto.dgvMostrar_Producto.ItemsSource = ObjProductBL.ObtenerProducto();

        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            var ObjProducto = new ProductoEN
            {
                Nombre = txtNombreProducto.Text,
                Codigo = txtCodigoProducto.Text,
                Estatus = new EstatusEN
                {
                    Id = Convert.ToInt32(cbxEstatusProducto.SelectedValue)
                },

                Precio = decimal.TryParse(txtPrecioProducto.Text, out decimal precioValue) ? precioValue : 0,

                UDM = new UnidadDeMedidaEN
                {
                    Id = Convert.ToInt32(cbxUnidadDeMedidaProducto.SelectedValue)
                },

                Categoria = new CategoriaEN
                {
                    Id = Convert.ToInt32(cbxCategoriaProducto.SelectedValue)
                },

                Proveedor = new ProveedorEN
                {
                    Id = Convert.ToInt32(cbxProveedorProducto.SelectedValue)
                },

                Descripcion = txtDescripcionProducto.Text,
                FechaCreacion = DateTime.Now
            };

            if (ObjProducto.Nombre != "" && ObjProducto.Codigo != "" && ObjProducto.Precio != 0 && ObjProducto.Descripcion != "")
            {
                if (Regex.IsMatch(ObjProducto.Nombre, @"\d"))
                {
                    MessageBox.Show("El campo 'Nombre del Producto' no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtNombreProducto.Focus();

                    return;
                }

                if (Regex.IsMatch(ObjProducto.Codigo, "[a-zA-Z]"))
                {
                    MessageBox.Show("El campo 'Código' no debe contener letras", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtCodigoProducto.Focus();

                    return;
                }
                if (Regex.IsMatch(ObjProducto.Precio.ToString(), "[a-zA-Z]"))
                {
                    MessageBox.Show("El campo 'Precio' no debe contener letras", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtPrecioProducto.Focus();

                    return;
                }

                var ObjProductoBL = new ProductoBL();

                var result = ObjProductoBL.GuardarProducto(ObjProducto);

                if (result == 0)
                {
                    MessageBox.Show("El codigo del Producto ya existente", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtCodigoProducto.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Producto agregado con éxito", "Guardado Exitosamente", MessageBoxButton.OK, MessageBoxImage.Information);

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

        private void btnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productoModificado = new ProductoEN
                {
                    Nombre = txtNombreProducto.Text,
                    Codigo = txtCodigoProducto.Text,
                    Estatus = new EstatusEN
                    {
                        Id = Convert.ToInt32(cbxEstatusProducto.SelectedValue)
                    },

                    Precio = decimal.TryParse(txtPrecioProducto.Text, out decimal precioValue) ? precioValue : 0,

                    UDM = new UnidadDeMedidaEN
                    {
                        Id = Convert.ToInt32(cbxUnidadDeMedidaProducto.SelectedValue)
                    },

                    Categoria = new CategoriaEN
                    {
                        Id = Convert.ToInt32(cbxCategoriaProducto.SelectedValue)
                    },

                    Proveedor = new ProveedorEN
                    {
                        Id = Convert.ToInt32(cbxProveedorProducto.SelectedValue)
                    },

                    Descripcion = txtDescripcionProducto.Text,
                    FechaModificacion = DateTime.Now
                };

                if (productoModificado.Nombre != "" && productoModificado.Codigo != "" && productoModificado.Precio != 0 && productoModificado.Descripcion != "")
                {
                    if (Regex.IsMatch(productoModificado.Nombre, @"\d"))
                    {
                        MessageBox.Show("El campo 'Nombre del Producto' no debe contener números", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        txtNombreProducto.Focus();

                        return;
                    }

                    if (Regex.IsMatch(productoModificado.Precio.ToString(), "[a-zA-Z]"))
                    {
                        MessageBox.Show("El campo 'Precio' no debe contener letras", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        txtPrecioProducto.Focus();

                        return;
                    }

                    if (productoModificado != null)
                    {
                        var pProductoBL = new ProductoBL();

                        pProductoBL.ModificarProducto(productoModificado);

                        var pProductoActulizado = pProductoBL.ObtenerProducto();

                        formProducto.dgvMostrar_Producto.ItemsSource = null;

                        formProducto.dgvMostrar_Producto.ItemsSource = pProductoActulizado;

                        MessageBox.Show("Producto Modificado Con Exito", "Modificacion de Producto", MessageBoxButton.OK, MessageBoxImage.Exclamation);

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

        private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            var EliminarProducto = new ProductoEN
            {
                Id = int.Parse(txtIdProducto.Text)
            };

            if (EliminarProducto != null)
            {
                var pProducto = new ProductoBL();

                pProducto.EliminarProducto(EliminarProducto);

                var ProductoActualizado = pProducto.ObtenerProducto();

                formProducto.dgvMostrar_Producto.ItemsSource = null;

                formProducto.dgvMostrar_Producto.ItemsSource = ProductoActualizado;

                MessageBox.Show("Producto Eliminado Con Exito", "Eliminar Unidad De Medida", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            Close();
        }



        private void txtCodigoProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Se obtiene el texto ingresado y se eliminan los espacios en blanco al principio y al final
            string codigo = txtCodigoProducto.Text.Trim();
            // Se eliminan los caracteres especiales, tildes, espacios y la letra "ñ"
            string cleanedCodigo = RemoveSpecialCharacters(codigo);

            // Se crea un objeto Barcode
            Barcode barcode = new Barcode();
            //Coniguracion del texto de las barras
            barcode.IncludeLabel = true;
            barcode.Alignment = AlignmentPositions.Center;
            //Dimensiones de la imagen
            int width = 446;
            int height = 119;

            // Si el texto ingresado contiene caracteres especiales, tildes, espacios o la letra "ñ"
            if (codigo != cleanedCodigo)
            {
                // Se muestra un mensaje de advertencia en el label "lblWarning" con un color de fuente rojo
                lblWarning.Visibility = Visibility.Visible;
                lblWarning.Content = "El texto no debe contener caracteres especiales, tildes, espacios o la letra ñ.";
                lblWarning.Foreground = new SolidColorBrush(Colors.Red);
                // Se borra la imagen del código de barras
                imgBarraCode.Source = null;
                //Ocultar botón de guardar imagen
                btnGuardaImg.Visibility = Visibility.Collapsed;
            }
            // Si el texto ingresado no contiene caracteres especiales, tildes, espacios o la letra "ñ"
            else if (!string.IsNullOrEmpty(cleanedCodigo))
            {
                // Se genera un código de barras Code 128 con el texto ingresado y se muestra en la imagen "imgBarraCode"
                SKImage barcodeImage = barcode.Encode(BarcodeStandard.Type.Code128, cleanedCodigo, width, height);
                imgBarraCode.Source = ToBitmap(barcodeImage);
                // Se oculta el label "lblWarning"
                lblWarning.Visibility = Visibility.Collapsed;
                //Mostrar botón de guardar imagen
                btnGuardaImg.Visibility = Visibility.Visible;
            }
            // Si el cuadro de texto está vacío
            else
            {
                // Se borra la imagen del código de barras y se muestra un mensaje de advertencia en el label "lblWarning" con un color de fuente negro
                imgBarraCode.Source = null;
                lblWarning.Visibility = Visibility.Visible;
                //Ocultar botón de guardar imagen
                btnGuardaImg.Visibility = Visibility.Collapsed;
                lblWarning.Content = "El texto no debe estar vacío.";
                lblWarning.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private BitmapSource ToBitmap(SKImage skImage)
        {
            using (var data = skImage.Encode()) // Codifica la imagen en formato SKData
            using (var stream = data.AsStream()) // Convierte SKData a Stream
            {
                var bitmapImage = new BitmapImage(); // Crea un nuevo objeto BitmapImage
                bitmapImage.BeginInit(); // Inicia la inicialización del objeto BitmapImage
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Establece la opción de caché en OnLoad
                bitmapImage.StreamSource = stream; // Establece el Stream de origen de la imagen
                bitmapImage.EndInit(); // Finaliza la inicialización del objeto BitmapImage
                return bitmapImage; // Devuelve el objeto BitmapImage convertido a BitmapSource
            }
        }

        private string RemoveSpecialCharacters(string input)
        {
            // Utiliza una expresión regular para reemplazar los caracteres especiales por una cadena vacía
            return Regex.Replace(input, "[^a-zA-Z0-9.,-]", "");
        }

        private void GuardarImagen()
        {
            // Se crea un cuadro de diálogo para guardar el archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen (*.png)|*.png";
            saveFileDialog.FileName = "codigo_de_barras.png";

            // Si el usuario selecciona un archivo y hace clic en "Guardar"
            if (saveFileDialog.ShowDialog() == true)
            {
                // Se guarda la imagen en el archivo seleccionado
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgBarraCode.Source));
                    encoder.Save(fileStream);
                }
            }
        }

        private void btnGuardaImg_Click(object sender, RoutedEventArgs e)
        {
            GuardarImagen();
        }
    }
}
