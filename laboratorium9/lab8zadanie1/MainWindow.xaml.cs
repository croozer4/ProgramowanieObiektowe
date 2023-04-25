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
using System.Xml.Serialization;

namespace lab8zadanie1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public class Ocena
    {
        public string Przedmiot { get; set; }
        public float Wartosc { get; set; }

        public Ocena()
        {
            Przedmiot = "nie podano";
            Wartosc = 0;
        }

        public Ocena(string przedmiot, float wartosc)
        {
            Przedmiot = przedmiot;
            Wartosc = wartosc;
        }
    }
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int NumerIndeksu { get; set; }
        public string Wydzial { get; set; }
        public List<Ocena> ListaOcen { get; set; } = new List<Ocena>();

        public Student()
        {
            Imie = "nie podano";
            Nazwisko = "nie podano";
            NumerIndeksu = 0;
            Wydzial = "nie podano";
        }

        public Student(string imie, string nazwisko, int numerIndeksu, string wydzial)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            NumerIndeksu = numerIndeksu;
            Wydzial = wydzial;
        }


    }
    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            list = new List<Student>()
            {
            new Student(){Nazwisko="Kowalski", Imie="Mateusz", NumerIndeksu = 123456, Wydzial = "Informatyka"},
            new Student(){Nazwisko="Nowak", Imie="Piotr", NumerIndeksu = 123457, Wydzial = "Informatyka"},


            };

            list[0].ListaOcen.Add(new Ocena("matematyka", 5));
            list[0].ListaOcen.Add(new Ocena("fizyka", 4));
            list[1].ListaOcen.Add(new Ocena("chemia", 3));
            list[1].ListaOcen.Add(new Ocena("biologia", 2));


            //bindowanie danych: krok 1 (w przypadku usunięcia tego kroku należy usunąć krok 3)
            dgStudenci.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Imie") });
            dgStudenci.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
            dgStudenci.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("NumerIndeksu") });
            dgStudenci.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Wydzial") });
            //itd.
            //bindowanie danych: krok 2
            dgStudenci.AutoGenerateColumns = false; //nie tworzy kolumn automatycznie, lecz zgodnie z ww. definicją
                                                    //bindowanie danych: krok 3
            dgStudenci.ItemsSource = list;
            //bindowanie danych: krok 4 (konfiguracja: wyłączenie możliwości wprowadzania danych)
            dgStudenci.IsReadOnly = true;

        }



        private void dodajStudenta_Click(object sender, RoutedEventArgs e)
        {
            var dodajStudenta = new StudentWindow((Student)dgStudenci.SelectedItem);

            var studentWybrany = (Student)dgStudenci.SelectedItem;

            if (dodajStudenta.ShowDialog() == true)
            {
                if (studentWybrany is null)
                {
                    list.Add(dodajStudenta.student);
                }
            }
            dgStudenci.Items.Refresh();
        }

        private void usunStudenta_Click(object sender, RoutedEventArgs e)
        {
            if (dgStudenci.SelectedItem is Student)
            {
                list.Remove((Student)dgStudenci.SelectedItem);
                dgStudenci.Items.Refresh();
            }

        }

        private void ocenyStudenta_Click(object sender, RoutedEventArgs e)
        {

            if (dgStudenci.SelectedItem is Student)
            {
                var ocenyStudenta = new OcenaWindow((Student)dgStudenci.SelectedItem);
                ocenyStudenta.ShowDialog();
            }

            dgStudenci.Items.Refresh();
        }

        private void MenuItemZapiszXML_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog d = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "studenci",
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                    serializer.Serialize(fs, list);
                }
            }
        }

        private void MenuItemZapiszTXT_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog d = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "studenci",
                DefaultExt = ".txt",
                Filter = "TXT documents (.txt)|*.txt"
            };

            if (d.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(d.FileName, FileMode.Create))
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
                } 
            }
        }

        //wczytywanie

        private void MenuItemWczytajXML_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog d = new Microsoft.Win32.OpenFileDialog()
            {
                FileName = "studenci",
                DefaultExt = ".xml",
                Filter = "XML documents (.xml)|*.xml"
            };

            if (d.ShowDialog() == true)
            {
                try
                {
                    list.Clear();
                    using (FileStream fs = new FileStream(d.FileName, FileMode.Open))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
                        list = (List<Student>)xs.Deserialize(fs);
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

                    dgStudenci.ItemsSource = list;
                    dgStudenci.Items.Refresh();

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
                FileName = "studenci",
                DefaultExt = ".txt",
                Filter = "TXT documents (.txt)|*.txt"
            };

            if (d.ShowDialog() == true)
            {
                try
                {
                    list.Clear();
                    using (FileStream fs = new FileStream(d.FileName, FileMode.Open))
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
                    }

                    dgStudenci.ItemsSource = list;
                    dgStudenci.Items.Refresh();

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
