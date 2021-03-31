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
                public string dTime;
                public string aTime;
                public Flight(int sc, int pf, int pe, string da, string aa, string dt, string at)
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
            int one;
            int two;
            int three;
            string four;
            string five;
            string six;
            string seven;
            Console.Write("Enter a seating capacity - ");
            one = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter price of 1st class ticket - ");
            two = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter price of economy ticket - ");
            three = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter departure airport - ");
            four = Console.ReadLine();
            Console.Write("Enter arrival airport - ");
            five = Console.ReadLine();
            Console.Write("Enter departure time - ");
            six = Console.ReadLine();
            Console.Write("Enter arrival time - ");
            seven = Console.ReadLine();
            Flight myObj = new Flight(one, two, three, four, five, six, seven);
            Console.WriteLine("Flight Capacity: {0}", myObj.seatingCapacity);
            Console.WriteLine("Price of First Class Ticket: {0}", myObj.pFirst);
            Console.WriteLine("Price of Economy Ticket: {0}", myObj.pEconomy);
            Console.WriteLine("Departure Airport: {0}", myObj.dAirport);
            Console.WriteLine("Arrival Airport: {0}", myObj.aAirport);
            Console.WriteLine("Departure Time: {0}", myObj.dTime);
            Console.WriteLine("Arrival Time: {0}", myObj.aTime);
        }
    }
}
