using CountryVoteModels.DBModel;
using Microsoft.EntityFrameworkCore;

namespace CountryVoteDataBaseContext
{
    public class CountryVoteDbContext : DbContext
    {
        public CountryVoteDbContext (DbContextOptions<CountryVoteDbContext> options) :base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Country)
            .WithMany(c => c.User)
            .HasForeignKey(u => u.idCountry)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
