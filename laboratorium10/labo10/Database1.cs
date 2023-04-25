using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo10
{
    public class Samochód
    {
        public int IdSamochodu { get; set; }
        public int IdWlasciciela { get; set; }
        public string Informacja { get; set; } = "";
        public string Marka { get; set; } = "";
        public string Model { get; set; } = "";
        public string NumerRejestracyjny { get; set; } = "";
    }
    
    public class Właściciel
    {
        public int IdWlasciciela { get; set; }
        public string Imie { get; set; } = "";
        public string Nazwisko { get; set; } = "";
        public string Informacja { get; set; } = "";
    }
    
    public class Database1
    {

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Konrad\Desktop\pliki na studia\Semestr 4\Programowanie obiektowe\laboratorium10\labo10\Database1.mdf;Integrated Security=True";
        
        public int SP_Samochody_delete(Samochód s)
        {
            
        }
        
    }
}
