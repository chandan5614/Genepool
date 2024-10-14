using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Genepool.Architectures.OnionArchitecture.Core.Entities
{
    public class Vehicle
    {
        // Unique identifier for the vehicle
        [Key]
        public Guid Id { get; set; }

        // Make of the vehicle
        [Required(ErrorMessage = "Vehicle make is required.")]
        [StringLength(50, ErrorMessage = "Vehicle make cannot be longer than 50 characters.")]
        public string Make { get; set; }

        // Model of the vehicle
        [Required(ErrorMessage = "Vehicle model is required.")]
        [StringLength(50, ErrorMessage = "Vehicle model cannot be longer than 50 characters.")]
        public string Model { get; set; }

        // Year of manufacture
        [Required(ErrorMessage = "Year is required.")]
        [Range(1886, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1886.")]
        public int Year { get; set; }

        // Foreign key to link the vehicle to its owner
        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }

        // Navigation property to the owner
        public Owner Owner { get; set; }

        // Additional business logic methods can be added here as needed
    }
}
