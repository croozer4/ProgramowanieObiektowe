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

namespace lab8zadanie1
{
    /// <summary>
    /// Logika interakcji dla klasy OcenaWindow.xaml
    /// </summary>
    /// 

    public partial class OcenaWindow : Window
    {
        List<Ocena> oceny;
        public Ocena ocenaDoDodania;
        public Student student;
        public OcenaWindow(Student student = null)
        {
            InitializeComponent();

            //bindowanie danych: krok 1 (w przypadku usunięcia tego kroku należy usunąć krok 3)
            dgOceny.Columns.Add(new DataGridTextColumn() { Header = "Nazwa przedmiotu", Binding = new Binding("Przedmiot") });
            dgOceny.Columns.Add(new DataGridTextColumn() { Header = "Wartość", Binding = new Binding("Wartosc") });
            //itd.
            //bindowanie danych: krok 2
            dgOceny.AutoGenerateColumns = false; //nie tworzy kolumn automatycznie, lecz zgodnie z ww. definicją
                                                 //bindowanie danych: krok 3
            dgOceny.ItemsSource = student.ListaOcen;
            oceny = student.ListaOcen;
            //bindowanie danych: krok 4 (konfiguracja: wyłączenie możliwości wprowadzania danych)
            dgOceny.IsReadOnly = true;

            this.student = student;
        }

        private void dodajOcene(object sender, RoutedEventArgs e)
        {       
            var dodajOceneStudenta = new DodajOceneWindow();
            if (dodajOceneStudenta.ShowDialog() == true)
            {
                student.ListaOcen.Add(dodajOceneStudenta.ocenaDoDodania);
            }
            dgOceny.Items.Refresh();
        }

    }
}
