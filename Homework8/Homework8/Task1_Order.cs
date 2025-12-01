using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework8
{

    // Порушено принцип Single Responsibility
    // Клас Order рахує суму, працює зі списком товарів, друкує замовлення, ще й завантажує його з файлу.

    class Item
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    class Order
    {
        private readonly List<Item> _items = new();

        public IReadOnlyList<Item> Items => _items;

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
        }

        public int GetItemCount()
        {
            return _items.Count;
        }

        public decimal CalculateTotalSum()
        {
            return _items.Sum(i => i.Price);
        }

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
    }

    interface IOrderRepository
    {
        void Load(Order order);
        void Save(Order order);
        void Update(Order order);
        void Delete(Order order);
    }

    class FileOrderRepository : IOrderRepository
    {
        public void Load(Order order)
        {
            /*...*/
        }

        public void Save(Order order)
        {
            /*...*/
        }

        public void Update(Order order)
        {
            /*...*/
        }

        public void Delete(Order order)
        {
            /*...*/
        }
    }

    interface IOrderPrinter
    {
        void PrintOrder(Order order);
        void ShowOrder(Order order);
    }

    class ConsoleOrderPrinter : IOrderPrinter
    {
        public void PrintOrder(Order order)
        {
            Console.WriteLine("=== Order ===");
            int index = 1;

            foreach (var item in order.Items)
            {
                Console.WriteLine($"[{index}] {item.Name} - {item.Price} грн");
                index++;
            }

            Console.WriteLine($"Total: {order.CalculateTotalSum()} грн");
        }

        public void ShowOrder(Order order)
        {
            PrintOrder(order);
        }
    }
}
