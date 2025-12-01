using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace Task2_IgnorePublishingHouseId
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Завдання 2: Не серіалізувати PublishingHouseId\n");

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

            Console.WriteLine("Оригінальні дані (десеріалізовані):");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, PublishingHouseId: {book.PublishingHouseId}");
            }

            Console.WriteLine();
            Console.WriteLine("Серіалізовані дані без PublishingHouseId:\n");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string outputJson = JsonSerializer.Serialize(books, options);
            Console.WriteLine(outputJson);
        }
    }
}
