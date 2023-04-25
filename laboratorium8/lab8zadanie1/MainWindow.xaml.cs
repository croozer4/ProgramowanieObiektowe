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
                if(studentWybrany is null)
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
    }
}
