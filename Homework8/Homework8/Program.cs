using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoTask1();
            //DemoTask2();
            //DemoTask3();
            //DemoTask4();
        }

        static void DemoTask1()
        {
            var order = new Order();
            order.AddItem(new Item { Name = "Book", Price = 100 });
            order.AddItem(new Item { Name = "T-shirt", Price = 250 });

            IOrderPrinter printer = new ConsoleOrderPrinter();
            printer.ShowOrder(order);
        }

        static void DemoTask2()
        {
            ILogger logger = new ConsoleLogger();
            var emailSender = new EmailSender(logger);

            var e1 = new Email { From = "Me", To = "Vasya", Theme = "Who are you?" };
            var e2 = new Email { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
            var e3 = new Email { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
            var e4 = new Email { From = "Vasya", To = "Me", Theme = "washing machines!" };
            var e5 = new Email { From = "Me", To = "Vasya", Theme = "Yes" };
            var e6 = new Email { From = "Vasya", To = "Petya", Theme = "+2" };

            emailSender.Send(e1);
            emailSender.Send(e2);
            emailSender.Send(e3);
            emailSender.Send(e4);
            emailSender.Send(e5);
            emailSender.Send(e6);
        }

        static void DemoTask3()
        {
            IShape rect = new Rectangle { Width = 5, Height = 10 };
            Console.WriteLine(rect.GetArea()); // 50

            IShape square = new Square { Side = 5 };
            Console.WriteLine(square.GetArea()); // 25
        }

        static void DemoTask4()
        {
            var book = new Book();
            book.SetPrice(200);
            book.ApplyDiscount("10%");

            var jacket = new Outerwear();
            jacket.SetPrice(1500);
            jacket.SetColor(1);
            jacket.SetSize(42);
            jacket.ApplyDiscount("15%");
        }
    }
}
