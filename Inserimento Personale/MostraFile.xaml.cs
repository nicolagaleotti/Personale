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

namespace Inserimento_Personale
{
    /// <summary>
    /// Interaction logic for MostraFile.xaml
    /// </summary>
    public partial class MostraFile : Window
    {
        public MostraFile()
        {
            InitializeComponent();
        }

        private void btnIndietro_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
