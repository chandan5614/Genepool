using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.L.Good
{
    public abstract class Shape
    {
        public abstract double Area { get; }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area => Width * Height;
    }

    public class Square : Shape
    {
        private double sideLength;
        public double SideLength
        {
            get => sideLength;
            set => sideLength = value;
        }

        public override double Area => SideLength * SideLength;
    }
}