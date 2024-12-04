using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data.Context
{
    public class universalContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }

        public universalContext(DbContextOptions<universalContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Client>("Client")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    LastName = "Coria",
                    Name = "Ezequiel",
                    Email = "Ez@gmail.com",
                    UserName = "CoriaCo",
                    Password = "pass",
                    Id = 1,
                    UserType = "Admin"
                });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    LastName = "Black",
                    Name = "Nathaniel",
                    Email = "Natha@gmail.com",
                    UserName = "BlackNatha",
                    Password = "pass",
                    Address = "Zeballos 1341",
                    Id = 2,
                    UserType = "Client"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 3,
                    Name = "Camiseta Selección Argentina",
                    Price = 150000,
                    Stock = 10
                });


           
            modelBuilder.Entity<Client>()
           .HasMany(c => c.SaleOrders)
           .WithOne(o => o.Client)
           .HasForeignKey(o => o.ClientId)
           .OnDelete(DeleteBehavior.Cascade);
                                            

           
            modelBuilder.Entity<SaleOrder>()
                .HasMany(o => o.SaleOrderDetails)
                .WithOne(l => l.SaleOrder)
                .HasForeignKey(l => l.SaleOrderId)
                .OnDelete(DeleteBehavior.Cascade); 
                                                   

          
            modelBuilder.Entity<SaleOrderDetail>()
                .HasOne(sol => sol.Product)
                .WithMany()
                .HasForeignKey(sol => sol.ProductId)
                .OnDelete(DeleteBehavior.Restrict); 
                                                    

            base.OnModelCreating(modelBuilder);
        }
    }
}