namespace Genepool.src.Architectures.OnionArchitecture.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}