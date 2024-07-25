using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation4 World!");

        // Activities
        Running running = new Running(new DateTime(2024, 7, 21), 25, 5.0);
        Cycling cycling = new Cycling(new DateTime(2024, 7, 22), 60, 13.0);
        Swimming swimming = new Swimming(new DateTime(2024, 7, 23), 45, 30);

        // List of activities
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Show activity summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

public class Activity
{
    protected DateTime date;
    protected int lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Activity ({lengthInMinutes} min)";
    }
}

public class Running : Activity
{
    private double distanceInMiles;

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles) 
        : base(date, lengthInMinutes)
    {
        this.distanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return distanceInMiles;
    }

    public override double GetSpeed()
    {
        return (distanceInMiles / lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return lengthInMinutes / distanceInMiles;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {distanceInMiles} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

public class Cycling : Activity
{
    private double speedInMph;

    public Cycling(DateTime date, int lengthInMinutes, double speedInMph) 
        : base(date, lengthInMinutes)
    {
        this.speedInMph = speedInMph;
    }

    public override double GetDistance()
    {
        return (speedInMph * lengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speedInMph;
    }

    public override double GetPace()
    {
        return 60 / speedInMph;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():0.0} miles, Speed: {speedInMph:0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) 
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return (laps * 50) / 1000 * 0.62; // From meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return lengthInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
