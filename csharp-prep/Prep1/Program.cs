using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        //Ask the user for their name//

        Console.WriteLine("What is your first name?");
        string first = Console.ReadLine();

        Console.WriteLine("What is your last name?");
        string last = Console.ReadLine();

        Console.WriteLine($"Your full name is {last}, {first} {last}");

    }
}