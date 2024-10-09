using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.D.Good
{
    public class Car
    {
        private IEngine engine;

        public Car(IEngine engine) // Dependency injection
        {
            this.engine = engine;
        }

        public void StartCar()
        {
            engine.Start();
            Console.WriteLine("Car started.");
        }
    }
}