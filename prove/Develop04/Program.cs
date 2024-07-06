using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_activityName}");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine($"Well done! You have completed the {_activityName} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b"); 
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b"); 
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b"); 
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        Start();
        int remainingTime = _duration;
        while (remainingTime > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            remainingTime -= 4;
            if (remainingTime <= 0) break;
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            remainingTime -= 4;
        }
        End();
    }
}

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        Start();
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        int remainingTime = _duration - 3;
        while (remainingTime > 0)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
            remainingTime -= 5;
        }
        End();
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        Start();
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        ShowCountdown(5);

        int remainingTime = _duration - 5;
        int itemCount = 0;
        Console.WriteLine("Start listing items:");

        while (remainingTime > 0)
        {
            string item = Console.ReadLine();
            itemCount++;
            remainingTime--;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        End();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}
