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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kalkulator_wejsciowka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string tymczasowyTekst;
        public MainWindow()
        {
            InitializeComponent();
        }

        int zmienna1;
        int zmienna2;

        bool wpisywanieCyfr1 = true;
        bool wpisywanieCyfr2 = false;

        string aktualneDzialanie = "";

        private void cyfra_Click(object sender, RoutedEventArgs e)
        {

            tymczasowyTekst += ((Button)sender).Content.ToString();
            wyswietlacz.Text = tymczasowyTekst.ToString();

            if (wpisywanieCyfr1)
            {
                zmienna1 = int.Parse(tymczasowyTekst);
            }
            if (wpisywanieCyfr2)
            {
                zmienna2 = int.Parse(tymczasowyTekst);
            }
        }

        private void dodawanie_Click(object sender, RoutedEventArgs e)
        {
            aktualneDzialanie = "+";
            wpisywanieCyfr1 = false;
            wpisywanieCyfr2 = true;
        }

        private void mnozenie_Click(object sender, RoutedEventArgs e)
        {
            aktualneDzialanie = "*";
            wpisywanieCyfr1 = false;
            wpisywanieCyfr2 = true;
        }

        private void rownaSie_Click(object sender, RoutedEventArgs e)
        {
            int wynik = 0;

            if (aktualneDzialanie == "+")
            {
                wynik = zmienna1 + zmienna2;
            }
            if(aktualneDzialanie == "*")
            {
                wynik = zmienna1 * zmienna2;
            }

            wyswietlacz.Text = wynik.ToString();

        }
    }
}
