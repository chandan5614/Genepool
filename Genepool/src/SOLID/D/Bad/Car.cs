using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.D.Bad
{
    public class Car
    {
       private Engine engine;

        public Car()
        {
            this.engine = new Engine(); // Direct dependency on concrete Engine class
        }

        public void StartCar()
        {
            engine.Start();
            Console.WriteLine("Car started.");
        } 
    }
}