using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UserManager.Models;

namespace Messanger.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Notice> Notices { get; set; }

        public DbSet<Dialog> Dialogs { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,

                Name = "Denis",

                Email = "surmanidzedenis609@gmail.com",

                Password = PasswordHasher.GenerateHash("01052001denis"),

                Role = "Admin",

                City = "Saint-Peterburg",

                Age = 22
            });
        }

    }

}
