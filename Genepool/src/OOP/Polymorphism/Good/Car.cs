using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Polymorphism.Good
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }

        public override void Start()
        {
            Console.WriteLine("Car is starting...");
        }

        public override void Stop()
        {
            Console.WriteLine("Car is stopping");
        }
    }
}