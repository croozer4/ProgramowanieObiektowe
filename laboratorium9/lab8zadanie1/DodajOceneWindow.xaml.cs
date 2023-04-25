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

namespace lab8zadanie1
{
    public partial class DodajOceneWindow : Window
    {
        public Ocena ocenaDoDodania;
        public DodajOceneWindow()
        {
            InitializeComponent();
        }

        private void zatwierdzOcene(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbPrzedmiot.Text, @"^\p{Lu}\p{Ll}{1,20}$"))
            {
                MessageBox.Show("Wprowadzone dane są niepoprawne.");
                return;
            };
            
            ocenaDoDodania = new Ocena(tbPrzedmiot.Text, Int32.Parse(tbOcena.Text));
            //...

            DialogResult = true; //można zamknąć okno i pograć dane z w. Studen

        }
    }
}
