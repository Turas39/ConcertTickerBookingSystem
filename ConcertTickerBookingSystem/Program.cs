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

public interface IConcertType
{
    void DisplayDetails();
}

public class NormalConcert : IConcertType
{
    public void DisplayDetails()
    {
        Console.WriteLine("Koncert normalny z ustaloną ceną biletów i przypisanymi miejscami");
    }
}

public class VIPConcert : IConcertType
{
    public void DisplayDetails()
    {
        Console.WriteLine("Koncert klasy VIP dla ograniczonej ilości osób z możliwością spotkania z artystami");
    }
}

public class OnlineConcert : IConcertType
{
    public void DisplayDetails()
    {
        Console.WriteLine("Koncert online z niska ceną biletów transmitowany na platformach streamingowych");
    }
}

public class PrivateConcert : IConcertType
{
    public void DisplayDetails()
    {
        Console.WriteLine("Koncert prywatny dla zamkniętego grona osób z wysokimi kosztami");
    }
}


internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}