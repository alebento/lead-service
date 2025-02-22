using Microsoft.EntityFrameworkCore;
using LeadsService.Domain.Entities;

namespace LeadsService.Infrastructure.Data
{
    public class LeadsDbContext : DbContext
    {
        public LeadsDbContext(DbContextOptions<LeadsDbContext> options) : base(options) { }

        public DbSet<DbLead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbLead>()
                .Property(l => l.Price)
                .HasPrecision(18, 2);
        }
    }
}
