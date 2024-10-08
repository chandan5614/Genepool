using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Inheritance.NoInheritance
{
    public class Car
    {
        public string brand;
        public string model;
        public int year;
        public int numberOfDoors;
        public int numberOfWheels;

        public void Start()
        {
            Console.WriteLine("Car is starting...");
        }

        public void Stop()
        {
            Console.WriteLine("Car is stopping");
        }
    }
}