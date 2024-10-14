using System;

namespace Genepool.Architectures.CleanArchitecture.Application.Dtos
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
