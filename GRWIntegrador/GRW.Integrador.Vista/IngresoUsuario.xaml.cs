using System;
using System.Windows;
using GRW.Integrador.Modelo.Negocio;

namespace GRW.Integrador.Vista
{
    /// <summary>
    /// Lógica de interacción para IngresoUsuario.xaml
    /// </summary>
    public partial class IngresoUsuario : Window
    {
        public bool UsuarioAceptado { get; set; }
        public string NombreUsuario { get; set; }

        public IngresoUsuario()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioAceptado = false;

            //Envio usuario y contraseña que puso el usuario a la capa de negocio
            ManejoDeUsuarios modeloManejoUsuarios = new ManejoDeUsuarios();

            try
            {
                if (modeloManejoUsuarios.ConsultaCredencialesDeUsuario(txtUsuario.Text, txtPassword.Password, Convert.ToBoolean(chkAdministrador.IsChecked)))
                    UsuarioAceptado = true;

                //Definiendo nombre de usuario dependiendo de si es administrador o no
                if (Convert.ToBoolean(chkAdministrador.IsChecked))
                    NombreUsuario = txtUsuario.Text;
                else if (!Convert.ToBoolean(chkAdministrador.IsChecked))
                {
                    string[] dominioUsuario = txtUsuario.Text.Split('\\');
                    NombreUsuario = dominioUsuario[1];
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DialogResult = true;
        }

    }
}
