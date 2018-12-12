using System;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
        : base(options){}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { 
             Id = 1,
             FirstName = "Drake",
             LastName = "Bennion",
             Address = "Murray",
             Age = 26,
             ImageSrc = "src",
             Interests = "So much interest" });
        }
    }
}
