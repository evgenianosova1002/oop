using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            Console.WriteLine($"You entered the number {number}");
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid integer.");
        }
    }
}

