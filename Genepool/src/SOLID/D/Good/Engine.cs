using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.SOLID.D.Good
{
    public class Engine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Engine started.");
        }
    }
}