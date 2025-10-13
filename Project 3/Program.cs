using System;

class Program
{
    static void Main()
    {
        Converter converter = new Converter(41.2m, 43.8m);

        Console.WriteLine("Enter the amount in UAH (Ukrainian Hryvnia):");
        decimal uah = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Convert to which currency? (USD / EUR):");
        string currency = Console.ReadLine();

        decimal result = converter.ConvertFromUah(uah, currency);
        Console.WriteLine($"{uah} UAH = {result:F2} {currency.ToUpper()}");

        Console.WriteLine("\nEnter the amount in foreign currency to convert to UAH:");
        decimal foreignAmount = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter the currency (USD / EUR):");
        string currency2 = Console.ReadLine();

        decimal result2 = converter.ConvertToUah(foreignAmount, currency2);
        Console.WriteLine($"{foreignAmount} {currency2.ToUpper()} = {result2:F2} UAH");
    }
}
