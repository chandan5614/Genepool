using System;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Dtos
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Guid OwnerId { get; set; }
    }
}
