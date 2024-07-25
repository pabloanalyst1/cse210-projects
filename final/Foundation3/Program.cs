using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");

        // Here I write the addresses
        Address address1 = new Address("615 Skull Dr", "Manchester City", "CA", "USA");
        Address address2 = new Address("7894 Cherry Ln", "Old Town", "TX", "USA");
        Address address3 = new Address("46 Colibri Rd", "Joyvillage", "CO", "USA");

        // Here I write the events
        Lecture lecture = new Lecture("Robots takedown", "An insightful lecture on the terrifying robots", "04/19/2023", "2:00 PM", address1, "Dr. Jane Smith", 150);
        Reception reception = new Reception("Red carpet", "A glamorous famous event", "09/15/2024", "7:15 PM", address2, "redcarpet@bombevents.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Guatemala Carnival", "A wonderful event dedicated to Guatemala", "09/15/2023", "12:00 AM", address3, "Partial cloudy");

        // The list of events
        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        // Display event details
        foreach (Event ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

public class Event
{
    protected string title;
    protected string description;
    protected string date;
    protected string time;
    protected Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {date}";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\nTitle: {title}\nDate: {date}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\nTitle: {title}\nDate: {date}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\nTitle: {title}\nDate: {date}";
    }
}
