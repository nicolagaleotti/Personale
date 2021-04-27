using System;
using System.Collections.Generic;
using System.IO;
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
            LeggiFile();
        }
        private void LeggiFile()
        {
            string line;
            StreamReader streamLettura = new StreamReader(Costanti.DIRECTORY + Costanti.FILE);

            do
            {
                line = streamLettura.ReadLine();
                if (line != null)
                {
                    string[] personale = line.Split(';');

                    foreach (string p in personale)
                        lbMostra.Items.Add(p);
                }
            } while (line != null);

            streamLettura.Close();
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
