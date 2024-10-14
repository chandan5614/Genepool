using System;

namespace Genepool.Architectures.CleanArchitecture.Application.Dtos
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public Guid OwnerId { get; set; }  // Foreign key to Owner
    }
}
