using System;
using System.Windows;
using System.Security.Principal;

namespace GRW.Integrador.Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Si las credenciales del usuario no coinciden se cierra la aplicación
            if(!LlamarPantallaIngreso())
                Application.Current.Shutdown(-1);

            InitializeComponent();

            LblUsuario.Content = "Usuario: " + System.Threading.Thread.CurrentPrincipal.Identity.Name;

            //MenuIntegrador menuPrincipal = new MenuIntegrador();
            //contenedor.Children.Clear();
            //contenedor.Children.Add(menuPrincipal);
        }

        private bool LlamarPantallaIngreso()
        {
            IngresoUsuario login = new IngresoUsuario();
            login.ShowDialog();

            if (login.UsuarioAceptado)
            {
                //le indico que voy a usar un usuario generico que viene de una base de datos
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
                //creo la identidad del usuario
                IIdentity usuario = new GenericIdentity(login.txtUsuario.Text, "Database");
                //TODO: consulto su lista de roles
                string[] roles = {"Usuario", "Administrador"};

                //creo la credencial
                GenericPrincipal credencialUsuario = new GenericPrincipal(usuario, roles);

                //asigno la credencial a la aplicación para que viva el usuario en toda su sesión
                System.Threading.Thread.CurrentPrincipal = credencialUsuario;

                //Consulto en la base de datos los permisos que tiene ese usuario

            }

            return login.UsuarioAceptado;
        }
    }
}
