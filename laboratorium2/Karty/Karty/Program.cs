using System;


namespace Karty { 

    internal class Karty
    {
        static void Main()
        {
            int ileKart = 45;
            decimal wynik = 1;

            for(int i = 1; i <= ileKart; i++)
            {
                wynik = wynik * Decimal.Parse(i.ToString());
            }

            Console.WriteLine("Wynik to " + wynik);
        }
    }
}


