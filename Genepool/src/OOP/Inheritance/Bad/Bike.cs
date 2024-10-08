using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Inheritance.Bad
{
    public class Bike
    {
        public string brand;
        public string model;
        public int year;
        public int numberOfWheels;

        public void Start()
        {
            Console.WriteLine("Bike is starting...");
        }

        public void Stop()
        {
            Console.WriteLine("Bike is stopping");
        }
    }
}