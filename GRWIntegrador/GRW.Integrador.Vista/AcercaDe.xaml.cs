﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : UserControl
    {
        private string _nombreCliente;
        public string NombreCliente
        {
            get
            {
                _nombreCliente = ConfigurationManager.AppSettings.Get("NombreCliente");
                return _nombreCliente;
            }
            set { _nombreCliente = value; }
        }

        public AcercaDe()
        {
            InitializeComponent();
        }

        
    }
}
