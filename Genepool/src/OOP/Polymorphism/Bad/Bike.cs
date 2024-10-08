using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Polymorphism.Bad
{
    public class Bike
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public void Start()
        {
            Console.WriteLine("Bike is starting.");
        }
        public void Stop()
        {
            Console.WriteLine("Bike is stopping.");
        }
    }
}