using System;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Infrastructure
{
    public class UserContext : DbContext
    {
        public UserContext() { }

        public UserContext(DbContextOptions<UserContext> options)
        : base(options){}

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { 
             Id = 1,
             FirstName = "Doug",
             LastName = "Dockson",
             Address = "Murray",
             Age = 39,
             ImageSrc = "src",
             Interests = "So much interest" });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Sylvia",
                LastName = "Plat",
                Address = "Germany",
                Age = 44,
                ImageSrc = "src",
                Interests = "Poetry"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                FirstName = "Walt",
                LastName = "White",
                Address = "New Mexico",
                Age = 56,
                ImageSrc = "src",
                Interests = "Meth"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                FirstName = "Carl",
                LastName = "Boon",
                Address = "Massachusetts",
                Age = 26,
                ImageSrc = "src",
                Interests = "Sports"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 5,
                FirstName = "Penny",
                LastName = "Shelstorp",
                Address = "Canada",
                Age = 19,
                ImageSrc = "src",
                Interests = "Pink"
            });
        }
    }
}
