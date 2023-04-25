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

namespace labo7kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public static string wynik_temp = "";

        public static IList<double> listaZmiennych = new List<double>();
        public static IList<string> listaDzialan = new List<string>();

        public bool ostatnieDzialanie = false;
        public bool ostatnieRownaSie = false;
        public bool rozpoczetaPotega = false;
        public bool rozpoczetyPierwiastek = false;

        public double tymczasowaDoPotegi1;
        public double tymczasowaDoPotegi2;

        public double buforOstatniaZmienna;
        public string buforOstatnieDzialanie;

        string tymczasowyStringDoPotegi = "";
        private void cyfra_Click(object sender, RoutedEventArgs e)
        {
            if (wynik_temp.Length > 15)
            {
                wynik.FontSize = 16;
            }
            else if (wynik_temp.Length > 10)
            {
                wynik.FontSize = 24;
            }
            else
            {
                wynik.FontSize = 36;
            }

            if(rozpoczetaPotega || rozpoczetyPierwiastek)
            {
                tymczasowyStringDoPotegi = tymczasowyStringDoPotegi + ((Button)sender).Content.ToString();
                if (rozpoczetaPotega)
                {
                    wynik.Text = "pwr(" + tymczasowaDoPotegi1 + ","+ tymczasowyStringDoPotegi + ")";
                }
                else
                {
                    wynik.Text = "sqrt(" + tymczasowaDoPotegi1 + "," + tymczasowyStringDoPotegi + ")";
                }
                return;
            }

            if(((Button)sender).Content.ToString() == "," && wynik_temp == "" || ((Button)sender).Content.ToString() == "," && wynik_temp == "w" || ((Button)sender).Content.ToString() == "," && ostatnieDzialanie)
            {
                return;
            }

            if (ostatnieRownaSie)
            {
                wynik_temp = "";
                ostatnieRownaSie=false;
                listaDzialan.Clear();
                listaZmiennych.Clear();
            }

            if (ostatnieDzialanie)
            {
                if(listaDzialan[listaDzialan.Count -1] == "/" && ((Button)sender).Content.ToString() == "0")
                {
                    wynik.Text = "nie można";
                }
                else
                {
                    wynik_temp = "";
                    ostatnieDzialanie = false;

                    wynik_temp += ((Button)sender).Content.ToString();
                    wynik.Text = wynik_temp;

                    buforOstatniaZmienna = double.Parse(wynik_temp);
                }
            }
            else
            {
                wynik_temp += ((Button)sender).Content.ToString();
                wynik.Text = wynik_temp;

                if (wynik_temp == "671")
                {
                    wynik.Text = "kocham cie";
                }
                
                buforOstatniaZmienna = double.Parse(wynik_temp);
            }
        }

        private void dzialanie_Click(object sender, RoutedEventArgs e)
        {
            wynik.FontSize = 36;
            if (rozpoczetaPotega || rozpoczetyPierwiastek)
            {
                if (tymczasowyStringDoPotegi == "")
                {
                    return;
                }
                else
                {
                    if (rozpoczetyPierwiastek)
                    {
                        tymczasowaDoPotegi2 = double.Parse(tymczasowyStringDoPotegi);
                        wynik_temp = (Math.Pow(tymczasowaDoPotegi1, 1 / tymczasowaDoPotegi2)).ToString();
                        wynik.Text = wynik_temp;
                        tymczasowaDoPotegi1 = 0;
                        tymczasowaDoPotegi2 = 0;
                        tymczasowyStringDoPotegi = "";
                        rozpoczetyPierwiastek = false;
                        rozpoczetaPotega = false;
                    }
                    if (rozpoczetaPotega)
                    {
                        tymczasowaDoPotegi2 = double.Parse(tymczasowyStringDoPotegi);
                        wynik_temp = (Math.Pow(tymczasowaDoPotegi1, tymczasowaDoPotegi2)).ToString();
                        wynik.Text = wynik_temp;
                        tymczasowaDoPotegi1 = 0;
                        tymczasowaDoPotegi2 = 0;
                        tymczasowyStringDoPotegi = "";
                        rozpoczetyPierwiastek = false;
                        rozpoczetaPotega = false;
                    }
                }
            }
            else
            {
                tymczasowaDoPotegi1 = 0;
                tymczasowaDoPotegi2 = 0;
                tymczasowyStringDoPotegi = "";
                rozpoczetyPierwiastek = false;
                rozpoczetaPotega = false;
            }

            if (!ostatnieDzialanie && wynik_temp != "")
            {   
                if(wynik_temp != "w")
                {
                    listaZmiennych.Add(double.Parse(wynik_temp));
                }
                wynik_temp = "";
                listaDzialan.Add(((Button)sender).Content.ToString());
                wynik_temp = ((Button)sender).Content.ToString();
                wynik.Text = wynik_temp;
                ostatnieDzialanie = true;
                ostatnieRownaSie = false;
                buforOstatnieDzialanie = wynik_temp;
                wypiszListeDzialan();
                wypiszListeZmiennych();
            }
        }

        private void wynik_Click(object sender, RoutedEventArgs e)
        {

            if (rozpoczetaPotega && tymczasowyStringDoPotegi != "" || rozpoczetyPierwiastek && tymczasowyStringDoPotegi != "")
            {
                if (rozpoczetyPierwiastek)
                {
                    tymczasowaDoPotegi2 = double.Parse(tymczasowyStringDoPotegi);
                    wynik_temp = (Math.Pow(tymczasowaDoPotegi1, 1 / tymczasowaDoPotegi2)).ToString();
                    wynik.Text = wynik_temp;
                    tymczasowaDoPotegi1 = 0;
                    tymczasowaDoPotegi2 = 0;
                    tymczasowyStringDoPotegi = "";
                    rozpoczetyPierwiastek = false;
                    rozpoczetaPotega = false;
                }
                if (rozpoczetaPotega)
                {
                    tymczasowaDoPotegi2 = double.Parse(tymczasowyStringDoPotegi);
                    wynik_temp = (Math.Pow(tymczasowaDoPotegi1, tymczasowaDoPotegi2)).ToString();
                    wynik.Text = wynik_temp;
                    tymczasowaDoPotegi1 = 0;
                    tymczasowaDoPotegi2 = 0;
                    tymczasowyStringDoPotegi = "";
                    rozpoczetyPierwiastek = false;
                    rozpoczetaPotega = false;
                }
            }
            else
            {
                tymczasowaDoPotegi1 = 0;
                tymczasowaDoPotegi2 = 0;
                tymczasowyStringDoPotegi = "";
                rozpoczetyPierwiastek = false;
                rozpoczetaPotega = false;
            }

            if (wynik_temp == "")
            {
                return;
            }
            if (listaZmiennych.Count() < 1)
            {
                listaZmiennych.Add(double.Parse(wynik_temp));
            }

            double sumaKoncowa = listaZmiennych[0];

            if (ostatnieDzialanie)
            {
                listaDzialan.RemoveAt(listaDzialan.Count() - 1);
            }

            if (ostatnieRownaSie)
            {
                if(buforOstatnieDzialanie == "+")
                {
                    sumaKoncowa = sumaKoncowa + buforOstatniaZmienna;
                }
                if(buforOstatnieDzialanie == "-")
                {
                    sumaKoncowa = sumaKoncowa - buforOstatniaZmienna;
                }
                if(buforOstatnieDzialanie == "*")
                {
                    sumaKoncowa = sumaKoncowa * buforOstatniaZmienna;
                }
                if(buforOstatnieDzialanie == "/")
                {
                    sumaKoncowa = sumaKoncowa / buforOstatniaZmienna;
                }

                wynik.Text = sumaKoncowa.ToString();
                listaZmiennych.Clear();
                listaDzialan.Clear();
                listaZmiennych.Add(sumaKoncowa);
                ostatnieDzialanie = false;
                wynik_temp = "w";
                ostatnieRownaSie = true;

                wypiszListeDzialan();
                wypiszListeZmiennych();
            }
            else
            {
                if (!ostatnieDzialanie)
                {
                    listaZmiennych.Add(double.Parse(wynik_temp));
                }
                listaDzialan.Add(((Button)sender).Content.ToString());


                for (int i = 1; i < listaZmiennych.Count(); i++)
                {
                    if (listaDzialan[i - 1] == "+")
                    {
                        sumaKoncowa = sumaKoncowa + listaZmiennych[i];
                    }
                    if (listaDzialan[i - 1] == "-")
                    {
                        sumaKoncowa = sumaKoncowa - listaZmiennych[i];
                    }
                    if (listaDzialan[i - 1] == "*")
                    {
                        sumaKoncowa = sumaKoncowa * listaZmiennych[i];
                    }
                    if (listaDzialan[i - 1] == "/")
                    {
                        sumaKoncowa = sumaKoncowa / listaZmiennych[i];
                    }
                }

                wynik.Text = sumaKoncowa.ToString();
                listaZmiennych.Clear();
                listaDzialan.Clear();
                listaZmiennych.Add(sumaKoncowa);
                ostatnieDzialanie = false;
                wynik_temp = "w";
                ostatnieRownaSie = true;

                wypiszListeDzialan();
                wypiszListeZmiennych();
            }

    
        }



        public void wypiszListeZmiennych() 
        {
            string aktualne = "";
            for(int i = 0; i < listaZmiennych.Count(); i++)
            {
                aktualne += "[" + i.ToString() + "] " + listaZmiennych[i].ToString() + ", ";
            }
            textblock1.Text = aktualne;
        }

        public void wypiszListeDzialan()
        {
            string aktualne = "";
            for (int i = 0; i < listaDzialan.Count(); i++)
            {
                aktualne += "[" + i.ToString() + "] " + listaDzialan[i].ToString() + ", ";
            }

            textblock2.Text = aktualne;
        }

        private void zmienZnak_Click(object sender, RoutedEventArgs e)
        {
            if (rozpoczetaPotega && tymczasowyStringDoPotegi != "" || rozpoczetyPierwiastek && tymczasowyStringDoPotegi != "")
            {
                if (tymczasowyStringDoPotegi.Substring(0, 1) == "-")
                {
                    tymczasowyStringDoPotegi = tymczasowyStringDoPotegi.Substring(1, ((tymczasowyStringDoPotegi.Length) - 1));
                    if (rozpoczetaPotega)
                    {
                        wynik.Text = "pwr(" + tymczasowaDoPotegi1 + "," + tymczasowyStringDoPotegi + ")";
                    }
                    else
                    {
                        wynik.Text = "sqrt(" + tymczasowaDoPotegi1 + "," + tymczasowyStringDoPotegi + ")";
                    }
                    return;
                }
                else
                {
                    tymczasowyStringDoPotegi = '-' + tymczasowyStringDoPotegi;
                    wynik.Text = wynik_temp;
                    if (rozpoczetaPotega)
                    {
                        wynik.Text = "pwr(" + tymczasowaDoPotegi1 + "," + tymczasowyStringDoPotegi + ")";
                    }
                    else
                    {
                        wynik.Text = "sqrt(" + tymczasowaDoPotegi1 + "," + tymczasowyStringDoPotegi + ")";
                    }
                    return;
                }
            }
            else if (rozpoczetaPotega && tymczasowyStringDoPotegi == "" || rozpoczetyPierwiastek && tymczasowyStringDoPotegi == "")
            {
                return;
            }

            if(wynik_temp != "" && !ostatnieDzialanie && wynik_temp != "w" && wynik_temp != "0")
            {
                if (wynik_temp.Substring(0,1) == "-")
                {
                    wynik_temp = wynik_temp.Substring(1, ((wynik_temp.Length) -1));
                    wynik.Text = wynik_temp;
                }
                else
                {
                    wynik_temp = '-' + wynik_temp;
                    wynik.Text = wynik_temp;
                }
            }
            else if(wynik_temp == "w" && listaZmiennych[0] != 0)
            {
                string nowazmienna = listaZmiennych[0].ToString();

                if (nowazmienna.Substring(0, 1) == "-")
                {
                    listaZmiennych[0] = double.Parse(nowazmienna.Substring(1, ((nowazmienna.Length) - 1)));
                    wynik.Text = listaZmiennych[0].ToString();
                }
                else
                {
                    listaZmiennych[0] = double.Parse('-' + nowazmienna);
                    wynik.Text = listaZmiennych[0].ToString();
                }
            }
        }

        private void kasuj_Click(object sender, RoutedEventArgs e)
        {
            listaZmiennych.Clear();
            listaDzialan.Clear();
            ostatnieDzialanie = false;
            wynik_temp = "";
            wynik.Text = "0";
            tymczasowyStringDoPotegi = "";
            tymczasowaDoPotegi1 = 0;
            tymczasowaDoPotegi2 = 0;
            rozpoczetaPotega = false;
            rozpoczetyPierwiastek = false;
            wynik.FontSize = 36;
            wypiszListeDzialan();
            wypiszListeZmiennych();
        }

        private void potega_Click(object sender, RoutedEventArgs e)
        {

            if(wynik_temp != "" && wynik_temp != "w" && !ostatnieDzialanie)
            {
                if (((Button)sender).Content.ToString() == "pwr")
                {
                    if (rozpoczetaPotega)
                    {
                        tymczasowaDoPotegi2 = double.Parse(tymczasowyStringDoPotegi);
                        wynik_temp = (Math.Pow(tymczasowaDoPotegi1, tymczasowaDoPotegi2)).ToString();
                        wynik.Text = wynik_temp;
                        return;
                    }

                    tymczasowaDoPotegi1 = double.Parse(wynik_temp);
                    wynik.Text = "pwr(" + tymczasowaDoPotegi1 + ", )";
                    rozpoczetaPotega = true;
                }
                else
                {
                    if (rozpoczetyPierwiastek)
                    {
                        tymczasowaDoPotegi2 = double.Parse(tymczasowyStringDoPotegi);
                        wynik_temp = (Math.Pow(tymczasowaDoPotegi1, 1/tymczasowaDoPotegi2)).ToString();
                        wynik.Text = wynik_temp;
                        return;
                    }

                    tymczasowaDoPotegi1 = double.Parse(wynik_temp);
                    wynik.Text = "sqrt(" + tymczasowaDoPotegi1 + ", )";
                    rozpoczetyPierwiastek = true;
                }
            }
        }
    }
}
