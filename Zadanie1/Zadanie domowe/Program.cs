using System;

namespace Zad2
{
    internal class Program
    {

        static Samochod[] istniejaceSamochody = new Samochod[0]; 
        class Samochod
        {
            private string marka;
            private string model;
            private int iloscDrzwi;
            private int pojemnoscSilnika;
            private double srednieSpalanie;
            private static int liczbaSamochodow = 0;
            private string numerRejestracyjny;
            public string Marka
            {
                get { return marka; }
                set { marka = value; }
            }
            public string Model
            {
                get { return model; }
                set { model = value; }
            }
            public int IloscDrzwi
            {
                get { return iloscDrzwi; }
                set { iloscDrzwi = value; }
            }
            public int PojemnoscSilnika
            {
                get { return pojemnoscSilnika; }
                set { pojemnoscSilnika = value; }
            }
            public double SrednieSpalanie
            {
                get { return srednieSpalanie; }
                set { srednieSpalanie = value; }
            }
            public string NumerRejestracyjny
            {
                get { return numerRejestracyjny; }
                set { numerRejestracyjny = value; }
            }
            public Samochod()
            {
                marka = "nieznany";
                model = "nieznany";
                iloscDrzwi = 0;
                pojemnoscSilnika = 0;
                srednieSpalanie = 0;
                liczbaSamochodow += 1;
                numerRejestracyjny = "nieznany";

                //dodawanie samochodu do listy istniejacych
                Array.Resize(ref istniejaceSamochody, istniejaceSamochody.Length + 1);
                istniejaceSamochody[istniejaceSamochody.Length - 1] = this;
            }

            public Samochod(string marka_, string model_, int iloscDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_, string numerRejestracyjny_)
            {
                marka = marka_;
                model = model_;
                iloscDrzwi = iloscDrzwi_;
                pojemnoscSilnika = pojemnoscSilnika_;
                srednieSpalanie = srednieSpalanie_;
                liczbaSamochodow += 1;
                numerRejestracyjny = numerRejestracyjny_;

                //dodawanie samochodu do listy istniejacych
                Array.Resize(ref istniejaceSamochody, istniejaceSamochody.Length + 1);
                istniejaceSamochody[istniejaceSamochody.Length - 1] = this;
            }
            public double ObliczSpalanie(double dlugoscTrasy)
            {
                return (srednieSpalanie * dlugoscTrasy) / 100;
            }
            public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
            {
                return ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
            }
            public void WypiszInfo()
            {
                Console.WriteLine("Marka: " + marka);
                Console.WriteLine("Model: " + model);
                Console.WriteLine("Ilość drzwi: " + iloscDrzwi);
                Console.WriteLine("Pojemność silnika (w cm^3): " + pojemnoscSilnika);
                Console.WriteLine("Średnie spalanie: " + srednieSpalanie);
                Console.WriteLine("Numer rejestracyjny: " + numerRejestracyjny);
                Console.WriteLine("\n");
            }
            public static void WypiszIloscSamochodow()
            {
                Console.WriteLine("Liczba utworzonych samochodów: " + liczbaSamochodow);
            }
        }

        class Garaz
        {
            private string adres;
            private int pojemnosc;
            private int liczbaSamochodow = 0;
            private Samochod[] samochody;

            public string Adres
            {
                get { return adres; }
                set { adres = value; }
            }

            public int Pojemnosc
            {
                get { return pojemnosc; }
                set
                {
                    pojemnosc = value;
                    samochody = new Samochod[pojemnosc];
                }
            }

            public Garaz()
            {
                this.adres = "nieznany";
                this.pojemnosc = 0;
                this.samochody = null;
            }

            public Garaz(string adres_, int pojemnosc_)
            {
                this.adres = adres_;
                this.pojemnosc = pojemnosc_;
                this.samochody = new Samochod[pojemnosc_];
                //for(int i=0; i<liczbaSamochodow_; i++) { this.samochody[i] = samochody_[i]; }
            }

            public void WprowadzSamochod(Samochod samochod_)
            {
                if (this.pojemnosc > this.liczbaSamochodow)
                {
                    this.samochody[liczbaSamochodow] = samochod_;
                    this.liczbaSamochodow += 1;
                }
                else
                {
                    Console.WriteLine("Garaż jest pełny.");
                }
            }

            public Samochod WyprowadzSamochod()
            {
                if (this.liczbaSamochodow == 0)
                {
                    Console.WriteLine("Garaż jest pusty.");
                    return null;
                }
                else
                {
                    Samochod wyprowadzony = this.samochody[liczbaSamochodow - 1];
                    this.samochody[liczbaSamochodow - 1] = null;
                    this.liczbaSamochodow -= 1;
                    return wyprowadzony;
                }
            }

            public void WypiszInfo()
            {
                Console.WriteLine("Adres garażu: " + this.adres);
                Console.WriteLine("Pojemność garażu: " + this.pojemnosc + "\n");
                Console.WriteLine("Informacje o poszczególnych samochodach:");
                for (int i = 0; i < this.liczbaSamochodow; i++)
                {
                    samochody[i].WypiszInfo();
                }
            }
        }

        class Osoba
        {
            private string imie;
            private string nazwisko;
            private string adresZamieszkania;
            private int iloscSamochodow = 0;
            private Samochod[] posiadane;

            public Osoba()
            {
                this.imie = "nieznane";
                this.nazwisko = "nieznane";
                this.adresZamieszkania = "nieznany";
                this.posiadane = new Samochod[iloscSamochodow];

                Console.WriteLine("Dodano nową osobę: " + this.imie + " " + this.nazwisko + "\n");
            }

            public Osoba(string imie_, string nazwisko_, string adres_)
            {
                this.imie = imie_;
                this.nazwisko = nazwisko_;
                this.adresZamieszkania = adres_;
                this.posiadane = new Samochod[iloscSamochodow];

                Console.WriteLine("Dodano nową osobę: " + this.imie + " " + this.nazwisko + "\n");
            }

            public void DodajSamochod(string nrRejestracyjny)
            {
                if (this.iloscSamochodow < 3)
                {
                    Array.Resize(ref posiadane, posiadane.Length + 1);
                    Samochod znaleziony = Array.Find(istniejaceSamochody, z => z.NumerRejestracyjny == nrRejestracyjny);
                    this.posiadane[iloscSamochodow] = znaleziony;
                    Console.WriteLine("Do " + this.imie + " " + this.nazwisko + " przypisano samochód: " +  this.posiadane[iloscSamochodow].Marka + " " + this.posiadane[iloscSamochodow].Model + "\n");
                    this.iloscSamochodow++;
                }
                else
                {
                    Console.WriteLine(this.imie + " nie może posiadać więcej samochodów niż 3.");
                    Console.ReadKey();
                }
            }

            public void UsunSamochod(string nrRejestracyjny)
            {
                Samochod znaleziony = Array.Find(istniejaceSamochody, z => z.NumerRejestracyjny == nrRejestracyjny);
                for (int i = 0; i < this.posiadane.Length; i++)
                {
                    if (this.posiadane[i] == znaleziony )
                    {
                        this.posiadane = this.posiadane.Where(e => e != znaleziony).ToArray();
                        this.iloscSamochodow--;
                    }
                }
            }

            public void WypiszInfo()
            {
                Console.WriteLine("Imie właściciela: " + this.imie);
                Console.WriteLine("Nazwisko właściciela: " + this.nazwisko);
                Console.WriteLine("Adres zamieszkania właściciela: " + this.adresZamieszkania + "\n");
                Console.WriteLine("Ile samochodów posiada: " + this.iloscSamochodow);
                if (this.iloscSamochodow == 0)
                {
                    Console.WriteLine(this.imie + " nie posiada żadnych samochodów. \n");
                }
                else
                {
                    Console.WriteLine("Dane samochodów: \n");
                    for (int i = 0; i < iloscSamochodow; i++)
                    {

                        if(posiadane[i] == null)
                        {
                            Console.WriteLine("to miejsce jest puste \n");
                        }
                        else
                        {
                            posiadane[i].WypiszInfo();
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Samochod s1 = new Samochod("Renault", "Scenic", 3, 1200, 8.0, "rejestracja1");
            Samochod s2 = new Samochod("Renault", "Modus", 5, 1200, 8.0, "rejestracja2");
            Samochod s3 = new Samochod("Peugeot", "208", 3, 1200, 8.0, "rejestracja3");
            Samochod s4 = new Samochod("Opel", "Zafira", 5, 1200, 8.0, "rejestracja4");

            Garaz g1 = new Garaz();
            g1.Adres = "ul. Garażowa 1";
            g1.Pojemnosc = 1;

            Garaz g2 = new Garaz("ul. Garażowa 2", 2);

            g1.WprowadzSamochod(s1);
            g1.WypiszInfo();
            g1.WprowadzSamochod(s2);

            g2.WprowadzSamochod(s2);
            g2.WprowadzSamochod(s1);
            g2.WypiszInfo();

            g2.WyprowadzSamochod();
            g2.WypiszInfo();

            g2.WyprowadzSamochod();
            g2.WyprowadzSamochod();

            Console.WriteLine("--------------------------------Zadanie domowe--------------------------------");

            Osoba o1 = new Osoba("Konrad", "Kulesza", "ul. Poludniowa 132, 42-100 Lgota");
            Osoba o2 = new Osoba("Karolina", "Budzik", "ul. Poludniowa 132, 42-100 Lgota");

            o1.DodajSamochod("rejestracja2");
            o2.DodajSamochod("rejestracja4");

            o1.WypiszInfo();
            o2.WypiszInfo();

            o1.DodajSamochod("rejestracja1");
            o1.WypiszInfo();

            o1.DodajSamochod("rejestracja3");
            o1.WypiszInfo();

            o1.UsunSamochod("rejestracja1");
            o1.WypiszInfo();

            o1.UsunSamochod("rejestracja2");
            o1.UsunSamochod("rejestracja3");
            o1.WypiszInfo();

            o2.UsunSamochod("rejestracja4");
            o2.WypiszInfo();

            Console.ReadKey();
        }
    }
}