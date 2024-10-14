using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Genepool.Architectures.CleanArchitecture.Core.Entities
{
    public class Owner
    {
        // Unique identifier for the owner
        [Key]
        public Guid Id { get; set; }

        // Name of the owner
        [Required(ErrorMessage = "Owner name is required.")]
        [StringLength(100, ErrorMessage = "Owner name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        // Email of the owner
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        // Collection of vehicles owned by the owner
        public ICollection<Vehicle> Vehicles { get; set; }

        // Constructor
        public Owner()
        {
            // Initialize the collection to prevent null reference exceptions
            Vehicles = new List<Vehicle>();
        }

        // Additional business logic methods can be added here as needed
    }
}
