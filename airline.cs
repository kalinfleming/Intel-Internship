using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace Intel_Internship
{
    public class Writer
    {
        public static async Task WriteAsync(Flight f)
        {
            using StreamWriter file = new("flights.txt", append: true);
            await file.WriteLineAsync((f.flightDetails()));
        }
    }

    public class Reader
    {
        public static void Read()
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("flights.txt");
            foreach (string line in lines)
            {
                count++;
                Console.WriteLine("Flight " +  count + ": ");
                Console.WriteLine(line);
            }
        }

        public static void ReadSpecific(int x)
        {
            Console.WriteLine("Made it");
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("flights.txt");
            foreach (string line in lines)
            {
                count++;
                if (count == x) {
                    Console.WriteLine("Flight " +  count + ": ");
                    Console.WriteLine(line);
                }
            }
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

                public string flightDetails()
                {
                    string x = "Capacity: " + seatingCapacity + ", 1st Class Ticket Price: " + pFirst + ", Economy Ticket Price: " + pEconomy + ", Departure Airport: " + dAirport + ", Arrival Airport: " + aAirport + ", Departure Time: " + dTime + ", Arrival Time: " + aTime;
                    return x;
                }
    }
    
    public class Database
    {
        public int numFlights;
        public List<Flight> database;
        public Database()
        {
            numFlights = 0;
            database = new List<Flight>();
        }
        public void addFlight(Flight f)
        {
            database.Add(f);
            numFlights++;
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
            int c = 0;

            Console.Write("Hello! Welcome to the Booking Portal. Are you a customer or administrator? ");
            person = Console.ReadLine();
            person = person.ToLower();

            while (c == 0) { 
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
                Database d = new Database();
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
                    Flight myObj = new Flight(one, two, three, four, five, six, seven);
                    d.addFlight(myObj);
                    Writer.WriteAsync(myObj);
                }
                else if(person.Equals("customer")) {
                    Console.Write("Please enter your first and last name - ");
                    cName = Console.ReadLine();
                    Console.Write("Please enter your age - ");
                    cAge = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Would you like to see a list of the flights? (Y/N) - ");
                    answer = Console.ReadLine();
                    bool areEqual = String.Equals("Y", answer, StringComparison.OrdinalIgnoreCase);
                    if (areEqual) {
                        Reader.Read();
                    }
                    Console.Write("Which flight would you like? (Just put the flight number) - ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("You have picked the following flight: ");
                    Reader.ReadSpecific(num);
                    Console.Write("Is this correct? (Y/N) - ");
                    string a = Console.ReadLine();
                    bool pequal = String.Equals("Y", a, StringComparison.OrdinalIgnoreCase);
                    if (pequal) {
                        Console.Write("Great! You may now pick your seat. Which seat number would you like? (Just put the seat number) - ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("You have picked seat number: " + n);
                        Console.Write("Is this correct? (Y/N) - ");
                        a = Console.ReadLine();
                        pequal = String.Equals("Y", a, StringComparison.OrdinalIgnoreCase);
                        if (pequal) {
                            Console.WriteLine("Great! You are all set and your seat is reserved.");
                        }
                    }
                }
                Console.Write("Would you like to continue? (Y/N) - ");
                string response = Console.ReadLine();
                bool equal = String.Equals("Y", response, StringComparison.OrdinalIgnoreCase);
                if (!equal) {
                    c = 1;
                    Console.WriteLine("Please come again. Have a great day!");
                }
                else {
                    Console.Write("Hello! Welcome to the Booking Portal. Are you a customer or administrator? ");
                    person = Console.ReadLine();
                    person = person.ToLower();
                    prompt = 0;
                }
            }
        }
    }
}
