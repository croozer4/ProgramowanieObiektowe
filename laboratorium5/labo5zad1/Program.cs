using System;
using System.Collections;
using System.Collections.Generic;

namespace labo5zad1
{
    internal class Program
    {

        public interface IWyświetlInfo
        {
            public virtual void WyświetlInfo()
            {
                Console.WriteLine("Wyświetl info");
            }
        }
        public class Osoba : IWyświetlInfo
        {
            public DateTime DataUrodzin { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }

            public Osoba()
            {
                DataUrodzin = DateTime.Now;
                Imie = "nie wiadomo";
                Nazwisko = "nie wiadomo";
            }

            public Osoba(string imie, string nazwisko, DateTime dataUrodzin)
            {
                Imie = imie;
                Nazwisko = nazwisko;
                DataUrodzin = dataUrodzin;
            }

            public override string ToString() {
                return Imie + " " + Nazwisko + DataUrodzin.ToString();
            }

            public void WyświetlInfo()
            {
                Console.WriteLine("Dane osoby:");
                Console.WriteLine("Imie: " + Imie);
                Console.WriteLine("Nazwisko: " + Nazwisko);
                Console.WriteLine("Data urodzin: " + DataUrodzin.ToString());
            }
        }

        public class Wykladowca : Osoba, IWyświetlInfo
        {
            string Stanowisko { get; set; }
            string TytulIStopien { get; set; }

            public override string ToString()
            {
                return base.ToString() + Stanowisko + TytulIStopien;
            }

            public Wykladowca() : base()
            {
                Stanowisko = "nie wiadomo";
                TytulIStopien = "nie wiadomo";
            }

            public Wykladowca(string imie, string nazwisko, DateTime dataUrodzin, string tytulIStopien, string stanowisko) : base(imie, nazwisko, dataUrodzin)
            {
                Stanowisko = stanowisko;
                TytulIStopien = tytulIStopien;
            }

            public new void WyświetlInfo()
            {
                base.WyświetlInfo();
                Console.WriteLine("Stanowisko: " + Stanowisko);
                Console.WriteLine("Tytul i stopien: " + TytulIStopien);
                Console.WriteLine();
            }
        }

        public class Przedmiot : IWyświetlInfo
        {
            public int LiczbaGodzin { get; set; }
            public string Nazwa { get; set; }
            public int Semestr { get; set; }
            public string Specjalizacja { get; set; }

            public Przedmiot(int liczbaGodzin, string nazwa, int semestr, string specjalizacja)
            {
                LiczbaGodzin = liczbaGodzin;
                Nazwa = nazwa;
                Semestr = semestr;
                Specjalizacja = specjalizacja;
            }

            public override string ToString()
            {
                return LiczbaGodzin + " " + Nazwa + " " + Semestr + " " + Specjalizacja;
            }

            public void WyświetlInfo()
            {
                Console.WriteLine("Infomacje o przedmiocie " + Nazwa);
                Console.WriteLine("Liczba godzin: " + LiczbaGodzin);
                Console.WriteLine("Semestr: " + Semestr);
                Console.WriteLine("Specjalizacja: " + Specjalizacja);
                Console.WriteLine();
            }
        }


        public class Student : Osoba, IWyświetlInfo
        {
            public int Grupa { get; set; }
            public int NumerIndeksu { get; set; }
            public IList<OcenaKońcowa> OcenyKońcowe { get; set; }
            public int Rok { get; set; }
            public string Specjalizacja { get; set; }

            public void DodajOcenę(OcenaKońcowa ocenaKońcowa)
            {
                OcenyKońcowe.Add(ocenaKońcowa);
            }

            public void DodajOcenę(Przedmiot przedmiot, double wartość, DateTime data)
            {
                OcenyKońcowe.Add(new OcenaKońcowa(przedmiot, wartość, data));
            }

            public Student()
            {
                Grupa = 0;
                NumerIndeksu = 0;
                OcenyKońcowe = new List<OcenaKońcowa>();
                Rok = 0;
                Specjalizacja = "nie wiadomo";
            }

            public Student(string imie, string nazwisko, DateTime dataUrodzin, int grupa, int numerIndeksu, string specjalizacja, int rok) : base(imie, nazwisko, dataUrodzin)
            {
                Grupa = grupa;
                NumerIndeksu = numerIndeksu;
                OcenyKońcowe = new List<OcenaKońcowa>();
                Specjalizacja = specjalizacja;
                Rok = rok;
            }

            public override string ToString()
            {
                return base.ToString() + " " + Grupa.ToString() + " " + NumerIndeksu.ToString() + " " + Specjalizacja + " " + Rok;
            }

            public bool UsuńOcenę(OcenaKońcowa ocenaKońcowa)
            {
                OcenyKońcowe.Remove(ocenaKońcowa);
                return true;
            }

            public void UsuńOceny()
            {
                for (int i = 0; i < OcenyKońcowe.Count(); i++)
                {
                    OcenyKońcowe.RemoveAt(i);
                }
            }

            public new void WyświetlInfo()
            {
                Console.WriteLine("-----Wyświetlam dane dla Studenta-----");
                base.WyświetlInfo();
                Console.WriteLine("Grupa: " + Grupa);
                Console.WriteLine("Numer indeksu: " + NumerIndeksu);
                Console.WriteLine("Rok: " + Rok);
                Console.WriteLine("Specjalizacja: " + Specjalizacja);
                Console.WriteLine("Oceny końcowe: \n");
                WyświetlOceny();
                Console.WriteLine("-----koniec-----");
                Console.WriteLine();
            }

            public void WyświetlOceny()
            {
                for (int i = 0; i < OcenyKońcowe.Count(); i++)
                {
                    OcenyKońcowe[i].WyswietlInfo();
                }
            }
        }

        public class OcenaKońcowa : IWyświetlInfo
        {
            public DateTime Data { get; set; }
            public Przedmiot Przedmiot { get; set; }
            public double Wartość { get; set; }

            public OcenaKońcowa(Przedmiot przedmiot, double wartość, DateTime data)
            {
                Data = data;
                Przedmiot = przedmiot;
                Wartość = wartość;
            }

            public override string ToString()
            {
                return Data.ToString() + " " + Przedmiot.ToString() + " " + Wartość;
            }

            public void WyswietlInfo()
            {
                Console.WriteLine("Informacje o ocenie końcowej ");
                Console.WriteLine("Data wpisania: " + Data);
                Console.WriteLine("Przedmiot: " + Przedmiot.Nazwa);
                Console.WriteLine("Wartość: " + Wartość);
                Console.WriteLine();
            }
        }

        public class JednostkaOrganizacyjna : IWyświetlInfo
        {

            public string Adres { get; set; }
            public string Nazwa { get; set; }
            public IList<Wykladowca> Wykładowcy { get; set; }

            public void DodajWykładowcę(Wykladowca wykladowca)
            {
                Wykładowcy.Add(wykladowca);
            }

            public JednostkaOrganizacyjna()
            {
                Adres = "nie wiadomo";
                Nazwa = "nie wiadomo";
                Wykładowcy = new List<Wykladowca>();
            }

            public JednostkaOrganizacyjna(string nazwa, string adres, IList<Wykladowca> wykładowcy = null)
            {
                Adres = adres;
                Nazwa = nazwa;
                if (wykładowcy == null)
                {
                    Wykładowcy = new List<Wykladowca>();
                }
                else
                {
                    Wykładowcy = wykładowcy;
                }
            }

            public new string ToString()
            {
                return "Nazwa: " + Nazwa + "Adres: " + Adres;
            }

            public string ToString(bool czyWrazZWykładowcami)
            {
                if (czyWrazZWykładowcami)
                {

                    string doZwrocenia = this.ToString();

                    for(int i = 0; i < Wykładowcy.Count(); i++)
                    {
                        doZwrocenia += Wykładowcy[i].ToString();
                    }

                    return doZwrocenia;
                }
                else
                {
                    return this.ToString();
                }
            }

            public bool UsuńWykładowcę(string imie, string nazwisko)
            {
                for(int i = 0; i < Wykładowcy.Count(); i++)
                {
                    if(Wykładowcy[i].Imie == imie && Wykładowcy[i].Nazwisko == nazwisko)
                    {
                        Wykładowcy.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool UsuńWykładowcę(Wykladowca wykladowca)
            {
                Wykładowcy.Remove(wykladowca);
                return true;
            }

            public void WyświetlInfo()
            {
                Console.WriteLine("Wyświetlam info o jednostce organizacyjnej: ");
                Console.WriteLine("Adres: " + Adres);
                Console.WriteLine("Nazwa: " + Nazwa);
                Console.WriteLine("Wykładowcy: ");
                this.WyświetlWykładowców();
            }

            public void WyświetlWykładowców()
            {
                Console.WriteLine("Wyświetlam wykładowców: ");
                for (int i = 0; i < Wykładowcy.Count(); i++)
                {
                    Wykładowcy[i].WyświetlInfo();
                }
            }
        }

        public class Wydział : IWyświetlInfo
        {
            public Osoba Dziekan { get; set; }
            public IList<JednostkaOrganizacyjna> JednostkiOrganizacyjne { get; set; } = new List<JednostkaOrganizacyjna>();
            public string Nazwa { get; set; }
            public IList<Przedmiot> Przedmioty { get; set; } = new List<Przedmiot>();
            public IList<Student> Studenci { get; set; } = new List<Student>();
            public void DodajJednostkęOrganizacyjną(JednostkaOrganizacyjna jednostkaOrganizacyjna)
            {
                JednostkiOrganizacyjne.Add(jednostkaOrganizacyjna);
            }

            public void DodajPrzedmiot(Przedmiot przedmiot)
            {
                Przedmioty.Add(przedmiot);
            }

            public void DodajStudenta(Student student)
            {
                Studenci.Add(student);
            }

            public void DodajWykładowcę(Wykladowca wykladowca, JednostkaOrganizacyjna jednostkaOrganizacyjna)
            {
                jednostkaOrganizacyjna.Wykładowcy.Add(wykladowca);
            }

            public void PrzenieśWykładowcę(Wykladowca wykladowca, JednostkaOrganizacyjna jednostkaOrganizacyjnaStara, JednostkaOrganizacyjna jednostkaOrganizacyjnaNowa)
            {
                jednostkaOrganizacyjnaStara.Wykładowcy.Remove(wykladowca);
                jednostkaOrganizacyjnaNowa.Wykładowcy.Add(wykladowca); 
            }

            public new string ToString()
            {
                return "Dziekan: " + Dziekan + " Nazwa: " + Nazwa;
            }

            public bool UsuńJednostkęOrganizacyjną(JednostkaOrganizacyjna jednostkaOrganizacyjna)
            {
                JednostkiOrganizacyjne.Remove(jednostkaOrganizacyjna);
                return true;
            }
            
            public bool UsuńJednostkęOrganizacyjną(string nazwa, string adres)
            {
                for(int i = 0; i < JednostkiOrganizacyjne.Count(); i++)
                {
                    if(JednostkiOrganizacyjne[i].Nazwa == nazwa && JednostkiOrganizacyjne[i].Adres == adres)
                    {
                        JednostkiOrganizacyjne.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool UsuńPrzedmiot(int liczbaGodzin, string nazwa, int semestr, string specjalizacja)
            {
                for(int i = 0; i < Przedmioty.Count(); i++)
                {
                    if(Przedmioty[i].LiczbaGodzin == liczbaGodzin && Przedmioty[i].Nazwa == nazwa && Przedmioty[i].Semestr == semestr && Przedmioty[i].Specjalizacja == specjalizacja)
                    {
                        Przedmioty.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool UsuńPrzedmiot(Przedmiot przedmiot)
            {
                Przedmioty.Remove(przedmiot);
                return true;
            }

            public bool UsuńStudenta(int numerIndeksu)
            {
                for(int i = 0; i < Studenci.Count(); i++)
                {
                    if(Studenci[i].NumerIndeksu == numerIndeksu)
                    {
                        Studenci.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool UsuńStudenta(Student student)
            {
                Studenci.Remove(student);
                return true;
            }

            public Wydział(string nazwa, Osoba dziekan, IList<Student> studenci = null, IList<Przedmiot> przedmioty = null, IList<JednostkaOrganizacyjna> jednostkiOrganizacyjne = null)
            {
                Nazwa = nazwa;
                Dziekan = dziekan;

                
            }

            public void WyświetlInfo()
            {
                Console.WriteLine("Wyświetlam info wydziału: ");
                Console.WriteLine("Dziekan: " + Dziekan);
                Console.WriteLine("Nazwa: " + Nazwa);
            }

            public void WyświetlJednostkiOrganizacyjne()
            {
                Console.WriteLine("Wyświetlam info o jednostkach: ");
                for(int i = 0; i < JednostkiOrganizacyjne.Count(); i++)
                {
                    JednostkiOrganizacyjne[i].WyświetlInfo();
                }
            }

            public void WyświetlPrzedmioty()
            {
                Console.WriteLine("Wyświetlam info o przedmiotach: ");
                for (int i = 0; i < Przedmioty.Count(); i++)
                {
                    Przedmioty[i].WyświetlInfo();
                }
            }

            public void WyświetlStudentów()
            {
                Console.WriteLine("Wyświetlam info o studentach: ");
                for (int i = 0; i < Studenci.Count(); i++)
                {
                    Studenci[i].WyświetlInfo();
                }
            }

            public void ZmieńDziekana(Osoba dziekan)
            {
                Dziekan = dziekan;
            }
        }
        public static void Main() {

            //-------------------------tworzenie obiektów-----------------------------

            Student student1 = new Student("Konrad", "Kulesza", DateTime.Parse("01/01/2000"), 1, 111111, "aplikacje internetowe", 2);
            Student student2 = new Student("Marcel", "Wójcik", DateTime.Parse("01/01/2000"), 1, 111111, "aplikacje internetowe", 2);
            Student student3 = new Student("Maciej", "Rataj", DateTime.Parse("01/01/2000"), 1, 111111, "aplikacje internetowe", 2);

            Wykladowca wykladowca1 = new Wykladowca("Tomasz", "Testowy", DateTime.Parse("01/01/2000"), "Profesor", "Wykładowca");
            Wykladowca wykladowca2 = new Wykladowca("Andrzej", "Testowy", DateTime.Parse("01/01/2000"), "Profesor", "Wykładowca");
            Wykladowca wykladowca3 = new Wykladowca("Krzysztof", "Testowy", DateTime.Parse("01/01/2000"), "Profesor", "Wykładowca");

            Przedmiot przedmiot1 = new Przedmiot(1, "Matematyka", 1, "aplikacje internetowe");
            Przedmiot przedmiot2 = new Przedmiot(1, "Polski", 1, "aplikacje internetowe");
            Przedmiot przedmiot3 = new Przedmiot(1, "Angielski", 1, "aplikacje internetowe");

            OcenaKońcowa ocenaKońcowa1 = new OcenaKońcowa(przedmiot1, 3, DateTime.Parse("01/01/2000"));
            OcenaKońcowa ocenaKońcowa2 = new OcenaKońcowa(przedmiot2, 3, DateTime.Parse("01/01/2000"));
            OcenaKońcowa ocenaKońcowa3 = new OcenaKońcowa(przedmiot3, 3, DateTime.Parse("01/01/2000"));

            Wydział wydział1 = new Wydział("Gier i zabaw", student2);
            Wydział wydział2 = new Wydział("Nauka z depresją", student3);
            Wydział wydział3 = new Wydział("Budownictwa", wykladowca1);

            JednostkaOrganizacyjna jednostka1 = new JednostkaOrganizacyjna("jednostka specjalna", "tajne", null);
            JednostkaOrganizacyjna jednostka2 = new JednostkaOrganizacyjna("jednostka niespecjalna", "Radom", null);

            //----------------------------kod testowy-------------------------------

            student1.DodajOcenę(ocenaKońcowa1);
            student2.DodajOcenę(ocenaKońcowa2);
            student3.DodajOcenę(ocenaKońcowa1);
            student3.DodajOcenę(ocenaKońcowa3);

            Console.WriteLine("----------Studenci po dodaniu ocen końcowych----------");
            Console.WriteLine();

            student1.WyświetlInfo();
            student2.WyświetlInfo();
            student3.WyświetlInfo();

            jednostka1.DodajWykładowcę(wykladowca1);
            jednostka1.DodajWykładowcę(wykladowca2);
            jednostka2.DodajWykładowcę(wykladowca3);


            Console.WriteLine("----------Jednostki po dodaniu wykładowców i wydziału----------");
            Console.WriteLine();

            jednostka1.WyświetlInfo();
            jednostka2.WyświetlInfo();

            wydział1.DodajJednostkęOrganizacyjną(jednostka1);
            wydział1.DodajJednostkęOrganizacyjną(jednostka2);
            wydział2.DodajJednostkęOrganizacyjną(jednostka2);
            wydział3.DodajJednostkęOrganizacyjną(jednostka2);

            wydział1.DodajStudenta(student1);
            wydział2.DodajStudenta(student2);
            wydział3.DodajStudenta(student3);

            wydział1.DodajPrzedmiot(przedmiot1);
            wydział2.DodajPrzedmiot(przedmiot2);
            wydział3.DodajPrzedmiot(przedmiot3);

            Console.WriteLine("----------Wydziały po dodaniu jednostek, przedmiotów i studentów----------");
            Console.WriteLine();

            wydział1.WyświetlInfo();
            wydział2.WyświetlInfo();
            wydział3.WyświetlInfo();


        }

    }
}