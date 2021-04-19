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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inserimento_Personale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LeggiFile();
            txtCodFisc.Focus();
        }

        string[] tipologia = new string[] { "Aziendale", "SubFornitore", "Fornitore", "Consulente" };
        private HashSet<string> codiciEsistenti = new HashSet<string>();
        List<Persona> persone = new List<Persona>();

        private void cmbTipologia_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in tipologia)
            {
                cmbTipologia.Items.Add(s);
            }
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
                    codiciEsistenti.Add(personale[0]);
                }
            } while (line != null);

            streamLettura.Close();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            Pulisci();
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCodFisc.Text == "")
                    throw new Exception("Codice fiscale non valido!");
                if (txtNome.Text == "")
                    throw new Exception("Nome non valido!");
                if (txtCognome.Text == "")
                    throw new Exception("Cognome non valido!");
                if (cmbTipologia.SelectedIndex == -1)
                    throw new Exception("Selezionare una tipologia!");

                Persona p = new Persona(txtCodFisc.Text, txtNome.Text, txtCognome.Text, cmbTipologia.SelectedIndex);

                if (codiciEsistenti.Contains(p.CodiceFiscale))
                {
                    throw new Exception("Codice fiscale già esistente!");
                }
                else
                {
                    codiciEsistenti.Add(p.CodiceFiscale);
                    persone.Add(p);
                }

                if (cmbTipologia.SelectedIndex == 0)
                    new Aziendalexaml(p).ShowDialog();
                if (cmbTipologia.SelectedIndex == 1)
                    MessageBox.Show("Presto disponibile!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (cmbTipologia.SelectedIndex == 2)
                    MessageBox.Show("Presto disponibile!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (cmbTipologia.SelectedIndex == 3)
                    MessageBox.Show("Presto disponibile!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                Pulisci();

                MessageBox.Show("Persona creata!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Pulisci()
        {
            txtCodFisc.Clear();
            txtNome.Clear();
            txtCognome.Clear();
            cmbTipologia.SelectedIndex = -1;
        }
    }
}
