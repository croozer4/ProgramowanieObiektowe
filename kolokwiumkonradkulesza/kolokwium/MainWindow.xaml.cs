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
using System.Xml.Serialization;
using System.IO;


namespace kolokwium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Pies
    {
        public string Imie { get; set; }
        public string Rasa { get; set; }

        public Pies()
        {
            Imie = "nie wiadomo";
            Rasa = "nie wiadomo";
        }

        public Pies(string imie, string rasa)
        {
            Imie = imie;
            Rasa = rasa;
        }
    }
    public class Hodowca
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string StronaInternetowa { get; set; }
        public int Wiek { get; set; }
        public List<Pies> listaPsów { get; set; }

        public Hodowca()
        {
            Imie = "nie wiadomo";
            Nazwisko = "nie wiadomo";
            StronaInternetowa = "brak";
            Wiek = 0;
            listaPsów = new List<Pies>();
        }

        public Hodowca(string imie, string nazwisko, string strona, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            StronaInternetowa = strona;
            Wiek = wiek;
        }
    }

    public partial class MainWindow : Window
    {

        public List<Hodowca> listaHodowców { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            listaHodowców = new List<Hodowca>()
            {
                new Hodowca(){Imie="Jan", Nazwisko="Testowy", StronaInternetowa="jantestowy.pl", Wiek=35},
                new Hodowca(){Imie="Konrad", Nazwisko="Testowy", StronaInternetowa="konradtestowy.pl", Wiek=22},
                new Hodowca(){Imie="Kuba", Nazwisko="Testowy", StronaInternetowa="kubatestowy.pl", Wiek=21},
            };

            listaHodowców[0].listaPsów.Add(new Pies("Burek", "Pudel"));
            listaHodowców[0].listaPsów.Add(new Pies("Reks", "Sznaucer"));
            listaHodowców[1].listaPsów.Add(new Pies("Azor", "Golden Retriever"));

            dgListaHodowcow.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Imie") });
            dgListaHodowcow.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
            dgListaHodowcow.Columns.Add(new DataGridTextColumn() { Header = "Strona internetowa", Binding = new Binding("StronaInternetowa") });
            dgListaHodowcow.Columns.Add(new DataGridTextColumn() { Header = "Wiek", Binding = new Binding("Wiek") });

            dgListaHodowcow.AutoGenerateColumns = false;
            dgListaHodowcow.ItemsSource = listaHodowców;
            dgListaHodowcow.IsReadOnly = true;
        }

        
        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            var dodajHodowce = new DodajHodowce();
            if(dodajHodowce.ShowDialog() == true)
            {
                listaHodowców.Add(dodajHodowce.hodowca);
            }
            dgListaHodowcow.Items.Refresh();
        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaHodowcow.SelectedItem is Hodowca)
            {
                listaHodowców.Remove((Hodowca)dgListaHodowcow.SelectedItem);
                dgListaHodowcow.Items.Refresh();
            }
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemZapiszXML_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog d = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "hodowcy",
                DefaultExt = ".xml",
                Filter = "XML documents (.xml)|*.xml"
            };

            if (d.ShowDialog() == true)
            {
                /*using (FileStream fs = new FileStream(d.FileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var s in list)
                        {
                            sw.WriteLine(s.Imie);
                            sw.WriteLine(s.Nazwisko);
                            sw.WriteLine(s.NumerIndeksu);
                            sw.WriteLine(s.Wydzial);
                            sw.WriteLine(s.ListaOcen.Count);
                            foreach (var o in s.ListaOcen)
                            {
                                sw.WriteLine(o.Przedmiot);
                                sw.WriteLine(o.Wartosc);
                            }
                        }
                    }
                }*/

                using (FileStream fs = new FileStream(d.FileName, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Hodowca>));
                    serializer.Serialize(fs, listaHodowców);
                }
            }
        }

        private void MenuItemZapiszTXT_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog d = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "hodowcy",
                DefaultExt = ".txt",
                Filter = "TXT documents (.txt)|*.txt"
            };

            if (d.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(d.FileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {

                        foreach (var h in listaHodowców)
                        {
                            sw.WriteLine(h.Imie);
                            sw.WriteLine(h.Nazwisko);
                            sw.WriteLine(h.StronaInternetowa);
                            sw.WriteLine(h.Wiek);
                            sw.WriteLine(h.listaPsów.Count);
                            foreach(var p in h.listaPsów)
                            {
                                sw.WriteLine(p.Imie);
                                sw.WriteLine(p.Rasa);
                            }
                        }
                    }
                }
            }
        }

        //wczytywanie

        private void MenuItemWczytajXML_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog d = new Microsoft.Win32.OpenFileDialog()
            {
                FileName = "hodowcy",
                DefaultExt = ".xml",
                Filter = "XML documents (.xml)|*.xml"
            };

            if (d.ShowDialog() == true)
            {
                try
                {
                    listaHodowców.Clear();
                    using (FileStream fs = new FileStream(d.FileName, FileMode.Open))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(List<Hodowca>));
                        listaHodowców = (List<Hodowca>)xs.Deserialize(fs);
                    }

                    /*using (FileStream fs = new FileStream(d.FileName, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (!sr.EndOfStream)
                            {
                                Student s = new Student();
                                s.Imie = sr.ReadLine();
                                s.Nazwisko = sr.ReadLine();
                                s.NumerIndeksu = int.Parse(sr.ReadLine());
                                s.Wydzial = sr.ReadLine();
                                int liczbaOcen = int.Parse(sr.ReadLine());
                                for (int i = 0; i < liczbaOcen; i++)
                                {
                                    var o = new Ocena();
                                    o.Przedmiot = sr.ReadLine();
                                    o.Wartosc = int.Parse(sr.ReadLine());
                                    s.ListaOcen.Add(o);
                                }
                                list.Add(s);
                            }
                        }
                    }*/

                    dgListaHodowcow.ItemsSource = listaHodowców;
                    dgListaHodowcow.Items.Refresh();

                    MessageBox.Show("Wczytano plik XML");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd odczytu pliku XML");
                }
            }
        }
        private void MenuItemWczytajTXT_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog d = new Microsoft.Win32.OpenFileDialog()
            {
                FileName = "hodowcy",
                DefaultExt = ".txt",
                Filter = "TXT documents (.txt)|*.txt"
            };

            if (d.ShowDialog() == true)
            {
                try
                {
                    listaHodowców.Clear();
                    using (FileStream fs = new FileStream(d.FileName, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (!sr.EndOfStream)
                            {

                                Hodowca h = new Hodowca();
                                h.Imie = sr.ReadLine();
                                h.Nazwisko = sr.ReadLine();
                                h.StronaInternetowa = sr.ReadLine();
                                h.Wiek = int.Parse(sr.ReadLine());
                                int liczbaPsow = int.Parse(sr.ReadLine());

                                for(int i = 0; i < liczbaPsow; i++)
                                {
                                    var p = new Pies();
                                    p.Imie = sr.ReadLine();
                                    p.Rasa = sr.ReadLine();
                                    h.listaPsów.Add(p);
                                }
                                listaHodowców.Add(h);
                            }
                        }
                    }

                    dgListaHodowcow.ItemsSource = listaHodowców;
                    dgListaHodowcow.Items.Refresh();

                    MessageBox.Show("Wczytano plik XML");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd odczytu pliku XML");
                }
            }
        }        
    }
}
