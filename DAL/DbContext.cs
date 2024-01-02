using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Donation> Donations {  get; set; }
        
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>()
                .Property(d => d.Id)
                .IsRequired();
            modelBuilder.Entity<Donation>()
                .Property(d => d.UserId)
                .IsRequired();
            modelBuilder.Entity<Donation>()
                .Property(d => d.Amount)
                .IsRequired();
            modelBuilder.Entity<Donation>()
                .Property(d => d.ArticleId)
                .IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}