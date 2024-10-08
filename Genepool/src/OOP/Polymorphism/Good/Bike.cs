using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Polymorphism.Good
{
    public class Bike: Vehicle
    {
        public int NumberOfWheels { get; set; }

        public override void Start()
        {
            Console.WriteLine("Bike is starting..");
        }

        public override void Stop()
        {
            Console.WriteLine("Bike is stopping");
        }
    }
}