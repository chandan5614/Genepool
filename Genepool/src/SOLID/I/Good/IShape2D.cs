using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.I.Good
{
    public interface IShape2D
    {
        double Area();
    }

    public class Circle : IShape2D
    {
        public double Radius { get; set; }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}