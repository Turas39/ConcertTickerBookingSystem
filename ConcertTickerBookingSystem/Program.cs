﻿using System;
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

public class BookingSystem
{
    private List<Concert> concerts = new List<Concert>();
    private List<Ticket> tickets = new List<Ticket>();

    public void AddConcert(Concert concert)
    {
        concerts.Add(concert);
        Console.WriteLine($"Dodano koncert: {concert.Name} w dniu {concert.Date}.");
    }

    public Ticket BookTicket(Concert concert, decimal price, int seatNumber)
    {
        if (concert.AvailableSeats <= 0)
        {
            throw new Exception("Brak dostępnych miejsc na ten koncert.");
        }

        concert.AvailableSeats--;
        var ticket = new Ticket(concert, price, seatNumber);
        tickets.Add(ticket);

        Console.WriteLine($"Zarezerwowano bilet na koncert {concert.Name} dla miejsca {seatNumber}.");
        return ticket;
    }

    public IEnumerable<Concert> GetConcerts(Func<Concert, bool> filter)
    {
        return concerts.Where(filter);
    }
    
    public void DisplayConcertsByDateOrLocation(DateTime? date = null, string location = null)
    {
        var filteredConcerts = concerts.Where(c => (date == null || c.Date.Date == date.Value.Date) &&
                                                   (location == null || c.Location == location));

        foreach (var concert in filteredConcerts)
        {
            Console.WriteLine($"Koncert: {concert.Name}, Data: {concert.Date}, Lokalizacja: {concert.Location}, Dostępne miejsca: {concert.AvailableSeats}");
        }
    }
    
    public void GenerateReport()
    {
        Console.WriteLine("Raport o liczbie sprzedanych biletów:");
        foreach (var concert in concerts)
        {
            var soldTickets = tickets.Count(t => t.Concert == concert);
            Console.WriteLine($"Koncert: {concert.Name}, Sprzedane bilety: {soldTickets}");
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        BookingSystem bookingSystem = new BookingSystem();
        
        var concert1 = new Concert("Rolling Loud", new DateTime(2025, 6, 15), "Miami", 50000);
        var concert2 = new Concert("Clout Festival", new DateTime(2025, 7, 20), "Warszawa", 2000);

        bookingSystem.AddConcert(concert1);
        bookingSystem.AddConcert(concert2);
        
        bookingSystem.BookTicket(concert1, 2000, 1);
        
        Console.WriteLine("Koncerty w dniu 2025-06-15:");
        bookingSystem.DisplayConcertsByDateOrLocation(date: new DateTime(2025, 6, 15));
        
        bookingSystem.GenerateReport();
    }
}