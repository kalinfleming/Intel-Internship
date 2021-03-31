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
            Console.WriteLine("Hello World!");
            Flight obj = new Flight(10, 100, 30, "DFW", "GSO", 850, 1050);
            Console.WriteLine("Flight Capacity: {0}", obj.seatingCapacity);
        }
    }
}
