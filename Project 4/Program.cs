using System;

namespace GeographyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення об’єкта типу River
            River dnipro = new River()
            {
                X = 48.45,
                Y = 35.05,
                Name = "Dnipro",
                Description = "Main river of Ukraine",
                FlowSpeed = 100,
                TotalLength = 2201
            };

            // Створення об’єкта типу Mountain
            Mountain hoverla = new Mountain()
            {
                X = 48.16,
                Y = 24.5,
                Name = "Hoverla",
                Description = "Highest mountain in Ukraine",
                HighestPoint = "2061 m"
            };

            // Вивід інформації
            Console.WriteLine(dnipro.GetInfoMethod());
            Console.WriteLine(hoverla.GetInfoMethod());
        }
    }
}
