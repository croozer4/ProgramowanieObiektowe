using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class Samochod
    {
        string marka;
        string model;
        int liczbaDrzwi;
        int pojemnoscSilnika;
        double srednieSpalanie;

        private static int liczbaObiektowSamochod;

        public Samochod()
        {
            marka = "nieznana";
            model = "nieznany";
            liczbaDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0;

            liczbaObiektowSamochod++;
        }

        public Samochod(string marka_, string model_, int liczbaDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_)
        {
            this.marka = marka_;
            this.model = model_;
            this.liczbaDrzwi = liczbaDrzwi_;
            this.pojemnoscSilnika = pojemnoscSilnika_;
            this.srednieSpalanie = srednieSpalanie_;

            liczbaObiektowSamochod++;
        }
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

        public int LiczbaDrzwi
        {
            get { return liczbaDrzwi; }
            set { liczbaDrzwi = value; }
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
            Console.WriteLine("Liczba drzwi: " + liczbaDrzwi);
            Console.WriteLine("Pojemnosc silnika: " + pojemnoscSilnika);
            Console.WriteLine("Srednie spalanie: " + srednieSpalanie);
        }

        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Ilosc samochodow: " + liczbaObiektowSamochod);
        }
    }

    public class Garaz
    {
        string adres;
        int pojemnosc;
        int liczbaSamochodow = 0;

        Samochod[] samochody;

        public Garaz() 
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = new Samochod[pojemnosc];
        }

        public Garaz(string adres, int pojemnosc)
        {
            this.adres = adres;
            this.pojemnosc = pojemnosc;
            samochody = new Samochod[this.pojemnosc];
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public int Pojemnosc
        {
            get { return pojemnosc; }
            set { 
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }

        public void wprowadzSamochod(Samochod s)
        {
            if(liczbaSamochodow < pojemnosc)
            {
                this.samochody[liczbaSamochodow] = s;
                this.liczbaSamochodow++;
            }
            else
            {
                Console.WriteLine("Niestety, garaż jest pełny\n");
            }
        }

        public void wyprowadzSamochod()
        {
            if (liczbaSamochodow > 0)
            {
                this.samochody[liczbaSamochodow-1] = null;
                this.liczbaSamochodow--;
            }
            else
            {
                Console.WriteLine("Niestety, garaż jest pusty\n");
            }
        }

        public void wypiszInfo()
        {
            Console.WriteLine("Adres garazu: " + adres);
            Console.WriteLine("Pojemnosc garazu " + pojemnosc);
            Console.WriteLine("W garażu znajduje się " + liczbaSamochodow + " samochodow: \n" );

            for(int i=0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Samochod s1 = new Samochod();

            s1.WypiszInfo();

            s1.Marka = "Fiat";
            s1.Model = "126p";
            s1.LiczbaDrzwi = 2;
            s1.PojemnoscSilnika = 650;
            s1.SrednieSpalanie = 6.0;

            s1.WypiszInfo();
            Console.WriteLine();

            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);

            s2.WypiszInfo();
            Console.WriteLine();

            double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85);
            Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu);

            Samochod.WypiszIloscSamochodow();
            Console.WriteLine();

            Samochod s3 = new Samochod("Fiat", "126p", 2, 650, 6.0);
            Samochod s4 = new Samochod("Syrena", "105", 2, 800, 7.6);

            Garaz g1 = new Garaz();
            g1.Adres = "ul. Garażowa 1";
            g1.Pojemnosc = 1;

            Garaz g2 = new Garaz("ul. Garażowa 2", 2);

            g1.wprowadzSamochod(s3);
            g1.wypiszInfo();
            g1.wprowadzSamochod(s4);

            g2.wprowadzSamochod(s4);
            g2.wprowadzSamochod(s3);
            g2.wypiszInfo();

            g2.wyprowadzSamochod();
            g2.wypiszInfo();

            g2.wyprowadzSamochod();
            g2.wyprowadzSamochod();

            Console.ReadKey();
        }
    }
}
