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
    /// <summary>
    /// Logika interakcji dla klasy StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student student;

        public bool edycja;
        public StudentWindow(Student student = null)
        {
            InitializeComponent();

            if(student != null)
            {
                tbImie.Text = student.Imie;
                tbNazwisko.Text = student.Nazwisko;
                tbNumerIndeksu.Text = student.NumerIndeksu.ToString();
                tbWydzial.Text = student.Wydzial;
                edycja = true;
            }
            else //if(student == null)
            {
                this.student = new Student();
                edycja = false;
            }
            this.student = student ?? new Student();
        }

        private void potwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (
                !Regex.IsMatch(tbImie.Text, @"^\p{Lu}\p{Ll}{1,20}$") ||
                !Regex.IsMatch(tbNazwisko.Text, @"^\p{Lu}\p{Ll}{1,20}$") ||
                !Regex.IsMatch(tbNumerIndeksu.Text, @"^[0-9]{4,10}$") ||
                !Regex.IsMatch(tbWydzial.Text, @"^[\p{Lu}|\p{Ll}]{1,12}$")
             )
            {
                MessageBox.Show("Wprowadzone dane są niepoprawne.");
                return;
            };
            student.Imie = tbImie.Text;
            student.Nazwisko = tbNazwisko.Text;
            student.NumerIndeksu = int.Parse(tbNumerIndeksu.Text);
            student.Wydzial = tbWydzial.Text;
            //...

            DialogResult = true; //można zamknąć okno i pograć dane z w. Student
        }
    }
}
