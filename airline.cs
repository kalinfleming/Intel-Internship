using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;


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
                int[] seatChart;
                
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
                    seatChart = new int[sc];
                    for (int i = 0; i < sc; i++) {
                        seatChart[i] = 0;
                    }
                }

                public void createSeatingChart() {
                    seatChart = new int[seatingCapacity];
                    for (int i = 0; i < seatingCapacity; i++) {
                        seatChart[i] = 0;
                    }
                }

                public string flightDetails()
                {
                    string x = "Capacity: " + seatingCapacity + ", 1st Class Ticket Price: " + pFirst + ", Economy Ticket Price: " + pEconomy + ", Departure Airport: " + dAirport + ", Arrival Airport: " + aAirport + ", Departure Time: " + dTime + ", Arrival Time: " + aTime;
                    return x;
                }

                public int takenSeat(int x) 
                {
                    if (seatChart[x-1] == 0) {
                        seatChart[x-1] = 1;
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }

                public void printSeating()
                {
                    string format = "--------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                    Console.WriteLine(format);
                    Console.WriteLine("Seating Chart (X represents seats that are taken): ");
                    for (int i = 0; i < seatingCapacity; i++) {
                        if (i != 0 && i%3 == 0 && i%6 !=0) {
                            Console.Write("           ");
                        }
                        else if (i != 0 && i%6 == 0) {
                            Console.WriteLine(" ");
                        }
                        if (seatChart[i] == 0 && i < 10) {
                            Console.Write(i+1 + "    ");
                        }
                        else if (seatChart[i] == 0 && i >=10) {
                            Console.Write(i+1 + "   ");
                        }
                        else {
                            Console.Write("X    ");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine(format);
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
    
    public class Writer
    {
        public static async Task WriteAsync(Flight f)
        {
            using StreamWriter file = new("flights.txt", append: true);
            await file.WriteLineAsync(f.seatingCapacity + " " + f.pFirst + " " + f.pEconomy + " " + f.dAirport + " " + f.aAirport + " " + f.dTime + " " + f.aTime);
        }
    }

    public class Reader
    {
        public static void firstRead(Database d)
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("flights.txt");
            foreach (string line in lines)
            {
                Flight obj = new Flight();
                count++;
                string result;
                string sub = line;
                for (int i = 0; i < 6; i++)
                {
                    int endIndex = sub.IndexOf(" ");
                    result = sub.Substring(0, endIndex);
                    sub = sub.Substring(endIndex+1);
                    if (i == 0) {
                        obj.seatingCapacity = Convert.ToInt32(result);
                    }
                    if (i == 1) {
                        obj.pFirst = Convert.ToInt32(result);
                    }
                    if (i == 2) {
                        obj.pEconomy = Convert.ToInt32(result);
                    }
                    if (i == 3) {
                        obj.dAirport = result;
                    }
                    if (i == 4) {
                        obj.aAirport = result;
                    }
                    if (i == 5) {
                        obj.dTime = result;
                    }
                }
                obj.aTime = sub;
                d.addFlight(obj);
                obj.createSeatingChart();
            }
        }
        public static void ReadAll(Database d)
        {
            string format = "--------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            Console.WriteLine(format);
            Console.WriteLine("Here is a current list of flights available: ");
            Console.WriteLine("");
            for (int i = 0; i < d.numFlights; i++) {
                Console.WriteLine("Flight " + (i+1) + ": ");
                Console.WriteLine(d.database[i].flightDetails());
                if (i < (d.numFlights-1)) {
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("");
            Console.WriteLine(format);
        }

        public static void ReadSpecific(Database d, int x)
        {
            Console.WriteLine("");
            for (int i = 0; i < d.numFlights; i++) {
                if (i==(x-1)) {
                    Console.WriteLine("Flight " + (i+1) + ": ");
                    Console.WriteLine(d.database[i].flightDetails());
                }
            }
            Console.WriteLine("");
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
            int prompt = 0;
            int c = 0;
            int validSeat = 0;
            string format = "--------------------------------------------------------------------------------------------------------------------------------------------------------------------";

            Database d = new Database();
            Reader.firstRead(d);
            
            Console.WriteLine(format);
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
                if(person.Equals("administrator")) 
                {
                    Console.WriteLine(format);
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
                    Console.WriteLine(format);
                    Flight myObj = new Flight(one, two, three, four, five, six, seven);
                    d.addFlight(myObj);
                    Writer.WriteAsync(myObj);
                }
                else if(person.Equals("customer")) {
                    Console.Write("Please enter your first and last name - ");
                    cName = Console.ReadLine();
                    Console.Write("Please enter your age - ");
                    cAge = Convert.ToInt32(Console.ReadLine());
                    Reader.ReadAll(d);
                    Console.Write("Which flight would you like? (Just put the flight number) - ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Reader.ReadSpecific(d, num);
                    Console.Write("Is this flight correct? (Y/N) - ");
                    string a = Console.ReadLine();
                    bool pequal = String.Equals("Y", a, StringComparison.OrdinalIgnoreCase);
                    while(!pequal) {
                        Reader.ReadAll(d);
                        Console.Write("Which flight would you like? (Just put the flight number) - ");
                        num = Convert.ToInt32(Console.ReadLine());
                        Reader.ReadSpecific(d, num);
                        Console.Write("Is this flight correct? (Y/N) - ");
                        a = Console.ReadLine();
                        pequal = String.Equals("Y", a, StringComparison.OrdinalIgnoreCase);
                    }
                    d.database[num-1].printSeating();
                    Console.Write("You may now pick your seat. Which seat number would you like? (Just put the seat number) - ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    validSeat = d.database[num-1].takenSeat(n);
                    while (validSeat==0) {
                        d.database[num-1].printSeating();
                        Console.WriteLine("Sorry. That seat is taken. Please select an open seat (Just put the seat number) - ");
                        n = Convert.ToInt32(Console.ReadLine());
                        validSeat = d.database[num-1].takenSeat(n);
                    }
                    Console.WriteLine("");
                    Console.Write("You have picked seat number: " + n);
                    Console.WriteLine(". You are all set and your seat is reserved.");
                }
                Console.WriteLine("");
                Console.Write("Would you like to continue? (Y/N) - ");
                string response = Console.ReadLine();
                bool equal = String.Equals("Y", response, StringComparison.OrdinalIgnoreCase);
                if (!equal) {
                    c = 1;
                    Console.WriteLine("Please come again. Have a great day!");
                    Console.WriteLine(format);
                }
                else {
                    Console.WriteLine(format);
                    Console.Write("Hello! Welcome to the Booking Portal. Are you a customer or administrator? ");
                    person = Console.ReadLine();
                    person = person.ToLower();
                    prompt = 0;
                }
            }
        }
    }
}
