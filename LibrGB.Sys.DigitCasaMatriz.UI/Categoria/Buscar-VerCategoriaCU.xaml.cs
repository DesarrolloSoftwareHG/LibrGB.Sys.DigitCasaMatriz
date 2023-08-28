﻿using LibrGB.Sys.DigitCasaMatriz.BL.Catalogo_BL;
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
            if (dgvMostrar_Categorias.SelectedItem != null)
            {
                // Si hay una fila seleccionada en el DataGridView (dgvMostrar_Categorias), continúa con el proceso de modificación.

                // Obtener la categoría seleccionada del enlace de datos del DataGridView.
                CategoriaEN categoriaSeleccionada = (CategoriaEN)dgvMostrar_Categorias.SelectedItem;

                // Obtener el ID de la categoría seleccionada.
                int idCategoria = categoriaSeleccionada.Id;

                // Crear una nueva instancia del formulario de modificación de categoría (_CategoriaAgregar) y pasar el ID de la categoría seleccionada.
                _MantenimientoCategoria ModifCategoria = new _MantenimientoCategoria(idCategoria);

                // Mostrar el formulario de modificación de categoría.
                ModifCategoria.Show();
            }
            else
            {
                // Si no hay ninguna fila seleccionada en el DataGridView, mostrar un mensaje de error.
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            // Definir el valor de la acción como byte usando el enumerado AccionEnum
            byte pAccion = (byte)AccionEnum.Eliminar;

            if (dgvMostrar_Categorias.SelectedItem != null)
            {
                // Obtener el objeto seleccionado del DataGrid (cambia "Categoria" por el tipo correcto)
                CategoriaEN categoriaSeleccionada = (CategoriaEN)dgvMostrar_Categorias.SelectedItem;

                // Obtener el valor de Id del objeto seleccionado (ajusta esto según la estructura de tus objetos)
                int idCategoria = categoriaSeleccionada.Id;

                // Crear una instancia de _CategoriaAgregar y pasar el Id y la acción
                _MantenimientoCategoria ElimCategoria = new _MantenimientoCategoria(idCategoria, pAccion);

                // Mostrar la ventana _CategoriaAgregar
                ElimCategoria.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error Al Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
        }

        private void btnVerCategoria_Click(object sender, RoutedEventArgs e)
        {
            // Definir el valor de la acción como byte usando el enumerado AccionEnum
            byte pAccion = (byte)AccionEnum.Ver;

            if (dgvMostrar_Categorias.SelectedItem != null)
            {
                // Obtener el objeto seleccionado del DataGrid (cambia "Categoria" por el tipo correcto)
                CategoriaEN categoriaSeleccionada = (CategoriaEN)dgvMostrar_Categorias.SelectedItem;

                // Obtener el valor de Id del objeto seleccionado (ajusta esto según la estructura de tus objetos)
                int idCategoria = categoriaSeleccionada.Id;

                // Crear una instancia de _CategoriaAgregar y pasar el Id y la acción
                _MantenimientoCategoria VerCategoria = new _MantenimientoCategoria(idCategoria, pAccion);

                // Mostrar la ventana _CategoriaAgregar
                VerCategoria.Show();
            }
            else
            {
                MessageBox.Show("Debes Seleccionar Almenos Una Fila", "Error En La Previsualizacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ActualizarDataGrid();
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
            this.Visibility = Visibility.Collapsed;
        }

        private void btnRecargarCategoria_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDataGrid();
            //Llamamos el metodo ActualizarDataGrid para actualizar el DGV al precionarlo
        }
    }
}
