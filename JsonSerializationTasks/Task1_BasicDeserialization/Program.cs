using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task1_BasicDeserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Завдання 1: Десеріалізація JSON у класи");

            Console.WriteLine();

            string filePath = "books.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл books.json не знайдено.");
                return;
            }

            string json = File.ReadAllText(filePath);

            List<Book>? books = JsonSerializer.Deserialize<List<Book>>(json);

            if (books is null)
            {
                Console.WriteLine("Не вдалося десеріалізувати JSON.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"PublishingHouseId: {book.PublishingHouseId}");
                Console.WriteLine($"Publishing house: {book.PublishingHouse.Name}, address: {book.PublishingHouse.Adress}");
                Console.WriteLine();
            }
        }
    }
}
