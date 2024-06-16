using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        
        char letter;
        string sign = string.Empty; // Initialize sign as an empty string

        // Determine the letter grade
        if (grade >= 90) {
            letter = 'A';
        } else if (grade >= 80) {
            letter = 'B';
        } else if (grade >= 70) {
            letter = 'C';
        } else if (grade >= 60) {
            letter = 'D';
        } else {
            letter = 'F';
        }

        // Determine the sign for the grade
        if (letter != 'A' && letter != 'F') { // No A+ or F+/F-
            int lastDigit = grade % 10;
            if (lastDigit >= 7) {
                sign = "+";
            } else if (lastDigit < 3) {
                sign = "-";
            }
        }

        // Print the letter grade with the sign if applicable
        if (string.IsNullOrEmpty(sign)) {
            Console.WriteLine($"Your grade is: {letter}");
        } else {
            Console.WriteLine($"Your grade is: {letter}{sign}");
        }

        // Determine if the user passed or failed
        if (grade >= 70) {
            Console.WriteLine("Congratulations, you passed the course!");
        } else {
            Console.WriteLine("You did not pass the course. Better luck next time!");
        }
    }
}
