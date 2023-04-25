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
using System.Text.RegularExpressions;

namespace kolokwium
{
    /// <summary>
    /// Logika interakcji dla klasy DodajHodowce.xaml
    /// </summary>
    public partial class DodajHodowce : Window
    {
        public Hodowca hodowca;
        public DodajHodowce()
        {
            InitializeComponent();
            
            this.hodowca = new Hodowca();
            
        }

        private void zatwierdz_Click(object sender, RoutedEventArgs e)
        {

            if (
                !Regex.IsMatch(tbImie.Text, @"^\p{Lu}\p{Ll}{1,20}$") ||
                !Regex.IsMatch(tbNazwisko.Text, @"^\p{Lu}\p{Ll}{1,20}$") ||
                !Regex.IsMatch(tbStrona.Text, @"^www.\p{Ll}{1,20}.pl$") ||
                !Regex.IsMatch(tbWiek.Text, @"^[0-9]{1,3}$")
             )
            {
                MessageBox.Show("Wprowadzone dane są niepoprawne.");
                return;
            };
            hodowca.Imie = tbImie.Text;
            hodowca.Nazwisko = tbNazwisko.Text;
            hodowca.StronaInternetowa = tbStrona.Text;
            hodowca.Wiek = int.Parse(tbWiek.Text);

            DialogResult = true;
        }
    }
}
