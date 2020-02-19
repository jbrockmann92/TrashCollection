using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Models;

namespace TrashCollector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole //This is a built-in, or at least inherits from a built-in class. That's why it doesn't have to be made and defined
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                }

                //Should I have something in here where I match the most recently created Admin, Employee, or Customer to its id by saving the id as its id?
            );
        }

        public DbSet<TrashCollector.Models.Customer> Customer { get; set; }

        public DbSet<TrashCollector.Models.Employee> Employee { get; set; }

        public DbSet<TrashCollector.Models.Address> Address { get; set; }

        public DbSet<TrashCollector.Models.Pickup> Pickup { get; set; }

        
    }
}
