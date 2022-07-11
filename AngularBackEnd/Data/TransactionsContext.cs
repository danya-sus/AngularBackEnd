using AngularBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularBackEnd.Data
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSnakeCaseNamingConvention();

        public DbSet<AllData> data_all { get; set; }
        public DbSet<Airline> airline_company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllData>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
