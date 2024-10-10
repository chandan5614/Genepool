using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.Architectures.OnionArchitecture.Application.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int OwnerId { get; set; }
    }
}