using System.Collections.Generic;
using System.Windows;

namespace FamilieLists.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> familieLeden = new List<string>()
            {
            "Jan|Mijne Man", "Jeanien|Mijn Trien", "Sid|My Kid"
            };
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnVoegFamilielidToe_Click(object sender, RoutedEventArgs e)
        {
            string familielid;
            string achternaam = txtAchternaam.Text;
            string voornaam = txtVoornaam.Text;
            familielid = voornaam + "|" + achternaam;
            List<string> familieleden = new List<string>

        }
    }
}
