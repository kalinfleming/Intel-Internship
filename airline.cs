using System;

namespace Intel_Internship
{
    public class Flight
    {
                public int seatingCapacity;
                public int pFirst;
                public int pEconomy;
                public string dAirport;
                public string aAirport;
                public int dTime;
                public int aTime;
                public Flight(int sc, int pf, int pe, string da, string aa, int dt, int at)
                {
                    seatingCapacity = sc;
                    pFirst = pf;
                    pEconomy = pe;
                    dAirport = da;
                    aAirport = aa;
                    dTime = dt;
                    aTime = at;
                }
    }
    class Airline
    {
        static void Main(string[] args)
        {
            string a;
            string b;
            string c;
            string d;
            string e;
            string f;
            string g;
            int one;
            int two;
            int three;
            int four;
            int five;
            Console.Write("Enter a seating capacity - ");
            a = Console.ReadLine();
            one = Convert.ToInt32(a);
            Console.Write("Enter price of 1st class ticket - ");
            b = Console.ReadLine();
            two = Convert.ToInt32(b);
            Console.Write("Enter price of economy ticket - ");
            c = Console.ReadLine();
            three = Convert.ToInt32(c);
            Console.Write("Enter departure airport - ");
            d = Console.ReadLine();
            Console.Write("Enter arrival airport - ");
            e = Console.ReadLine();
            Console.Write("Enter departure time - ");
            f = Console.ReadLine();
            four = Convert.ToInt32(f);
            Console.Write("Enter arrival time - ");
            g = Console.ReadLine();
            five = Convert.ToInt32(g);
            Console.WriteLine("Hello World!");
            Flight obj = new Flight(10, 100, 30, "DFW", "GSO", 850, 1050);
            Flight myObj = new Flight(one, two, three, d, e, four, five);
            Console.WriteLine("Flight Capacity: {0}", obj.seatingCapacity);
            Console.WriteLine("Flight Capacity: {0}", myObj.seatingCapacity);
        }
    }
}
