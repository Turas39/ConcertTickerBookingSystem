using System;
using System.Collections.Generic;
using System.Linq;

public class Concert
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; set; }

    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
    }
}

public class Ticket
{
    public Concert Concert { get; private set; }
    public decimal Price { get; private set; }
    public int SeatNumber { get; private set; }

    public Ticket(Concert concert, decimal price, int seatNumber)
    {
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}