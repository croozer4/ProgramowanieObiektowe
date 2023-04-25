using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace zadanie3lab2
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

        public class Ocena
        {
            protected string nazwaPrzedmiotu;
            protected string data;
            protected double wartosc;

            public Ocena(string nazwaPrzemiotu, string data, double wartosc)
            {
                this.nazwaPrzedmiotu = nazwaPrzemiotu;
                this.data = data;
                this.wartosc = wartosc;
            }

            public string NazwaPrzedmiotu
            {
                get { return nazwaPrzedmiotu; }
                set { nazwaPrzedmiotu = value; }
            }

            public string Data
            {
                get { return data; }
                set { data = value; }
            }

            public double Wartosc
            {
                get { return wartosc; }
                set { wartosc = value; }
            }

            public void WypiszInfo()
            {
                Console.WriteLine("Informacje o ocenie");
                Console.WriteLine("Nazwa przedmiotu: " + nazwaPrzedmiotu);
                Console.WriteLine("Data wpisania do dziennika: " + data);
                Console.WriteLine("Wartość oceny: " + wartosc);
                Console.WriteLine("\n");
            }
        }

        public class Student : Osoba
        {
            private int rok;
            private int grupa;
            private int nrIndeksu;
            private List<Ocena> oceny;

            public Student() : base()
            {
                this.rok = 0;
                this.grupa = 0;
                this.nrIndeksu = 0;
                this.oceny = new List<Ocena>();
            }

            public Student(string imie, string nazwisko, string dataUrodzenia, int rok, int grupa, int nrIndeksu) : base(imie, nazwisko, dataUrodzenia)
            {
                this.rok = rok;
                this.grupa = grupa;
                this.nrIndeksu = nrIndeksu;
                this.oceny = new List<Ocena>();
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
                this.WypiszOceny();
                Console.WriteLine("\n");
            }

            public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
            {
                Ocena o = new Ocena(nazwaPrzedmiotu, data, wartosc);
                oceny.Add(o);
                Console.WriteLine("Dodano ocenę " + wartosc + " z przedmiotu " + nazwaPrzedmiotu + " w dniu " + data + "\n");
            }

            public void WypiszOceny()
            {
                Console.WriteLine("Oceny studenta " + imie + " " + nazwisko + "\n");
                for (int i = 0; i < oceny.Count; i++)
                {
                    oceny[i].WypiszInfo();
                }
            }

            public void WypiszOceny(string nazwaPrzedmiotu)
            {
                Console.WriteLine("Oceny studenta " + imie + " " + nazwisko + " z przedmiotu " + nazwaPrzedmiotu + "\n");

                for (int i = 0; i < oceny.Count; i++)
                {
                    if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
                    {
                        oceny[i].WypiszInfo();
                    }
                }
            }

            public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
            {
                Console.WriteLine("Usuwanie oceny studenta " + imie + " " + nazwisko + "\n");

                for (int i = 0; i < oceny.Count; i++)
                {
                    if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu && oceny[i].Data == data && oceny[i].Wartosc == wartosc)
                    {
                        Console.WriteLine("Usuwam ocene: ");
                        oceny[i].WypiszInfo();
                        oceny.RemoveAt(i);
                        i--;
                    }
                }
            }

            public void UsunOceny()
            {
                Console.WriteLine("Usuwanie wszystkich ocen studenta " + imie + " " + nazwisko + "\n");

                oceny.Clear();
            }

            public void UsunOceny(string nazwaPrzedmiotu)
            {
                Console.WriteLine("Usuwam oceny z przedmiotu: " + nazwaPrzedmiotu);
                for (int i = 0; i < oceny.Count; i++)
                {
                    if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
                    {
                        oceny.RemoveAt(i);
                        i--;
                    }
                }
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

            public virtual void StrzelGola()
            {
                liczbaGoli++;
                Console.WriteLine("Pilkarz strzelil gola, liczba goli:" + liczbaGoli);
                Console.WriteLine("\n");
            }
        }

        public class PilkarzReczny : Pilkarz
        {

            public PilkarzReczny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) : base(imie, nazwisko, dataUrodzenia, pozycja, klub) { }

            public override void StrzelGola()
            {
                Console.WriteLine("Reczny strzelił gola");
                base.StrzelGola();
            }
        }

        public class PilkarzNozny : Pilkarz
        {
            public PilkarzNozny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) : base(imie, nazwisko, dataUrodzenia, pozycja, klub) { }

            public override void StrzelGola()
            {
                Console.WriteLine("Nożny strzelił gola");
                base.StrzelGola();
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

            Console.WriteLine("\n ZADANIE 2 \n");

            ((Student)o2).DodajOcene("PO", "20.02.2011", 5.0);
            ((Student)o2).DodajOcene("Bazy danych", "13.02.2011", 4.0);

            o2.WypiszInfo();

            s.DodajOcene("Bazy danych", "01.05.2011", 5.0);
            s.DodajOcene("AWWW", "11.05.2011", 5.0);
            s.DodajOcene("AWWW", "02.04.2011", 4.5);

            s.WypiszInfo();

            s.UsunOcene("AWWW", "02.04.2011", 4.5);

            s.WypiszInfo();

            s.DodajOcene("AWWW", "02.04.2011", 4.5);
            s.UsunOceny("AWWW");

            s.WypiszInfo();

            s.DodajOcene("AWWW", "02.04.2011", 4.5);
            s.UsunOceny();

            s.WypiszInfo();

            Console.ReadKey();
        }
    }
}