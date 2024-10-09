using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.I.Bad
{
    public interface IShape
    {
        double Area();
        double Volume(); // Not all shapes have volume
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        // Volume not applicable for 2D shapes
        public double Volume()
        {
            throw new InvalidOperationException("Volume not applicable for 2D shapes.");
        }
    }

    public class Sphere : IShape
    {
        public double Radius { get; set; }

        public double Area()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}