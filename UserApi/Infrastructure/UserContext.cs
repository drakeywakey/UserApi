using System;
using System.Collections.Generic;
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
            var seedData = new List<User>
            {
                new User{ Id = 1, FirstName = "Silas", LastName = "Maldonado", Address = "427 Vestibulum. Avenue", Age = 18, Interests = "Donec fringilla. Donec feugiat metus sit", ImageSrc = "https://randomuser.me/api/portraits/men/1.jpg" },
                new User{ Id = 2, FirstName = "Amy", LastName = "Holland", Address = "Ap #771-9668 At Street", Age = 45, Interests = "vitae, orci. Phasellus", ImageSrc = "https://randomuser.me/api/portraits/women/1.jpg" },
                new User{ Id = 3, FirstName = "Nathaniel", LastName = "Phillips", Address = "655-7949 Sapien. St.", Age = 44, Interests = "libero", ImageSrc = "https://randomuser.me/api/portraits/men/2.jpg" },
                new User{ Id = 4, FirstName = "Margaret", LastName = "Johnson", Address = "3492 Convallis Ave", Age = 18, Interests = "gravida sagittis. Duis gravida. Praesent eu", ImageSrc = "https://randomuser.me/api/portraits/women/2.jpg" },
                new User{ Id = 5, FirstName = "Leroy", LastName = "Bowen", Address = "P.O. Box 282, 6833 Pharetra Ave", Age = 19, Interests = "arcu. Aliquam ultrices iaculis odio.", ImageSrc = "https://randomuser.me/api/portraits/men/3.jpg" },
                new User{ Id = 6, FirstName = "Frances", LastName = "Gillespie", Address = "969-659 Risus. Avenue", Age = 39, Interests = "augue id ante dictum", ImageSrc = "https://randomuser.me/api/portraits/women/3.jpg" },
                new User{ Id = 7, FirstName = "Harper", LastName = "Roach", Address = "Ap #660-6915 Dolor Av.", Age = 64, Interests = "tellus. Suspendisse sed dolor.", ImageSrc = "https://randomuser.me/api/portraits/men/4.jpg" },
                new User{ Id = 8, FirstName = "Florence", LastName = "Dejesus", Address = "Ap #417-5283 Suspendisse St.", Age = 20, Interests = "velit. Aliquam nisl. Nulla eu", ImageSrc = "https://randomuser.me/api/portraits/women/4.jpg" },
                new User{ Id = 9, FirstName = "Louis", LastName = "Sims", Address = "504 Lectus St.", Age = 35, Interests = "Maecenas malesuada fringilla est. Mauris eu", ImageSrc = "https://randomuser.me/api/portraits/men/5.jpg" },
                new User{ Id = 10, FirstName = "Olivia", LastName = "Adkins", Address = "Ap #664-8457 Ligula. Street", Age = 38, Interests = "fringilla euismod enim. Etiam", ImageSrc = "https://randomuser.me/api/portraits/women/5.jpg" },
                new User{ Id = 11, FirstName = "Leo", LastName = "Savage", Address = "P.O. Box 793, 1889 Pede Street", Age = 25, Interests = "fermentum arcu. Vestibulum ante ipsum primis", ImageSrc = "https://randomuser.me/api/portraits/men/6.jpg" },
                new User{ Id = 13, FirstName = "Galvin", LastName = "Huber", Address = "1310 Felis Ave", Age = 44, Interests = "auctor vitae, aliquet nec,", ImageSrc = "https://randomuser.me/api/portraits/men/7.jpg" },
                new User{ Id = 15, FirstName = "Xander", LastName = "Whitfield", Address = "582-8227 Dolor Street", Age = 30, Interests = "bibendum. Donec", ImageSrc = "https://randomuser.me/api/portraits/men/8.jpg" },
                new User{ Id = 17, FirstName = "Guy", LastName = "Baird", Address = "P.O. Box 529, 5415 Ut Rd.", Age = 60, Interests = "fermentum metus. Aenean", ImageSrc = "https://randomuser.me/api/portraits/men/9.jpg" },
                new User{ Id = 19, FirstName = "Logan", LastName = "Tillman", Address = "619-7434 Purus St.", Age = 50, Interests = "Duis elementum, dui quis", ImageSrc = "https://randomuser.me/api/portraits/men/10.jpg" },
                new User{ Id = 21, FirstName = "Gage", LastName = "Rowland", Address = "383-256 Proin St.", Age = 56, Interests = "odio vel est tempor bibendum.", ImageSrc = "https://randomuser.me/api/portraits/men/11.jpg" },
                new User{ Id = 23, FirstName = "Bradley", LastName = "Key", Address = "132-2692 Sed Street", Age = 53, Interests = "tincidunt congue", ImageSrc = "https://randomuser.me/api/portraits/men/12.jpg" },
                new User{ Id = 25, FirstName = "Sawyer", LastName = "Valenzuela", Address = "7967 Diam. Avenue", Age = 40, Interests = "pede sagittis augue, eu", ImageSrc = "https://randomuser.me/api/portraits/men/13.jpg" },
                new User{ Id = 27, FirstName = "Lane", LastName = "Wilder", Address = "858-9008 Pharetra. Ave", Age = 56, Interests = "malesuada augue", ImageSrc = "https://randomuser.me/api/portraits/men/14.jpg" },
                new User{ Id = 29, FirstName = "Tanner", LastName = "Carver", Address = "Ap #604-9659 Molestie Av.", Age = 33, Interests = "amet, consectetuer adipiscing", ImageSrc = "https://randomuser.me/api/portraits/men/15.jpg" },
                new User{ Id = 31, FirstName = "Seth", LastName = "Hartman", Address = "Ap #772-4152 Ipsum Ave", Age = 34, Interests = "Suspendisse sagittis.", ImageSrc = "https://randomuser.me/api/portraits/men/16.jpg" },
                new User{ Id = 33, FirstName = "Steven", LastName = "Mcbride", Address = "748 Eu Rd.", Age = 56, Interests = "ultricies dignissim lacus. Aliquam rutrum", ImageSrc = "https://randomuser.me/api/portraits/men/17.jpg" },
                new User{ Id = 35, FirstName = "Davis", LastName = "Harrison", Address = "798-3361 Nisl Rd.", Age = 64, Interests = "Suspendisse non leo.", ImageSrc = "https://randomuser.me/api/portraits/men/18.jpg" },
                new User{ Id = 37, FirstName = "Baxter", LastName = "Hurst", Address = "Ap #462-2361 Ut St.", Age = 63, Interests = "ac mattis", ImageSrc = "https://randomuser.me/api/portraits/men/19.jpg" },
                new User{ Id = 39, FirstName = "Branden", LastName = "Richard", Address = "P.O. Box 928, 5370 Convallis Road", Age = 53, Interests = "molestie pharetra nibh.", ImageSrc = "https://randomuser.me/api/portraits/men/20.jpg" },
                new User{ Id = 41, FirstName = "Demetrius", LastName = "Gilliam", Address = "7669 Diam. Rd.", Age = 65, Interests = "id, blandit at, nisi.", ImageSrc = "https://randomuser.me/api/portraits/men/21.jpg" },
                new User{ Id = 43, FirstName = "Aladdin", LastName = "Hawkins", Address = "P.O. Box 833, 7057 Luctus St.", Age = 52, Interests = "egestas. Aliquam nec enim.", ImageSrc = "https://randomuser.me/api/portraits/men/22.jpg" },
                new User{ Id = 45, FirstName = "Lars", LastName = "Atkins", Address = "818 Et St.", Age = 58, Interests = "lectus pede, ultrices a, auctor", ImageSrc = "https://randomuser.me/api/portraits/men/23.jpg" },
                new User{ Id = 47, FirstName = "Anthony", LastName = "Patterson", Address = "3691 Magnis Av.", Age = 54, Interests = "Morbi quis urna. Nunc quis", ImageSrc = "https://randomuser.me/api/portraits/men/24.jpg" },
                new User{ Id = 49, FirstName = "Burke", LastName = "Robinson", Address = "1574 Sem St.", Age = 42, Interests = "amet massa. Quisque porttitor eros", ImageSrc = "https://randomuser.me/api/portraits/men/25.jpg" },
                new User{ Id = 12, FirstName = "Maggie", LastName = "Beck", Address = "P.O. Box 764, 4218 Mattis St.", Age = 63, Interests = "Quisque ac", ImageSrc = "https://randomuser.me/api/portraits/women/6.jpg" },
                new User{ Id = 14, FirstName = "Naomi", LastName = "Gaines", Address = "5398 Vivamus St.", Age = 42, Interests = "dui quis accumsan convallis,", ImageSrc = "https://randomuser.me/api/portraits/women/7.jpg" },
                new User{ Id = 16, FirstName = "Sacha", LastName = "Strong", Address = "6397 A, Rd.", Age = 40, Interests = "vulputate, posuere vulputate, lacus. Cras interdum.", ImageSrc = "https://randomuser.me/api/portraits/women/8.jpg" },
                new User{ Id = 18, FirstName = "Idona", LastName = "Hoover", Address = "P.O. Box 294, 9747 Facilisis, Av.", Age = 18, Interests = "iaculis odio. Nam", ImageSrc = "https://randomuser.me/api/portraits/women/9.jpg" },
                new User{ Id = 20, FirstName = "Wendy", LastName = "Oneill", Address = "P.O. Box 401, 3347 Mauris Ave", Age = 37, Interests = "sed pede.", ImageSrc = "https://randomuser.me/api/portraits/women/10.jpg" },
                new User{ Id = 22, FirstName = "Xyla", LastName = "Johnson", Address = "P.O. Box 925, 1137 Consectetuer Rd.", Age = 27, Interests = "eu tempor erat", ImageSrc = "https://randomuser.me/api/portraits/women/11.jpg" },
                new User{ Id = 24, FirstName = "Hyacinth", LastName = "Dickerson", Address = "P.O. Box 977, 3060 Cras Road", Age = 61, Interests = "augue malesuada", ImageSrc = "https://randomuser.me/api/portraits/women/12.jpg" },
                new User{ Id = 26, FirstName = "Lisandra", LastName = "Hawkins", Address = "Ap #171-8637 Luctus Rd.", Age = 50, Interests = "risus varius orci, in consequat enim", ImageSrc = "https://randomuser.me/api/portraits/women/13.jpg" },
                new User{ Id = 28, FirstName = "Cameran", LastName = "Nixon", Address = "P.O. Box 593, 6144 Magnis St.", Age = 28, Interests = "massa. Vestibulum accumsan neque et", ImageSrc = "https://randomuser.me/api/portraits/women/14.jpg" },
                new User{ Id = 30, FirstName = "Imogene", LastName = "Flowers", Address = "8520 Aliquam Ave", Age = 45, Interests = "Nam interdum enim non nisi.", ImageSrc = "https://randomuser.me/api/portraits/women/15.jpg" },
                new User{ Id = 32, FirstName = "Myra", LastName = "Faulkner", Address = "9469 Diam Rd.", Age = 30, Interests = "ornare lectus justo eu", ImageSrc = "https://randomuser.me/api/portraits/women/16.jpg" },
                new User{ Id = 34, FirstName = "Mariam", LastName = "Cline", Address = "863-5079 Ante St.", Age = 26, Interests = "nunc, ullamcorper eu,", ImageSrc = "https://randomuser.me/api/portraits/women/17.jpg" },
                new User{ Id = 36, FirstName = "Xyla", LastName = "Jennings", Address = "3630 A Rd.", Age = 60, Interests = "ornare, facilisis eget,", ImageSrc = "https://randomuser.me/api/portraits/women/18.jpg" },
                new User{ Id = 38, FirstName = "Olivia", LastName = "Dorsey", Address = "6097 Bibendum Rd.", Age = 18, Interests = "vestibulum massa rutrum magna. Cras", ImageSrc = "https://randomuser.me/api/portraits/women/19.jpg" },
                new User{ Id = 40, FirstName = "Portia", LastName = "Cardenas", Address = "P.O. Box 791, 8995 Metus. Street", Age = 37, Interests = "egestas rhoncus. Proin nisl sem,", ImageSrc = "https://randomuser.me/api/portraits/women/20.jpg" },
                new User{ Id = 42, FirstName = "Tatyana", LastName = "Hernandez", Address = "Ap #321-9613 Vel Street", Age = 19, Interests = "Phasellus dolor", ImageSrc = "https://randomuser.me/api/portraits/women/21.jpg" },
                new User{ Id = 44, FirstName = "Anika", LastName = "Underwood", Address = "877 Penatibus Avenue", Age = 42, Interests = "auctor velit. Aliquam nisl. Nulla eu", ImageSrc = "https://randomuser.me/api/portraits/women/22.jpg" },
                new User{ Id = 46, FirstName = "Nichole", LastName = "Moss", Address = "621-460 Nunc. Rd.", Age = 27, Interests = "adipiscing fringilla, porttitor vulputate, posuere", ImageSrc = "https://randomuser.me/api/portraits/women/23.jpg" },
                new User{ Id = 48, FirstName = "Wyoming", LastName = "Cleveland", Address = "480-7485 Erat Street", Age = 56, Interests = "condimentum. Donec at arcu.", ImageSrc = "https://randomuser.me/api/portraits/women/24.jpg" },
                new User{ Id = 50, FirstName = "Kevyn", LastName = "Hardin", Address = "Ap #327-4599 Nibh Avenue", Age = 44, Interests = "lectus rutrum urna", ImageSrc = "https://randomuser.me/api/portraits/women/25.jpg" }
            };

            foreach (User user in seedData)
            {
                modelBuilder.Entity<User>().HasData(user);
            }
            /*modelBuilder.Entity<User>().HasData(new User { 
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
            });*/

        }
    }
}
