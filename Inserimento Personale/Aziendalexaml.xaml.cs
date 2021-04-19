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
using System.Windows.Shapes;

namespace Inserimento_Personale
{
    /// <summary>
    /// Interaction logic for Aziendalexaml.xaml
    /// </summary>
    public partial class Aziendalexaml : Window
    {
        Persona p;
        string[] qualifica = new string[] { "1", "2", "3", "4" };

        public Aziendalexaml(Persona p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void cmbQualifica_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in qualifica)
                cmbQualifica.Items.Add(s);
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbQualifica.SelectedIndex == -1)
                    throw new Exception("Selezionare una qualifica!");
                if (txtArea.Text == "")
                    throw new Exception("Area non valida!");

                p.Qualifica = cmbQualifica.SelectedItem.ToString();
                p.Area = txtArea.Text;

                lbRiepilogo.Items.Add(p.Descrizione());

                Pulisci();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNuovoInserimento_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Pulisci()
        {
            cmbQualifica.SelectedIndex = -1;
            txtArea.Clear();
        }
    }
}
