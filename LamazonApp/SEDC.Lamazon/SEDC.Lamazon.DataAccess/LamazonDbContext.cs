using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.Domain.Enum;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.DataAccess
{
    public class LamazonDbContext : DbContext
    {
        public LamazonDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Admin"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Supplier"
                    },
                    new Role
                    {
                        Id = 3,
                        Name = "Customer"
                    }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Martin",
                        LastName = "Panovski",
                        Username = "martin-pano",
                        Password = "Martin123",
                        Address = "Partizanski Odredi 20",
                        Age = 27,
                        RoleId = 1
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Dejan",
                        LastName = "Jovanov",
                        Username = "dejan-jovanov",
                        Password = "Dejan123",
                        Address = "Test Street 20",
                        Age = 28,
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Ivo",
                        LastName = "Kostovski",
                        Username = "ivo-kostovski",
                        Password = "Ivo123",
                        Address = "Test Street 10",
                        Age = 30,
                        RoleId = 3
                    }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        Id = 1,
                        Status = StatusType.Init,
                        IsPaid = false,
                        DateOfOrder = DateTime.Now,
                        UserId = 3
                    },
                    new Order
                    {
                        Id = 2,
                        Status = StatusType.Confirmed,
                        IsPaid = false,
                        DateOfOrder = DateTime.Now,
                        UserId = 3
                    },
                    new Order
                    {
                        Id = 3,
                        Status = StatusType.Pending,
                        IsPaid = false,
                        DateOfOrder = DateTime.Now,
                        UserId = 3
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Samsung Galaxy S20",
                        Price = 1000,
                        Description = "The best samsung phone!",
                        Category = CategoryType.Electornics
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Ice",
                        Price = 1,
                        Description = "Full bag of ice for your party!",
                        Category = CategoryType.Other,
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Johnnie Walker",
                        Price = 20,
                        Description = "Scotch wiskey",
                        Category = CategoryType.Drinks
                    }
                );


            modelBuilder.Entity<ProductOrder>()
                .HasData(
                    new ProductOrder
                    {
                        Id = 1,
                        OrderId = 1,
                        ProductId = 1
                    },
                    new ProductOrder
                    {
                        Id = 2,
                        OrderId = 2,
                        ProductId = 3
                    },
                    //The following two records are two Products for same Order
                    new ProductOrder
                    {
                        Id = 3,
                        OrderId = 3,
                        ProductId = 2
                    },
                    new ProductOrder
                    {
                        Id = 4,
                        OrderId = 3,
                        ProductId = 1
                    }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.ProductOrders)
                .WithOne(po => po.Order)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductOrders)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);


            Seed(modelBuilder);
        }
    }
}
