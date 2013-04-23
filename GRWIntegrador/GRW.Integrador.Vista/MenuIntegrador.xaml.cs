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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GRW.Integrador.Vista
{
    /// <summary>
    /// Lógica de interacción para MenuIntegrador.xaml
    /// </summary>
    public partial class MenuIntegrador : UserControl
    {
        public MenuIntegrador()
        {
            InitializeComponent();
        }

        private void Salir_OnClick(object sender, EventArgs e)
        {
            Application.Current.Shutdown(-1);
        }

    }
}
