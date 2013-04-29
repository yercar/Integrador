using System;
using System.Windows;
using System.Windows.Controls;

namespace GRW.Integrador.Vista
{
    /// <summary>
    /// Lógica de interacción para MenuIntegrador.xaml
    /// </summary>
    public partial class MenuIntegrador : UserControl
    {
        #region Menu ventana principal

        // Variable de clase para instanciar la ventana principal.
        private MainWindow _ventanaPrincipal = ((MainWindow)App.Current.MainWindow);

        // Instanciamos el metodo publico para cambiar menu en la ventana principal
        private void SeleccionarMenu(EnumeracionMenu menu)
        {
            _ventanaPrincipal.SeleccionarMenu(menu);
        }

        #endregion


        public MenuIntegrador()
        {
            InitializeComponent();
        }

        private void Salir_OnClick(object sender, EventArgs e)
        {
            Application.Current.Shutdown(-1);
        }

        private void TileCargarArchivo_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.CargarArchivo);
        }

        private void TileBitacora_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.Bitacora);
        }

        private void TileSlideInterfaces_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.Interfaces);
        }

        private void TileDiarios_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.Diarios);
        }

        private void TileCuentas_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.Cuentas);
        }

        private void TileInventarios_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.ControlDeInventarios);
        }

        private void TileSlideDimensiones_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.Dimensiones);
        }

        private void TileReprocesos_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.CargarArchivo);
        }

        private void TilePermisos_Click(object sender, EventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.AdministracionUsuarios);
        }

    }
}
