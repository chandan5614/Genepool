using Microsoft.EntityFrameworkCore;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Infrastructure.Configurations
{
    public class ServiceADbContext : DbContext
    {
        public ServiceADbContext(DbContextOptions<ServiceADbContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Owner entity
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Owner>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Owner>()
                .Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Configure the Vehicle entity
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Make)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Year)
                .IsRequired();

            // Configure the relationships
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Owner)
                .WithMany(o => o.Vehicles)
                .HasForeignKey(v => v.OwnerId);
        }
    }
}
