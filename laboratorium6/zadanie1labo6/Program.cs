using System;
using System.Collections;
using System.Collections.Generic;

namespace zadanie1labo6
{
    static class IListRozszerzenia
    {
        public static void Dodaj<T>(this IList<T> lista, T element)
        {
            lista.Add(element);
        }

        public static bool Usun<T>(this IList<T> lista, T element)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                if(lista[i].GetHashCode == element.GetHashCode)
                {
                    lista.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public static bool Wyszukaj<T>(this IList<T> lista, T element)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].GetHashCode == element.GetHashCode)
                {
                    Console.WriteLine("Odnaleziono element na indeksie " + i + "!");
                    Console.WriteLine(lista[i].ToString());
                }
            }
            Console.WriteLine("Nie udało się odnaleźć elementu :(");
            return false;
        }

        public static IList<T> WyszukajWszystkie<T>(this IList<T> lista, T element)
        {
            var listaZnalezionych = Activator.CreateInstance(lista.GetType()) as IList<T>;
            foreach(var e in lista) if(e.Equals(element))listaZnalezionych.Add(e);
            return listaZnalezionych;
        }

        public static IList<T> WyszukajWszystkie<T>(this IList<T> lista, Func<T,bool> warunekWyszukania)
        {
            var listaZnalezionych = Activator.CreateInstance(lista.GetType()) as IList<T>;
            foreach(var e in lista) if(warunekWyszukania(e)) listaZnalezionych.Add(e);
            return listaZnalezionych;
        }

        public static void Wyswietl<T>(this IList<T> lista, string komentarz)
        {
            Console.WriteLine(komentarz);
            foreach(var e in lista) Console.WriteLine(e);
        }
    }
    internal class Program
    {
        public static IList<Klatka> listaWszystkichKlatek { get; set; } = new List<Klatka>();
        public static IList<Opiekun> listaWszystkichOpiekunow { get; set; } = new List<Opiekun>();

        public interface IKlasyZListami { }

        public class Zwierze
        {
            public string Gatunek { get; set; }
            public string RodzajPozywienia { get; set; }
            public string Pochodzenie { get; set; }

            public Zwierze()
            {
                Gatunek = "nie wiadomo";
                RodzajPozywienia = "nie wiadomo";
                Pochodzenie = "nie wiadomo";
            }
            
            public Zwierze(string gatunek, string rodziajPozywienia, string pochodzenie)
            {
                Gatunek = gatunek;
                RodzajPozywienia = rodziajPozywienia;
                Pochodzenie = pochodzenie;
            }

            public override string ToString()
            {
                return "Gatunek: " + Gatunek + " Rodzaj Pożywienia: " + RodzajPozywienia + " Pochodzenie: " + Pochodzenie;
            }
        }

        public class Ssak : Zwierze
        {
            public string NaturalneSrodowisko { get; set; }

            public Ssak() :base()
            {
                NaturalneSrodowisko = "nie wiadomo";
            }

            public Ssak(string gatunek, string rodzajPozywienia, string pochodzenie, string naturalneSrodowisko) :base(gatunek, rodzajPozywienia, pochodzenie)
            {
                NaturalneSrodowisko = naturalneSrodowisko;
            }

            public override string ToString()
            {
                return base.ToString() + " Naturalne środowisko: " + NaturalneSrodowisko + "\n";
            }
        }

        public class Ptak : Zwierze
        {
            public int RozpietoscSkrzydel { get; set; }
            public int Wytrzymalosc { get; set; }
            public int MaksymalnaDlugoscLotu { get; set; }

            public Ptak():base()
            {
                RozpietoscSkrzydel = 0;
                Wytrzymalosc = 0;
                MaksymalnaDlugoscLotu = RozpietoscSkrzydel*Wytrzymalosc;
            }

            public Ptak(string gatunek, string rodzajPozywienia, string pochodzenie, int rozpietoscSkrzydel, int wytrzymalosc) :base(gatunek, rodzajPozywienia, pochodzenie)
            {
                RozpietoscSkrzydel = rozpietoscSkrzydel;
                Wytrzymalosc = wytrzymalosc;
                MaksymalnaDlugoscLotu = Wytrzymalosc*RozpietoscSkrzydel;
            }

            public void Lec()
            {
                Console.WriteLine(Gatunek + " leci!");
            }

            public override string ToString()
            {
                return base.ToString() + " Rozpietosc skrzydel: " + RozpietoscSkrzydel + " Wytrzymalosc: " + Wytrzymalosc + " Maksymalna dlugosc lotu:" + MaksymalnaDlugoscLotu + "\n";
            }
        }
        
        public class Gad : Zwierze
        {
            public bool Jadowity { get; set; }

            public Gad() :base()
            {
                Jadowity = false;
            }
            public Gad(string gatunek, string rodzajPozywienia, string pochodzenie, bool jadowity) :base(gatunek, rodzajPozywienia, pochodzenie)
            {
                Jadowity = jadowity;
            }

            public override string ToString()
            {
                return base.ToString() + " Jadowity: " + Jadowity + "\n";
            }
        }

        public class Klatka : IKlasyZListami
        {
            public int Pojemnosc { get; set; }
            public int NumerKlatki { get; set; }
            public bool WymagaPosprzatania { get; set; } = false;
            public IList<Zwierze> ListaZwierzat { get; set; } = new List<Zwierze>();
            public Opiekun opiekunKlatki { get; set; }

            public Klatka(int pojemnosc, int numerKlatki)
            {
                Pojemnosc = pojemnosc;
                NumerKlatki = numerKlatki;
            }
            public override string ToString()
            {
                string zwierzeta = "Zwierzęta w klatce: \n";
                for(int i = 0; i < ListaZwierzat.Count(); i++)
                {
                    zwierzeta += ListaZwierzat[i].ToString();
                }

                return "Pojemnosc: " + Pojemnosc + "\nNumer klatki: " + NumerKlatki + "\nCzy wymaga posprzatania: " + WymagaPosprzatania + "\nOpiekun klatki: " + opiekunKlatki + "\n" + zwierzeta;

            }

        }

        public class Opiekun : IKlasyZListami
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public IList<Klatka> listaKlatek { get; set; } = new List<Klatka>();
            public Opiekun(string imie, string nazwisko)
            {
                Imie = imie;
                Nazwisko = nazwisko;
            }
            
            public void posprzatajKlatke(Klatka klatkaDoPosprzatania)
            {
                klatkaDoPosprzatania.WymagaPosprzatania = false;
                Console.WriteLine(Imie + " " + Nazwisko + " posprzątał klatkę nr " + klatkaDoPosprzatania.NumerKlatki);
            }

            public void przydzielOpiekeNadKlatka(Klatka klatkaDoPrzydzielenia)
            {
                klatkaDoPrzydzielenia.opiekunKlatki = this;
            }

            public override string ToString()
            {
                return Imie + " " + Nazwisko;
            }
        }

        public class Dyrekcja
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public Dyrekcja() 
            {
                Imie = "nie wiadomo";
                Nazwisko = "nie wiadomo";
            }

            public Dyrekcja(string imie, string nazwisko)
            {
                Imie = imie;
                Nazwisko = nazwisko;
            }

            public void utworzKlatke(int pojemnosc, int numerKlatki)
            {
                listaWszystkichKlatek.Add(new Klatka(pojemnosc, numerKlatki));
            }

            public void zatrudnijProcownika(string imie, string nazwisko)
            {
                listaWszystkichOpiekunow.Add(new Opiekun(imie, nazwisko));
            }

            public void powiekszKlatke(Klatka klatkaDoPowiekszenia)
            {
                klatkaDoPowiekszenia.Pojemnosc++;
                Console.WriteLine("Powiekszono klatkę o numerze " + klatkaDoPowiekszenia.NumerKlatki);
            }

            public void wyswietlInformacjeOKlatce(Klatka klatkaDoWyswietlenia)
            {
                Console.WriteLine("Pojemnosc: " + klatkaDoWyswietlenia.opiekunKlatki);
                Console.WriteLine("Numer klatki: " + klatkaDoWyswietlenia.NumerKlatki);
                Console.WriteLine("Czy wymaga posprzątania: " + klatkaDoWyswietlenia.WymagaPosprzatania);
                Console.WriteLine("Zwierzęta w klatce: ");
                Console.WriteLine("Opiekun klatki: " + klatkaDoWyswietlenia.opiekunKlatki.Imie + " " + klatkaDoWyswietlenia.opiekunKlatki.Nazwisko);
                for(int i = 0; i < klatkaDoWyswietlenia.ListaZwierzat.Count(); i++)
                {
                    Console.WriteLine("Zwierze nr " + i);
                    Console.WriteLine("Gatunek: " + klatkaDoWyswietlenia.ListaZwierzat[i].Gatunek);
                    Console.WriteLine("Pochodzenie: " + klatkaDoWyswietlenia.ListaZwierzat[i].Pochodzenie);
                    Console.WriteLine("Rodzaj Pozywienia: " + klatkaDoWyswietlenia.ListaZwierzat[i].RodzajPozywienia);
                    Console.WriteLine();
                }
            }

        }
        public static void Main()
        {
            Ssak dziobak = new Ssak("dziobakowaty","mieso i rośliny","Australia","wodne");
            Gad jaszczurka = new Gad("jaszczurkowaty", "mieso", "Europa", true);
            Ptak wrobel = new Ptak("ptakowaty", "rośliny", "Ameryka", 20, 30);

            Dyrekcja dyrektor1 = new Dyrekcja("Kuba", "Profesor");

            dyrektor1.utworzKlatke(1, 1);
            dyrektor1.utworzKlatke(2, 2);

            dyrektor1.zatrudnijProcownika("Konrad", "Kulesza");
            dyrektor1.zatrudnijProcownika("Karolina", "Budzik");

            Console.WriteLine("Tacy opiekunowie zostali zatrudnieni:");

            for(int i = 0; i < listaWszystkichOpiekunow.Count(); i++)
            {
                Console.WriteLine(listaWszystkichOpiekunow[i]);
            }
            Console.WriteLine();

            listaWszystkichOpiekunow[0].listaKlatek.Dodaj<Klatka>(listaWszystkichKlatek[0]);
            listaWszystkichOpiekunow[1].listaKlatek.Dodaj<Klatka>(listaWszystkichKlatek[1]);
            listaWszystkichOpiekunow[0].przydzielOpiekeNadKlatka(listaWszystkichKlatek[0]);
            listaWszystkichOpiekunow[1].przydzielOpiekeNadKlatka(listaWszystkichKlatek[1]);


            listaWszystkichKlatek[0].ListaZwierzat.Dodaj<Zwierze>(wrobel);
            listaWszystkichKlatek[1].ListaZwierzat.Dodaj<Zwierze>(jaszczurka);
            listaWszystkichKlatek[1].ListaZwierzat.Dodaj<Zwierze>(dziobak);


            listaWszystkichOpiekunow[0].listaKlatek.Wyswietl<Klatka>("Wyświetlam klatki opiekuna " + listaWszystkichOpiekunow[0].Imie + " " + listaWszystkichOpiekunow[0].Nazwisko);
            Console.WriteLine();
            listaWszystkichOpiekunow[1].listaKlatek.Wyswietl<Klatka>("Wyświetlam klatki opiekuna " + listaWszystkichOpiekunow[1].Imie + " " + listaWszystkichOpiekunow[1].Nazwisko);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}