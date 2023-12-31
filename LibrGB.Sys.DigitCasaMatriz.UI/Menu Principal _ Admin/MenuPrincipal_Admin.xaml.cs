﻿using System;
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
using LibrGB.Sys.DigitCasaMatriz.UI.Categoria;
using LibrGB.Sys.DigitCasaMatriz.UI.Producto;
using LibrGB.Sys.DigitCasaMatriz.UI.Proveedor;
using LibrGB.Sys.DigitCasaMatriz.UI.UnidaDeMedida;
using MahApps.Metro.Controls;

namespace LibrGB.Sys.DigitCasaMatriz.UI.Menu_Principal___Admin
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal_Admin.xaml
    /// </summary>
    public partial class MenuPrincipal_Admin : MetroWindow
    {
        public MenuPrincipal_Admin()
        {
            InitializeComponent();
        }

        private void Producto_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerProductoCU());
        }

        private void Categoria_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerCategoriaCU());
        }

        private void Proveedor_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerProveedorCU());
        }

        private void UnidadDeMedida_Click(object sender, RoutedEventArgs e)
        {
            FramePrincipal.NavigationService.Navigate(new Buscar_VerUnidadDeMedidaCU());
        }

        //Boton para limpiar el frame ( no cumple con su accion al 100% pero es funcional, quedara por si se llegase a utilizar)
        private void LimpiarFrame(object sender, RoutedEventArgs e)
        {
            FramePrincipal.Content = null;

        }
    }
}
