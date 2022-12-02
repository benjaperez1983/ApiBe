using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApiBEDbContext : DbContext, IApiBEDbContext
    {
        public ApiBEDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
        public DbSet<PricesDetail> PricesDetail { get; set; }
        public DbSet<PricesHeader> PricesHeader { get; set; }
    }
}
