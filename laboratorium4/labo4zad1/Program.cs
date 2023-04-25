using System;
using System.Collections;
using System.Collections.Generic;

namespace labo5zad1
{
    internal class Program
    {
        public partial class MyList<T>
        {
            private class Element
            {
                public T wartosc { get; set; }
                public Element nastepny { get; set; } = null;
            }

            private Element pierwszy = null;
            private Element ostatni = null;

            public void Insert(int i, T element)
            {
                var aktualna = pierwszy;

                for (int j = 0; j < i; j++)
                {
                    aktualna = aktualna.nastepny;

                }

                var tymczasowaNastepna = aktualna.nastepny;
                aktualna.nastepny = new Element() { wartosc = element };
                aktualna.nastepny.nastepny = tymczasowaNastepna;
            }

            public void Add(T element)
            {
                if(pierwszy == null)
                    pierwszy = ostatni = new Element() { wartosc = element };
                else
                    ostatni = ostatni.nastepny = new Element() { wartosc = element };
            }

            private Element Get(int i)
            {
                var e = pierwszy;

                while (i-- > 0 && e != null)
                    e = e.nastepny;
                if (e == null)
                    throw new IndexOutOfRangeException();
                return e;
            }

            public void RemoveAt(int i)
            {
                if(i == 0)
                {
                    pierwszy = pierwszy.nastepny;
                    return;
                }

                var aktualna = pierwszy;

                for (int j = 0; j < (i - 1); j++)
                {
                    aktualna = aktualna.nastepny;
                }

                aktualna.nastepny = aktualna.nastepny.nastepny;
            }

            public void Remove(T element)
            {
                var aktualna = pierwszy;
                var poprzednia = pierwszy;

                if(element.GetHashCode == pierwszy.GetHashCode)
                {
                    pierwszy = pierwszy.nastepny;
                }

                while (aktualna.nastepny != null)
                {
                    if (aktualna.wartosc.GetHashCode == element.GetHashCode)
                    {
                        poprzednia.nastepny = aktualna.nastepny;
                    }

                    poprzednia = aktualna;
                    aktualna = aktualna.nastepny;
                }
            }

            public T this[int i] { get => Get(i).wartosc; set => Get(i).wartosc = value; }
        }

        public class Zwierze
        {
            public string Nazwa { get; set; }
            public string Gatunek { get; set; }
            public int LiczbaNog { get; set; }

            public Zwierze()
            {
                Nazwa = "nie podano";
                Gatunek = "nie podano";
                LiczbaNog = 0;
            }

            public Zwierze(string nazwa, string gatunek, int liczbNog)
            {
                Nazwa = nazwa;
                Gatunek = gatunek;
                LiczbaNog = liczbNog;
            }

            public override string ToString()
            {
                return Nazwa + " " + Gatunek + " " + LiczbaNog.ToString();
            }
        }

        static void Main()
        {

            MyList<Zwierze> zwierzeta = new MyList<Zwierze>();

            Zwierze zwierze1 = new Zwierze("Kot", "kotowate", 4);
            Zwierze zwierze2 = new Zwierze("Pies", "psowate", 4);
            Zwierze zwierze3 = new Zwierze("Pajak", "pajeczaki", 8);
            Zwierze zwierze4 = new Zwierze("Waz", "gad", 0);

            zwierzeta.Add(zwierze1);
            zwierzeta.Add(zwierze2);
            zwierzeta.Add(zwierze3);
            zwierzeta.Add(zwierze4);

            Console.WriteLine("Po dodaniu 4 zwierząt: ");
            Console.WriteLine("\n");

            Console.WriteLine(zwierzeta[0]);
            Console.WriteLine(zwierzeta[1]);
            Console.WriteLine(zwierzeta[2]);
            Console.WriteLine(zwierzeta[3]);

            Console.WriteLine("\n");
            Console.WriteLine("Po usunieciu 1 pozycji: ");
            Console.WriteLine("\n");

            zwierzeta.RemoveAt(0);

            Console.WriteLine(zwierzeta[0]);
            Console.WriteLine(zwierzeta[1]);
            Console.WriteLine(zwierzeta[2]);
            //Console.WriteLine(zwierzeta[3]);

            zwierzeta.Remove(zwierze3);

            Console.WriteLine("\n");
            Console.WriteLine("Po usunieciu konkretnego obiektu: ");
            Console.WriteLine("\n");

            Console.WriteLine(zwierzeta[0]);
            Console.WriteLine(zwierzeta[1]);

            Console.WriteLine("\n");
            Console.WriteLine("Po dodaniu konkretnego obiektu: ");
            Console.WriteLine("\n");

            zwierzeta.Insert(1, zwierze4);

            Console.WriteLine(zwierzeta[0]);
            Console.WriteLine(zwierzeta[1]);
            Console.WriteLine(zwierzeta[2]);





            Console.ReadKey();
        }

    }
}