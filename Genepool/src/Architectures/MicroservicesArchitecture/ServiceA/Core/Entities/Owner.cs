using System;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation property to related vehicles
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public Owner()
        {
            Id = Guid.NewGuid();
        }
    }
}
