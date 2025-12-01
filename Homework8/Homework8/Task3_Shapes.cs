using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework8
{

    // Square наслідується від Rectangle,
    // але при присвоєнні Width/Height веде себе не як прямокутник,
    // тому Rectangle rect = new Square(); працює некоректно

    interface IShape
    {
        int GetArea();
    }

    class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : IShape
    {
        public int Side { get; set; }

        public int GetArea()
        {
            return Side * Side;
        }
    }
}
