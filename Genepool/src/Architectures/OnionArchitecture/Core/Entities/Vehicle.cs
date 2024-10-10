namespace Genepool.src.Architectures.OnionArchitecture.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }

        // Foreign key
        public int OwnerId { get; set; }
        public Owner Owner { get; set; } // Navigation property
    }
}