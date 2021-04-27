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
    /// Interaction logic for Aziendalexaml.xaml
    /// </summary>
    public partial class Aziendalexaml : Window
    {
        Persona p;
        string[] qualifica = new string[] { "Dirigente", "Quadro", "Amministrativo", "Operaio" };

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

                using (StreamWriter sw = new StreamWriter(Costanti.FILE, true))
                {
                    string line = $"{p.CodiceFiscale};{p.Nome};{p.Cognome};{p.Tipologia};{p.Qualifica};{p.Area}";
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }

                lbRiepilogo.Items.Add(p.Descrizione());

                Pulisci();

                cmbQualifica.IsEnabled = false;
                txtArea.IsEnabled = false;
                btnInserisci.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNuovoInserimento_Click(object sender, RoutedEventArgs e)
        {
            if (lbRiepilogo.Items.Count == 0)
                MessageBox.Show("Inserire qualifica e area per creare la persona!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
                this.Close();
        }

        private void Pulisci()
        {
            cmbQualifica.SelectedIndex = -1;
            txtArea.Clear();
        }

        private void btnMostraFile_Click(object sender, RoutedEventArgs e)
        {
            new MostraFile().ShowDialog();
        }
    }
}
