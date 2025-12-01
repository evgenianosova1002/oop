using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework8
{

    // Інтерфейс IItem занадто великий
    // Деяким товарам не потрібні колір або розмір, але вони все одно змушені реалізовувати методи

    interface IHasPrice
    {
        void SetPrice(double price);
    }

    interface IDiscountable
    {
        void ApplyDiscount(string discount);
    }

    interface IPromocodeApplicable
    {
        void ApplyPromocode(string promocode);
    }

    interface IColored
    {
        void SetColor(byte color);
    }

    interface ISized
    {
        void SetSize(byte size);
    }

    class Book : IHasPrice, IDiscountable
    {
        public double Price { get; private set; }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public void ApplyDiscount(string discount)
        {
            /*...*/
        }
    }

    class Outerwear : IHasPrice, IDiscountable, IColored, ISized
    {
        public double Price { get; private set; }
        public byte Color { get; private set; }
        public byte Size { get; private set; }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public void ApplyDiscount(string discount)
        {
            /*...*/
        }

        public void SetColor(byte color)
        {
            Color = color;
        }

        public void SetSize(byte size)
        {
            Size = size;
        }
    }
}
