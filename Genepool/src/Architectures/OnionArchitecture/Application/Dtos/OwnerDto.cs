using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.Architectures.OnionArchitecture.Application.Dtos
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();
    }
}