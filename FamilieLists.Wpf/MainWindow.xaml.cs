using System.Collections.Generic;
using System.Windows;

namespace FamilieLists.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> familieLeden = new List<string>();
        List<string> backUp = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVoegFamilielidToe_Click(object sender, RoutedEventArgs e)
        {
            if (txtAchternaam.Text.Length != 0 && txtVoornaam.Text.Length != 0)
            {
                string achternaam = txtAchternaam.Text;
                string voornaam = txtVoornaam.Text;
                string[] familielid = new string [] {voornaam, achternaam };
                string familielidNaam = string.Join(", ", familielid);
                familieLeden.Add(familielidNaam);
                Properties.Settings.Default.Familieleden = familieLeden;
                Properties.Settings.Default.Save();
                backUp = familieLeden;
                VulLijsten();
                txtAchternaam.Clear();
                txtVoornaam.Clear();
                txtVoornaam.Focus();
            }
            else
            {
                string message = "Gelieve alle gegevens in te vullen aub!";
                string titel = "Fout!";
                MessageBoxImage icoon = MessageBoxImage.Error;
                MessageBoxButton ok = MessageBoxButton.OK;
                MessageBox.Show(message, titel, ok ,icoon);
            }

        }
        void VulLijsten()
        {
            familieLeden = Properties.Settings.Default.Familieleden;
            lstFamilieLijst.ItemsSource = familieLeden;
            lstFamilieLijst.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulLijsten();
            txtVoornaam.Focus();
        }

        private void btnVerwijderGeselecteerdFamilielidIndex_Click(object sender, RoutedEventArgs e)
        {
            if (lstFamilieLijst.SelectedIndex != -1)
            {
                int index;
                backUp = familieLeden;
                index = lstFamilieLijst.SelectedIndex;
                familieLeden.RemoveAt(index);
                VulLijsten();
            }
            else
            {
                string message = "Gelieve een familielid te selecteren!";
                string titel = "Fout!";
                MessageBoxImage icoon = MessageBoxImage.Error;
                MessageBoxButton ok = MessageBoxButton.OK;
                MessageBox.Show(message, titel, ok, icoon);
            }
        }

        private void btnVerwijderGeselecteerdFamilielidValue_Click(object sender, RoutedEventArgs e)
        {
            if (lstFamilieLijst.SelectedIndex != -1)
            {
                string familielid;
                backUp = Properties.Settings.Default.Familieleden;
                familielid = lstFamilieLijst.SelectedItem.ToString();
                familieLeden.Remove(familielid);
                VulLijsten();
            }
            else
            {
                string message = "Gelieve een familielid te selecteren!";
                string titel = "Fout!";
                MessageBoxImage icoon = MessageBoxImage.Error;
                MessageBoxButton ok = MessageBoxButton.OK;
                MessageBox.Show(message, titel, ok, icoon);
            }
        }

        private void btnVerwijderGansDeFamilie_Click(object sender, RoutedEventArgs e)
        {
            backUp = Properties.Settings.Default.Familieleden;
            familieLeden = null;
            familieLeden = new List<string>();
            Properties.Settings.Default.Familieleden = familieLeden;
            Properties.Settings.Default.Save();
            VulLijsten();
        }

        private void btnHerstel_Click(object sender, RoutedEventArgs e)
        {
            
            familieLeden = backUp ;
            Properties.Settings.Default.Familieleden = familieLeden;
            Properties.Settings.Default.Save();
            VulLijsten();
        }
    }
}
