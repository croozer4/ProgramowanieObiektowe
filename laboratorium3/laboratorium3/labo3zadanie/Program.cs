using System;
using System.Collections;
using System.Collections.Generic;

namespace labo3zadanie
{
    internal class Program
    {
        public interface IZarzadzaniePozycjami
        {
            public Pozycja ZnajdzPozycjePoTytule(string tytulDoZnalezienia);
            public Pozycja ZnajdzPozycjePoId(int idDoZnalezienia);
            public void WypiszWszystkiePozycje();
        }

        public interface IZarzadzanieBibliotekarzami
        {
            public void DodajBibliotekarza(Bibliotekarz bibliotekarzDoDodania);
            public void WypiszBibliotekarzy();
        }
        public class Katalog : IZarzadzaniePozycjami
        {
            private string dzialTematyczny;
            private List<Pozycja> listaPozycji;

            public Katalog()
            {
                dzialTematyczny = "nie wiadomo";
                this.listaPozycji = new List<Pozycja>();
            }

            public Katalog(string dzialTematyczny)
            {
                this.dzialTematyczny = dzialTematyczny;
                this.listaPozycji = new List<Pozycja>();
            }

            public Pozycja ZnajdzPozycjePoTytule(string tytulDoZnalezienia)
            {
                Console.WriteLine("Wypisuje wszystkie pozycje znalezione po tytule");
                for (int i = 0; i < listaPozycji.Count(); i++)
                {
                    if(listaPozycji[i].Tytul == tytulDoZnalezienia)
                    {
                        return listaPozycji[i];
                    }
                }
                return null;
            }

            public Pozycja ZnajdzPozycjePoId(int idDoZnalezienia)
            {
                Console.WriteLine("Wypisuje wszystkie pozycje znalezione po id");
                for (int i = 0; i < listaPozycji.Count(); i++)
                {
                    if(listaPozycji[i].Id == idDoZnalezienia)
                    {
                        return listaPozycji[i];
                    }
                }
                return null;
            }

            public string DzialTematyczny{
                get { return this.dzialTematyczny; }
                set { this.dzialTematyczny = value; }
            }

            public List<Pozycja> ListaPozycji
            {
                get { return this.listaPozycji; }
                set { this.listaPozycji = value; }
            }

            public void DodajPozycje(Pozycja doDodania)
            {
                listaPozycji.Add(doDodania);
            }

            public Pozycja ZnajdzPozycje(string tytul, int id, string wydawnictwo, int rokWydania)
            {
                for(int i = 0; i < listaPozycji.Count(); i++)
                {
                    if(listaPozycji[i].Tytul == tytul && listaPozycji[i].Id == id && listaPozycji[i].Wydawnictwo == wydawnictwo && listaPozycji[i].RokWydania == rokWydania)
                    {
                        return listaPozycji[i];
                    }
                }
                return null;
            }

            public void WypiszWszystkiePozycje()
            {
                Console.WriteLine("Wypisuję wszystkie pozycje z katalogu " + dzialTematyczny + ":\n");

                for (int i = 0; i < listaPozycji.Count(); i++)
                {
                    Console.WriteLine("Pozycja nr " + i+1);
                    listaPozycji[i].WypiszInfo();
                }
                Console.WriteLine();
            }
        }

        public abstract class Pozycja
        {
            protected string tytul;
            protected int id;
            protected string wydawnictwo;
            protected int rokWydania;

            public string Tytul
            {
                get { return tytul; }
                set { tytul = value; }
            }
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Wydawnictwo
            {
                get { return wydawnictwo; }
                set { wydawnictwo = value; }
            }
            public int RokWydania
            {
                get { return rokWydania; }
                set { rokWydania = value; }
            }
            public Pozycja()
            {
                this.tytul = "brak tytułu";
                this.id = 0;
                this.wydawnictwo = "brak wydawnictwa";
                this.rokWydania = 0;
            }

            public Pozycja(string tytul, int id, string wydawnictwo, int rokWydania)
            {
                this.tytul = tytul;
                this.id = id;
                this.wydawnictwo = wydawnictwo;
                this.rokWydania = rokWydania;
            }

            public virtual void WypiszInfo()
            {
                Console.WriteLine("---Dane pozycji---");
                Console.WriteLine("Tytuł: " + tytul + ", id: " + id + ", wydawnictwo: " + wydawnictwo + ", rok wydania: " + rokWydania);
                Console.WriteLine();
            }
        }

        public class Ksiazka : Pozycja
        {
            private int liczbaStron;
            public List<Autor> listaAutorow;

            public Ksiazka() : base()
            {
                this.liczbaStron = 0;
                this.listaAutorow = new List<Autor>();
            }

            public Ksiazka(string tytul, int id, string wydawnictwo, int rokWydania, int liczbaStron) : base(tytul, id, wydawnictwo, rokWydania)
            {
                this.liczbaStron = liczbaStron;
                this.listaAutorow = new List<Autor>();
            }

            public void DodajAutora(Autor autorDoDodania)
            {
                listaAutorow.Add(autorDoDodania);
            }

            public override void WypiszInfo()
            {
                Console.WriteLine("---Dane ksiazki---");
                Console.WriteLine("Tytuł: " + tytul + ", id: " + id + ", wydawnictwo: " + wydawnictwo + ", rok wydania: " + rokWydania + "liczba stron: " + liczbaStron);
                Console.WriteLine("Autorzy: ");

                if (listaAutorow.Count() == 0) Console.WriteLine("brak autorów :(");

                for(int i = 0; i < listaAutorow.Count(); i++)
                {
                    Console.WriteLine(listaAutorow[i].Imie + " " + listaAutorow[i].Nazwisko);
                }
                Console.WriteLine();
            }

        }

        public class Osoba
        {
            protected string imie;
            protected string nazwisko;

            public string Imie
            {
                get { return imie; }
                set { imie = value; }
            }

            public string Nazwisko
            {
                get { return nazwisko; }
                set { nazwisko = value; }
            }

            public Osoba() {
                this.imie = "nie wiadomo";
                this.nazwisko = "nie wiadomo";
            }

            public Osoba(string imie, string nazwisko)
            {
                this.imie = imie;
                this.nazwisko = nazwisko;
            }

            public void WypiszInfo()
            {
                Console.WriteLine("Wypisuje dane osoby:");
                Console.WriteLine("imie: " + imie);
                Console.WriteLine("nazwisko: " + nazwisko);
            }
        }

        public class Autor : Osoba
        {
            private string narodowosc;

            public string Narodowosc
            {
                get { return narodowosc; }
                set { narodowosc = value; }
            }
            public Autor():base()
            {
                this.narodowosc = "nie wiadomo";
            }

            public Autor(string imie, string nazwisko, string narodowosc): base(imie, nazwisko)
            {
                this.narodowosc = narodowosc;
            }

            public void WypiszInfo()
            {
                base.WypiszInfo();
                Console.WriteLine("narodowosc: " + narodowosc);
                Console.WriteLine();
            }
        }

        public class Bibliotekarz : Osoba
        {
            private string dataZatrudnienia;
            private double wynagrodzenie;

            public Bibliotekarz() : base()
            {
                this.dataZatrudnienia = "nie wiadomo";
                this.wynagrodzenie = 0;
            }

            public Bibliotekarz(string imie, string nazwisko, string dataZatrudnienia, double wynagrodznie) : base(imie, nazwisko)
            {
                this.dataZatrudnienia = dataZatrudnienia;
                this .wynagrodzenie = wynagrodznie;
            }

            public void WypiszInfo()
            {
                base.WypiszInfo();
                Console.WriteLine("data zatrudnienia: " + dataZatrudnienia);
                Console.WriteLine("wynagrodzenie: " + wynagrodzenie);
                Console.WriteLine();
            }
        }

        public class Biblioteka : IZarzadzaniePozycjami, IZarzadzanieBibliotekarzami
        {
            private string adres;
            public List<Bibliotekarz> listaBibliotekarzy;
            public List<Katalog> listaKatalogow;

            public Biblioteka()
            {
                this.adres = "nie wiadomo";
                listaBibliotekarzy = new List<Bibliotekarz>();
                listaKatalogow = new List<Katalog>();
            }

            public Biblioteka(string adres)
            {
                this.adres = adres;
                listaBibliotekarzy = new List<Bibliotekarz>();
                listaKatalogow = new List<Katalog>();
            }

            public Pozycja ZnajdzPozycjePoTytule(string tytulDoZnalezienia)
            {
                for(int i = 0; i < listaKatalogow.Count; i++)
                {
                    for(int j = 0; j< listaKatalogow[i].ListaPozycji.Count(); j++)
                    {
                        if(listaKatalogow[i].ListaPozycji[j].Tytul == tytulDoZnalezienia)
                        {
                            return listaKatalogow[i].ListaPozycji[j];
                        }
                    }
                }
                return null;
            }

            public Pozycja ZnajdzPozycjePoId(int idDoZnalezienia)
            {
                for(int i = 0; i < listaKatalogow.Count(); i++)
                {
                    for(int j = 0; j < listaKatalogow[i].ListaPozycji.Count(); j++)
                    {
                        if(listaKatalogow[i].ListaPozycji[j].Id == idDoZnalezienia)
                        {
                            return listaKatalogow [i].ListaPozycji[j];
                        }
                    }
                }
                return null;
            }

            public void WypiszWszystkiePozycje()
            {
                Console.WriteLine("Wypisuje wszystkie pozycje: ");
                for(int i = 0; i < listaKatalogow.Count(); i++)
                {
                    for(int j = 0; j < listaKatalogow[i].ListaPozycji.Count(); j++)
                    {
                        listaKatalogow[i].ListaPozycji[j].WypiszInfo();
                    }
                }
            }

            public void DodajBibliotekarza(Bibliotekarz bibliotekarzDoDodania)
            {
                listaBibliotekarzy.Add(bibliotekarzDoDodania);
            }

            public void WypiszBibliotekarzy()
            {
                for(int i = 0; i < listaBibliotekarzy.Count(); i++)
                {
                    listaBibliotekarzy[i].WypiszInfo();
                }
            }

            public void DodajKatalog(Katalog katalogDoDodania)
            {
                listaKatalogow.Add(katalogDoDodania);
            }

            public void DodajPozycje(Pozycja p, string dzialTematyczny)
            {
                for(int i = 0; i < listaKatalogow.Count(); i++)
                {
                    if(listaKatalogow[i].DzialTematyczny == dzialTematyczny)
                    {
                        listaKatalogow[i].DodajPozycje(p);
                    }
                }
            }

            public void WypiszInfo()
            {
                Console.WriteLine("Wypisuje informacje o bibliotece na " + adres);
                Console.WriteLine("Dostępne katalogi: ");
                for(int i = 0; i < listaKatalogow.Count(); i++)
                {
                    Console.WriteLine("Nazwa katalogu " + listaKatalogow[i].DzialTematyczny);
                    listaKatalogow[i].WypiszWszystkiePozycje();
                }

                Console.WriteLine("Dostępni biblotekarze: " + listaBibliotekarzy.Count());
                this.WypiszBibliotekarzy();
            }

        }

        public class Czasopismo : Pozycja
        {
            private int numer;

            public Czasopismo() : base()
            {
                this.numer = 0;
            }

            public Czasopismo(string tytul, int id, string wydawnictwo, int rokWydania, int numer) : base(tytul, id, wydawnictwo, rokWydania)
            {
                this.numer = numer;
            }

            public override void WypiszInfo()
            {
                Console.WriteLine("---Dane czasopisma---");
                Console.WriteLine("Tytuł: " + tytul + ", id: " + id + ", wydawnictwo: " + wydawnictwo + ", rok wydania: " + rokWydania + "numer: " + numer);
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {

            //kod testujacy do zadania 1

            Console.WriteLine("Zadanie 1");

            Katalog katalog1 = new Katalog("Bajki");
            Katalog katalog2 = new Katalog("Ksiazki fabularne");
            Katalog katalog3 = new Katalog("Czasopisma popularne");

            Ksiazka ksiazka1 = new Ksiazka("Kubus puchatek", 01, "wydawnictwo1", 2001, 15);
            Ksiazka ksiazka2 = new Ksiazka("Smerfy", 02, "wydawnictwo2", 2001, 20);
            Ksiazka ksiazka3 = new Ksiazka("Krol lew", 03, "wydawnictwo1", 1995, 50);

            Ksiazka ksiazka4 = new Ksiazka("Harry Potter", 04, "wydawnictwo3", 2005, 200);
            Ksiazka ksiazka5 = new Ksiazka("Krotka ksiazka", 05, "wydawnictwo4", 2006, 12);

            Czasopismo czasopismo1 = new Czasopismo("Dlugie czasopismo", 06, "wydawnictwo czasopism", 2000, 1);
            Czasopismo czasopismo2 = new Czasopismo("Krotkie czasopismo", 07, "wydawnictwo czasopism", 2000, 2);

            Autor autor1 = new Autor("Jan", "Niezbedny", "polak");
            Autor autor2 = new Autor("Jan", "Zbedny", "tez polak");

            ksiazka1.WypiszInfo();
            ksiazka2.WypiszInfo();
            ksiazka3.WypiszInfo();

            ksiazka1.DodajAutora(autor1);
            ksiazka2.DodajAutora(autor2);

            ksiazka1.WypiszInfo();
            ksiazka2.WypiszInfo();
            ksiazka3.WypiszInfo();

            katalog1.DodajPozycje(ksiazka1);

            katalog1.WypiszWszystkiePozycje();

            katalog1.DodajPozycje(ksiazka2);
            katalog1.DodajPozycje(ksiazka3);

            katalog1.WypiszWszystkiePozycje();

            katalog2.DodajPozycje(ksiazka4);
            katalog2.DodajPozycje(ksiazka5);

            katalog2.WypiszWszystkiePozycje();

            katalog3.DodajPozycje(czasopismo1);
            katalog3.DodajPozycje(czasopismo2);

            katalog3.WypiszWszystkiePozycje();

            Console.WriteLine("Szukanie pozycji");

            katalog1.ZnajdzPozycje("Kubus puchatek", 01, "wydawnictwo1", 2001).WypiszInfo();

            //zadanie 2

            Console.WriteLine("----------------- Zadanie 2 -----------------\n");

            Biblioteka biblioteka1 = new Biblioteka("ul. Ksiazkowa 1");
            Biblioteka biblioteka2 = new Biblioteka("ul. Czasopismowa 2");

            Bibliotekarz bibliotekarz1 = new Bibliotekarz("Jan", "Kowalczyk", "wczoraj", 2200.0);
            Bibliotekarz bibliotekarz2 = new Bibliotekarz("Radosław", "Testowy", "dzisiaj", 100.0);

            biblioteka1.WypiszBibliotekarzy();
            biblioteka2.WypiszBibliotekarzy();

            biblioteka1.DodajBibliotekarza(bibliotekarz1);
            biblioteka2.DodajBibliotekarza(bibliotekarz2);

            biblioteka1.WypiszBibliotekarzy();
            biblioteka2.WypiszBibliotekarzy();

            biblioteka1.DodajKatalog(katalog2);
            biblioteka2.DodajKatalog(katalog3);

            biblioteka1.DodajPozycje(ksiazka1, "Ksiazki fabularne");

            biblioteka1.WypiszInfo();
            biblioteka2.WypiszInfo();
        
        }
    }
}
