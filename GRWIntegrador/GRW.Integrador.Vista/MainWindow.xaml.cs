using System;
using System.ComponentModel;
using System.Windows;
using System.Security.Principal;
using GRW.Integrador.Modelo.Entidades;
using GRW.Integrador.Modelo.Negocio;

namespace GRW.Integrador.Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region VisibilidadMenus

        private Visibility _contenidoMenuIntegrador;
        public Visibility ContenidoMenuIntegrador
        {
            get { return _contenidoMenuIntegrador; }
            set
            {
                _contenidoMenuIntegrador = value;
                NotificarXAML("ContenidoMenuIntegrador");
            }
        }

        private Visibility _contenidoCargarArchivo;
        public Visibility ContenidoCargarArchivo
        {
            get { return _contenidoCargarArchivo; }
            set
            {
                _contenidoCargarArchivo = value;
                NotificarXAML("ContenidoCargarArchivo");
            }
        }

        private Visibility _contenidoAdministracionUsuarios;
        public Visibility ContenidoAdministracionUsuarios
        {
            get { return _contenidoAdministracionUsuarios; }
            set
            {
                _contenidoAdministracionUsuarios = value;
                NotificarXAML("ContenidoAdministracionUsuarios");
            }
        }

        private Visibility _contenidoTodosLosUsuarios;
        public Visibility ContenidoTodosLosUsuarios
        {
            get { return _contenidoTodosLosUsuarios; }
            set
            {
                _contenidoTodosLosUsuarios = value;
                NotificarXAML("ContenidoTodosLosUsuarios");
            }
        }

        private Visibility _contenidoInterfaces;
        public Visibility ContenidoInterfaces
        {
            get { return _contenidoInterfaces; }
            set
            {
                _contenidoInterfaces = value;
                NotificarXAML("ContenidoInterfaces");
            }
        }

        private Visibility _contenidoControlDeInventarios;
        public Visibility ContenidoControlDeInventarios
        {
            get { return _contenidoControlDeInventarios; }
            set
            {
                _contenidoControlDeInventarios = value;
                NotificarXAML("ContenidoControlDeInventarios");
            }
        }

        private Visibility _contenidoDiarios;
        public Visibility ContenidoDiarios
        {
            get { return _contenidoDiarios; }
            set
            {
                _contenidoDiarios = value;
                NotificarXAML("ContenidoDiarios");
            }
        }

        private Visibility _contenidoCuentas;
        public Visibility ContenidoCuentas
        {
            get { return _contenidoCuentas; }
            set
            {
                _contenidoCuentas = value;
                NotificarXAML("ContenidoCuentas");
            }
        }

        private Visibility _contenidoDimensiones;
        public Visibility ContenidoDimensiones
        {
            get { return _contenidoDimensiones; }
            set
            {
                _contenidoDimensiones = value;
                NotificarXAML("ContenidoDimensiones");
            }
        }

        private Visibility _contenidoBitacora;
        public Visibility ContenidoBitacora
        {
            get { return _contenidoBitacora; }
            set
            {
                _contenidoBitacora = value;
                NotificarXAML("ContenidoBitacora");
            }
        }

        private Visibility _contenidoLecturaAutomatica;
        public Visibility ContenidoLecturaAutomatica
        {
            get { return _contenidoLecturaAutomatica; }
            set
            {
                _contenidoLecturaAutomatica = value;
                NotificarXAML("ContenidoLecturaAutomatica");
            }
        }

        private Visibility _contenidoAcercaDe;
        public Visibility ContenidoAcercaDe
        {
            get { return _contenidoAcercaDe; }
            set
            {
                _contenidoAcercaDe = value;
                NotificarXAML("ContenidoAcercaDe");
            }
        }

        private Visibility _contenidoReporteDeDiscrepancias;
        public Visibility ContenidoReporteDeDiscrepancias
        {
            get { return _contenidoReporteDeDiscrepancias; }
            set
            {
                _contenidoReporteDeDiscrepancias = value;
                NotificarXAML("ContenidoReporteDeDiscrepancias");
            }
        }

        #endregion VisibilidadMenus

        public MainWindow()
        {
            //int reintentos = 1;
            //bool usuarioAceptado;

            //do
            //{
            //    //Se permiten 2 intentos para poner las credenciales correctas
            //    usuarioAceptado = LlamarPantallaIngreso();
            //    if (!usuarioAceptado)
            //    {
            //        MessageBox.Show("Verifique sus credenciales.", "Usuario no válido", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        reintentos++;
            //    }
            //} while (reintentos != 3 && usuarioAceptado == false);

            //if (usuarioAceptado == false)
            //{
            //    //Si las credenciales del usuario no coinciden se cierra la aplicación
            //    Application.Current.Shutdown(-1);
            //}
            if (!LlamarPantallaIngreso())
            {
                //Si las credenciales del usuario no coinciden se cierra la aplicación
                MessageBox.Show("Verifique sus credenciales y vuelva a iniciar la aplicación.", "Usuario no válido", MessageBoxButton.OK, MessageBoxImage.Warning);
                Application.Current.Shutdown(-1);
            }
            else
            {
                InitializeComponent();

                //Consulto en la base de datos los permisos que tiene ese usuario para 
                //asignarlos a la ENTIDAD USUARIO, esta entidad se la debo pasar al control, de usuario
                //MENU para saber que botones estan deshabilitados
                ManejoDeUsuarios modeloManejoUsuarios = new ManejoDeUsuarios();
                UsuarioEntidad usuarioPermisos = new UsuarioEntidad();
                usuarioPermisos =
                    modeloManejoUsuarios.ConsultaPermisosUsuario(System.Threading.Thread.CurrentPrincipal.Identity.Name);

                //verificando que el usuario tenga permisos en la base del integrador
                if (usuarioPermisos != null)
                {
                    LblUsuario.Content = "Usuario: " + usuarioPermisos.Nombre;
                    ContenidoMenuIntegrador = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("El usuario no tiene permisos en el Integrador.", "Usuario no válido", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Application.Current.Shutdown(-1);
                }
            }
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
                IIdentity usuario = new GenericIdentity(login.NombreUsuario, "Database");
                //su lista de roles
                string[] roles = {"Usuario", "Administrador"};
                //creo la credencial
                GenericPrincipal credencialUsuario = new GenericPrincipal(usuario, roles);
                //asigno la credencial a la aplicación para que viva el usuario en toda su sesión
                System.Threading.Thread.CurrentPrincipal = credencialUsuario;
            }

            return login.UsuarioAceptado;
        }

        #region Notify

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotificarXAML(string propiedad)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propiedad));
            else MessageBox.Show("Error al notificar al XAML la propiedad " + propiedad);
        }

        #endregion

        #region ManejoDeMenus

        public void SeleccionarMenu(EnumeracionMenu menu)
        {
            DescargarContenidos();
            switch (menu)
            {
                case EnumeracionMenu.AcercaDe:
                    ContenidoAcercaDe = Visibility.Visible;
                    break;
                case EnumeracionMenu.AdministracionUsuarios:
                    ContenidoAdministracionUsuarios = Visibility.Visible;
                    break;
                case EnumeracionMenu.Bitacora:
                    ContenidoBitacora = Visibility.Visible;
                    break;
                case EnumeracionMenu.CargarArchivo:
                    ContenidoCargarArchivo = Visibility.Visible;
                    break;
                case EnumeracionMenu.ControlDeInventarios:
                    ContenidoControlDeInventarios = Visibility.Visible;
                    break;
                case EnumeracionMenu.Cuentas:
                    ContenidoCuentas = Visibility.Visible;
                    break;
                case EnumeracionMenu.Diarios:
                    ContenidoDiarios = Visibility.Visible;
                    break;
                case EnumeracionMenu.Dimensiones:
                    ContenidoDimensiones = Visibility.Visible;
                    break;
                case EnumeracionMenu.Interfaces:
                    ContenidoInterfaces = Visibility.Visible;
                    break;
                case EnumeracionMenu.LecturaAutomatica:
                    ContenidoLecturaAutomatica = Visibility.Visible;
                    break;
                case EnumeracionMenu.MenuIntegrador:
                    ContenidoMenuIntegrador = Visibility.Visible;
                    break;
                case EnumeracionMenu.TodosLosUsuarios:
                    ContenidoTodosLosUsuarios = Visibility.Visible;
                    break;
                case EnumeracionMenu.ReporteDeDiscrepancias:
                    ContenidoReporteDeDiscrepancias = Visibility.Visible;
                    break;
                default:
                    ContenidoMenuIntegrador = Visibility.Visible;
                    break;
            }
        }

        private void DescargarContenidos()
        {
            ContenidoAcercaDe = Visibility.Collapsed;
            ContenidoAdministracionUsuarios = Visibility.Collapsed;
            ContenidoBitacora = Visibility.Collapsed;
            ContenidoCargarArchivo = Visibility.Collapsed;
            ContenidoControlDeInventarios = Visibility.Collapsed;
            ContenidoCuentas = Visibility.Collapsed;
            ContenidoDiarios = Visibility.Collapsed;
            ContenidoDimensiones = Visibility.Collapsed;
            ContenidoInterfaces = Visibility.Collapsed;
            ContenidoLecturaAutomatica = Visibility.Collapsed;
            ContenidoMenuIntegrador = Visibility.Collapsed;
            ContenidoTodosLosUsuarios = Visibility.Collapsed;
            ContenidoReporteDeDiscrepancias = Visibility.Collapsed;
        }

        private void LblMenu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.MenuIntegrador);
        }

        private void LblAcerca_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SeleccionarMenu(EnumeracionMenu.AcercaDe);
        }

        #endregion ManejoDeMenus
    }
}
