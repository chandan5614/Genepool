using System;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Foreign key for Owner
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public Vehicle()
        {
            Id = Guid.NewGuid();
        }
    }
}
