using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ST10109685Prog7311.Models;

namespace ST10109685Prog7311.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.FarmerEmail)
                .HasPrincipalKey(u => u.Email)
                .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
