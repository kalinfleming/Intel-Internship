using System;
using System.Collections;

namespace Intel_Internship
{
    public class Database
    {
        public int numFlights;
        public ArrayList database;
        public Database()
        {
            numFlights = 0;
            database = new ArrayList();
        }
        public void addFlight(Flight f)
        {
            database.Add(f);
            numFlights++;
            Console.WriteLine("Number of flights: {0}", numFlights);
        }

    }
    
    public class Flight
    {
                public int seatingCapacity;
                public int pFirst;
                public int pEconomy;
                public string dAirport;
                public string aAirport;
                public string dTime;
                public string aTime;
                public Flight()
                {
                    seatingCapacity = 0;
                    pFirst = 0;
                    pEconomy = 0;
                    dAirport = "Nowhere";
                    aAirport = "Nowhere";
                    dTime = "Never";
                    aTime = "Never";
                }
                public Flight(int sc, int pf, int pe, string da, string aa, string dt, string at)
                {
                    da = da.ToUpper();
                    aa = aa.ToUpper();
                    seatingCapacity = sc;
                    pFirst = pf;
                    pEconomy = pe;
                    dAirport = da;
                    aAirport = aa;
                    dTime = dt;
                    aTime = at;
                }
    }

    public class Customer
    {
        public string name;
        public int age;
        public Customer()
        {
            name = "John Doe";
            age = 0;
        }
        public Customer(string n, int a)
        {
            name = n;
            age = a;
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
            string person;
            string cName;
            int cAge;
            string answer;
            int prompt = 0;

            Console.Write("Hello! Welcome to the Booking Portal. Are you a customer or administrator? ");
            person = Console.ReadLine();
            person = person.ToLower();
            
            while (prompt == 0) {
                if ((person.Equals("administrator")) || (person.Equals("customer"))) {
                    prompt = 1;
                } else {
                    Console.WriteLine("Please check your spelling and try again.");
                    Console.Write("Hello! Welcome to the Booking Portal. Are you a customer or administrator? ");
                    person = Console.ReadLine();
                    person = person.ToLower();
                }
            }

            if(person.Equals("administrator")) 
            {
                Console.Write("Enter a seating capacity - ");
                one = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter price of 1st class ticket - $");
                two = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter price of economy ticket - $");
                three = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter departure airport - ");
                four = Console.ReadLine();
                Console.Write("Enter arrival airport - ");
                five = Console.ReadLine();
                Console.Write("Enter departure time (XX:XX) - ");
                six = Console.ReadLine();
                Console.Write("Enter arrival time (XX:XX) - ");
                seven = Console.ReadLine();
                Database d = new Database();
                Flight myObj = new Flight(one, two, three, four, five, six, seven);
                d.addFlight(myObj);
                Console.WriteLine("Flight Capacity: {0}", myObj.seatingCapacity);
                Console.WriteLine("Price of First Class Ticket: {0}", myObj.pFirst);
                Console.WriteLine("Price of Economy Ticket: {0}", myObj.pEconomy);
                Console.WriteLine("Departure Airport: {0}", myObj.dAirport);
                Console.WriteLine("Arrival Airport: {0}", myObj.aAirport);
                Console.WriteLine("Departure Time: {0}", myObj.dTime);
                Console.WriteLine("Arrival Time: {0}", myObj.aTime);
            }
            else if(person.Equals("customer")) {
                Console.Write("Please enter your first and last name - ");
                cName = Console.ReadLine();
                Console.Write("Please enter your age - ");
                cAge = Convert.ToInt32(Console.ReadLine());
                Console.Write("Would you like to see a list of the flights (Y/N) - ");
                answer = Console.ReadLine();
                bool areEqual = String.Equals("Y", answer, StringComparison.OrdinalIgnoreCase);
                if (areEqual) {
                    Console.WriteLine("List of flights");
                }
                else {
                    bool areEqual2 = String.Equals("N", answer, StringComparison.OrdinalIgnoreCase);
                    if (areEqual2) {
                        Console.WriteLine("Please come again. Have a great day!");
                    }
                }
            }
        }
    }
}
