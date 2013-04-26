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

        public IngresoUsuario()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioAceptado = false;

            //TODO: Consultar usuario en base de datos
            //Envio usuario y contraseña que puso el usuario a la capa de negocio
            ManejoDeUsuarios modeloManejoUsuarios = new ManejoDeUsuarios();
            if (modeloManejoUsuarios.ConsultaUsuario(txtUsuario.Text, txtPassword.Password))
            {
                UsuarioAceptado = true;
            }

            DialogResult = true;
        }
    }
}
