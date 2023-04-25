using System;

namespace zadanie1lab2
{
    internal class Program
    {
        public class Osoba
        {
            protected string imie;
            protected string nazwisko;
            protected string dataUrodzenia;

            public Osoba()
            {
                this.imie = "nieznane";
                this.nazwisko = "nieznane";
                this.dataUrodzenia = "nieznana";
            }

            public Osoba(string imie, string nazwisko, string dataUrodzenia)
            {
                this.imie = imie;
                this.nazwisko = nazwisko;
                this.dataUrodzenia = dataUrodzenia;
            }

            public virtual void WypiszInfo()
            {
                Console.WriteLine("Informacje o osobie");
                Console.WriteLine("Imie: " + imie);
                Console.WriteLine("Nazwisko: " + nazwisko);
                Console.WriteLine("Data urodzenia: " + dataUrodzenia);
                Console.WriteLine("\n");
            }
        }

        public class Student : Osoba
        {
            private int rok;
            private int grupa;
            private int nrIndeksu;

            public Student() : base()
            {
                this.rok = 0;
                this.grupa = 0;
                this.nrIndeksu = 0;
            }

            public Student(string imie, string nazwisko, string dataUrodzenia, int rok, int grupa, int nrIndeksu) : base(imie, nazwisko, dataUrodzenia)
            {
                this.rok = rok;
                this.grupa = grupa;
                this.nrIndeksu = nrIndeksu;
            }

            public override void WypiszInfo()
            {
                Console.WriteLine("Informacje o studencie");
                Console.WriteLine("Imie: " + imie);
                Console.WriteLine("Nazwisko: " + nazwisko);
                Console.WriteLine("Data urodzenia: " + dataUrodzenia);
                Console.WriteLine("Rok: " + rok);
                Console.WriteLine("Grupa: " + grupa);
                Console.WriteLine("nrIndeksu: " + nrIndeksu);
                Console.WriteLine("\n");
            }
        }

        public class Pilkarz : Osoba
        {
            private string pozycja;
            private string klub;
            private int liczbaGoli = 0;

            public Pilkarz() : base()
            {
                this.pozycja = "nieznany";
                this.klub = "nieznany";
            }

            public Pilkarz(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) : base(imie, nazwisko, dataUrodzenia)
            {
                this.pozycja = pozycja;
                this.klub = klub;
            }

            public override void WypiszInfo()
            {
                Console.WriteLine("Informacje o pilkarzu");
                Console.WriteLine("Imie: " + imie);
                Console.WriteLine("Nazwisko: " + nazwisko);
                Console.WriteLine("Data urodzenia: " + dataUrodzenia);
                Console.WriteLine("Pozycja: " + pozycja);
                Console.WriteLine("Liczba goli: " + liczbaGoli);
                Console.WriteLine("Klub: " + klub);
                Console.WriteLine("\n");
            }

            public void StrzelGola()
            {
                liczbaGoli++;
                Console.WriteLine("Pilkarz strzelil gola, liczba goli:" + liczbaGoli);
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
            Osoba o = new Osoba("Adam", "Miś", "20.03.1980");
            Osoba o2 = new Student("Michał", "Kot", "13.04.1990", 2, 1, 12345);
            Osoba o3 = new Pilkarz("Mateusz", "Żbik", "10.08.1986", "obrońca", "FC Częstochowa");

            o.WypiszInfo();
            o2.WypiszInfo();
            o3.WypiszInfo();

            Student s = new Student("Krzysztof", "Jeż", "22.12.1990", 2, 5, 54321);
            Pilkarz p = new Pilkarz("Piotr", "Kos", "14.09.1984", "napastnik", "FC Politechnika");

            s.WypiszInfo();
            p.WypiszInfo();

            ((Pilkarz)o3).StrzelGola();
            p.StrzelGola();
            p.StrzelGola();

            o3.WypiszInfo();
            p.WypiszInfo();

            Console.ReadKey();
        }
    }
}