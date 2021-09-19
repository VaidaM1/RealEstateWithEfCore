using Microsoft.EntityFrameworkCore;
using RealEstate_with_efcore.Models;

namespace RealEstate_with_efcore.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Broker> Brokers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<CompanyBroker> CompanyBrokers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<CompanyBroker>()
                .HasKey(cb => new { cb.CompanyId, cb.BrokerId });
            modelbuilder.Entity<CompanyBroker>()
                .HasOne(cb => cb.Broker)
                .WithMany(b => b.CompanyBroker)
                .HasForeignKey(cb => cb.BrokerId);
            modelbuilder.Entity<CompanyBroker>()
                .HasOne(cb => cb.Broker)
                .WithMany(b => b.CompanyBroker)
                .HasForeignKey(cb => cb.BrokerId);

        }



    }


}
