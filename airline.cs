/* 
Kalin Fleming
Intel Internship Airline Project
04/07/2021
Description: This program simulates an Airline website. The user can either be a customer or an administrator. The administrator
can create flights by inputting different flight descriptions. The program will store all flights into a text file named
"flights.txt". The administrator can also clear any previous reservations made by customers for all flights.
The customer can reserve a seat on a flight. The customer will be able to see a list of flights available
with the relevant descriptions and reserve a seat. If customers attempt to book the same seat in the same program simulation,
the customer will have to choose a different seat. 
*/

/* import files */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;


namespace Intel_Internship
{
    /* Flight class. This class contains all data pertaining to a flight, function to generate a seating chart,
    function to create a user-friendly string of flight information, function to keep track of seat reservations,
    a function to print out a seating chart to the user, and lastly a function to clean out all seat reservations for a flight */
    public class Flight
    {
                public int seatingCapacity;
                public int pFirst;
                public int pEconomy;
                public string dAirport;
                public string aAirport;
                public string dTime;
                public string aTime;
                public int idNum;
                public int[] seatChart;
                
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

                public void createSeatingChart(Database database, Flight f) {
                    f.seatChart = new int[seatingCapacity];
                    Reader.ReadSeating(database, f);
                }

                public string flightDetails()
                {
                    string x = "Capacity: " + seatingCapacity + ", 1st Class Ticket Price: " + pFirst + ", Economy Ticket Price: " + pEconomy + ", Departure Airport: " + dAirport + ", Arrival Airport: " + aAirport + ", Departure Time: " + dTime + ", Arrival Time: " + aTime;
                    return x;
                }

                public int takenSeat(int x) 
                {
                    int result = 0;
                    if (x>seatingCapacity) {
                        result = 3;
                        return result;
                    }
                    if (seatChart[x-1] == x) {
                        seatChart[x-1] = 0;
                        result = 1;
                        return result;
                    }
                    else {
                        return result;
                    }
                }

                public int fullFlight() 
                {
                    int result = 1;
                    for (int i = 0; i < seatingCapacity; i++) {
                        if (seatChart[i] == (i+1)) {
                            result = 0;
                        }
                    }
                    return result;
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
                        if (seatChart[i] == (i+1) && i < 10) {
                            Console.Write(i+1 + "    ");
                        }
                        else if (seatChart[i] == (i+1) && i >=10) {
                            Console.Write(i+1 + "   ");
                        }
                        else {
                            Console.Write("X    ");
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine(format);
                }

                public void cleanOut()
                {
                    for (int i = 0; i < seatingCapacity; i++) {
                        seatChart[i] = (i+1);
                    }
                }
    }
    
    /* Database class. This class contains a list of all flights, an integer to store
    the current number of flights, a function to add a flight to the list, and a 
    function to call the cleanOut() function for each flight in the database */
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

        public void clean()
        {
            for (int i = 0; i < numFlights; i++) {
                database[i].cleanOut();
            }
        }
    }
    
    /* Customer class. This class contains a customer's information such as the name and age */
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
    
    /* Writer class. This class writes flight information to the "flights.txt" file in order
    to maintain a list of flights across program instances. The WriteAsynch() function will also
    create a file that contains a seating chart for each individual flight with a unique file name.
    This class also contains a function to update seat reservations in each of the unique files */
    public class Writer
    {
        public static async Task WriteAsync(Flight f)
        {
            using StreamWriter file = new("flights.txt", append: true);
            await file.WriteLineAsync(f.seatingCapacity + " " + f.pFirst + " " + f.pEconomy + " " + f.dAirport + " " + f.aAirport + " " + f.dTime + " " + f.aTime);
            string name = "flight" + f.idNum + ".txt";
            using (FileStream fs = new FileStream(name, FileMode.Create))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    for (int i = 0; i < f.seatingCapacity; i++) {
                        w.Write(i+1);
                    }
                }
            }
        }

        public static async Task ChangeSeat(Flight f)
        {
            string name = "flight" + f.idNum + ".txt";
            using (FileStream fs = new FileStream(name, FileMode.Create))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    for (int i = 0; i < f.seatingCapacity; i++) {
                        w.Write(f.seatChart[i]);
                    }
                }
            }
        }
    }

    /* Reader class. This class contains a function that will read a list of all past flights
    from the "flights.txt" file and add it to the current database, a function to print out a
    list of current flights, a function to print out a specific flight given by the user, and a 
    function to to read the seating chart from a unique file for each flight */
    public class Reader
    {
        /* Read all flights from text file, add flights to flight database */
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
                obj.idNum = d.numFlights;
                obj.createSeatingChart(d, obj);
            }
        }

        /* Read an output all flights for customer to choose */
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

        /* Read and output specific flight information for customer */
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
        /* Read seating chart from a unique file, update seatChart array in the Flight class accordingly */
        public static void ReadSeating (Database d, Flight f)
        {
            string name = "flight" + f.idNum + ".txt";
            using (FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader r = new BinaryReader(fs))
                {
                    for (int i = 0; i < f.seatingCapacity; i++) {
                        int temp = r.ReadInt32();
                        f.seatChart[i] = temp;
                    }
                }
            }
        }
    }

    /* Airline class. This class contains our main program which simulates an airline reservation website */
    class Airline
    {
        static void Main(string[] args)
        {
            /* Initializing variables */
            int capacity, fticket, eticket, cAge;
            string dairport, aairport, dtime, atime, person, cName, response;
            int prompt = 0;
            int c = 0;
            int x = 0;
            int n = 0;
            int validSeat = 1;
            bool equal;
            string format = "--------------------------------------------------------------------------------------------------------------------------------------------------------------------";

            /* Creating database and receiving input from "flights.txt" file */ 
            Database d = new Database();
            Reader.firstRead(d);
            
            /* Initial prompt */
            Console.WriteLine(format);
            Console.Write("Hello! Welcome to the Booking Portal. Are you a customer or administrator? ");
            person = Console.ReadLine();
            person = person.ToLower();

            /* Keep iterating through program until user is done */
            while (c == 0) { 
                /* Ensuring user gives proper input */
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
                /* When user is an administrator */
                if(person.Equals("administrator")) 
                {
                    /* Documenting flight data from administrator */
                    Console.WriteLine(format);
                    Console.Write("Enter a seating capacity - ");
                    capacity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter price of 1st class ticket - $");
                    fticket = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter price of economy ticket - $");
                    eticket = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter departure airport - ");
                    dairport = Console.ReadLine();
                    Console.Write("Enter arrival airport - ");
                    aairport = Console.ReadLine();
                    Console.Write("Enter departure time (XX:XX) - ");
                    dtime = Console.ReadLine();
                    Console.Write("Enter arrival time (XX:XX) - ");
                    atime = Console.ReadLine();
                    /* Creating the specified flight, adding the flight to the database, and writing the flight to a file */
                    Flight myObj = new Flight(capacity, fticket, eticket, dairport, aairport, dtime, atime);
                    d.addFlight(myObj);
                    myObj.idNum = d.numFlights;
                    Writer.WriteAsync(myObj);
                    /* Asking administrator if they would like to re-set all flights. If yes, call the clean function in the database class */
                    Console.Write("Would you like to re-set all flights? This would delete any previous seat reservations, all of the flights would have all open seats. (Y/N) - ");
                    response = Console.ReadLine();
                    equal = String.Equals("Y", response, StringComparison.OrdinalIgnoreCase);
                    if (equal) {
                        d.clean();
                    }
                    Console.WriteLine(format);
                }
                /* When user is a customer */
                else if(person.Equals("customer")) {
                    /* Documenting customer information */
                    Console.Write("Please enter your first and last name - ");
                    cName = Console.ReadLine();
                    Console.Write("Please enter your age - ");
                    cAge = Convert.ToInt32(Console.ReadLine());
                    /* Printing out flight list */
                    Reader.ReadAll(d);
                    /* Checking to see there are no available flights */
                    if (d.numFlights == 0) {
                        Console.WriteLine("Sorry. There are no current flights available. Please come back and check at a later time");
                    }
                    else {
                        /* Asking customer what flight they would like */
                        Console.Write("Which flight would you like? (Just put the flight number) - ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        /* Checking if flight number is valid */
                        if (num > d.numFlights) {
                            x = 1;
                        }
                        while (x==1) {
                            Console.WriteLine("That is not a valid flight number. Please try again");
                            Console.Write("Which flight would you like? (Just put the flight number) - ");
                            num = Convert.ToInt32(Console.ReadLine());
                            if (num<=d.numFlights) {
                                x = 0;
                            }
                        }
                        /* Checking if flight is full (all seats are reserved) */
                        if (d.database[num-1].fullFlight() == 1) {
                            x = 1;
                        }
                        while (x == 1) {
                            Console.WriteLine("Sorry. That flight is full. Please try again.");
                            Console.Write("Which flight would you like? (Just put the flight number) - ");
                            num = Convert.ToInt32(Console.ReadLine());
                            if (d.database[num-1].fullFlight() == 0) {
                                x = 0;
                            }
                        }
                        /* Printing out specific flight and confirming with customer */
                        Reader.ReadSpecific(d, num);
                        Console.Write("Is this flight correct? (Y/N) - ");
                        string a = Console.ReadLine();
                        bool pequal = String.Equals("Y", a, StringComparison.OrdinalIgnoreCase);
                        /* Keep asking customer to choose a flight until they are satisfied with their choice */
                        while(!pequal) {
                            Reader.ReadAll(d);
                            Console.Write("Which flight would you like? (Just put the flight number) - ");
                            num = Convert.ToInt32(Console.ReadLine());
                            /* Checking if flight number is valid */
                            if (num > d.numFlights) {
                                x = 1;
                            }
                            while (x==1) {
                                Console.WriteLine("That is not a valid flight number. Please try again");
                                Console.Write("Which flight would you like? (Just put the flight number) - ");
                                num = Convert.ToInt32(Console.ReadLine());
                                if (num<=d.numFlights) {
                                    x = 0;
                                }
                            }
                            Reader.ReadSpecific(d, num);
                            Console.Write("Is this flight correct? (Y/N) - ");
                            a = Console.ReadLine();
                            pequal = String.Equals("Y", a, StringComparison.OrdinalIgnoreCase);
                        }
                        /* Print seating chart and ask customer what seat they would like */
                        d.database[num-1].printSeating();
                        Console.Write("You may now pick your seat. Which seat number would you like? (Just put the seat number) - ");
                        n = Convert.ToInt32(Console.ReadLine());
                        validSeat = d.database[num-1].takenSeat(n);
                        /* Checking if that seat number is valid. If not, ask again */
                        while (validSeat==3) {
                            d.database[num-1].printSeating();
                            Console.Write("That is not a valid seat number. Please pick a valid seat (Just put the seat number) - ");
                            n = Convert.ToInt32(Console.ReadLine());
                            validSeat = d.database[num-1].takenSeat(n);
                        }
                        /* If that seat has been taken, keep asking customer what seat they would like until they make a valid choice */
                        while (validSeat==0) {
                            d.database[num-1].printSeating();
                            Console.Write("Sorry. That seat is taken. Please select an open seat (Just put the seat number) - ");
                            n = Convert.ToInt32(Console.ReadLine());
                            validSeat = d.database[num-1].takenSeat(n);
                        }
                        /* Printing out seat number and updated seating chart */
                        Console.WriteLine("");
                        Console.WriteLine("You have picked seat number: " + n);
                        d.database[num-1].printSeating();
                        Writer.ChangeSeat(d.database[num-1]);
                        Console.WriteLine("");
                        Console.WriteLine("You are all set and your seat is reserved.");
                    }
                }
                /* Determining if user would like to continue to create/book flights */
                Console.WriteLine("");
                Console.Write("Would you like to continue? (Y/N) - ");
                response = Console.ReadLine();
                equal = String.Equals("Y", response, StringComparison.OrdinalIgnoreCase);
                /* Exiting the program */
                if (!equal) {
                    c = 1;
                    Console.WriteLine("Please come again. Have a great day!");
                    Console.WriteLine(format);
                }
                /* Re-printing initial prompt */
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
