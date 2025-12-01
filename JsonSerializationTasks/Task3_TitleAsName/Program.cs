using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Task3_TitleAsName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Завдання 3: Серіалізувати Title як Name");
            Console.WriteLine("Серіалізовані дані, де Title зберігається як Name:\n");

            string filePath = "books.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл books.json не знайдено.");
                return;
            }

            string json = File.ReadAllText(filePath);

            List<BookInput>? sourceBooks = JsonSerializer.Deserialize<List<BookInput>>(json);

            if (sourceBooks is null)
            {
                Console.WriteLine("Не вдалося десеріалізувати JSON.");
                return;
            }

            List<Book> booksForSerialization = new List<Book>();

            foreach (var b in sourceBooks)
            {
                booksForSerialization.Add(new Book
                {
                    PublishingHouseId = b.PublishingHouseId,
                    Title = b.Title,
                    PublishingHouse = b.PublishingHouse
                });
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string outputJson = JsonSerializer.Serialize(booksForSerialization, options);
            Console.WriteLine(outputJson);
        }
    }
}
