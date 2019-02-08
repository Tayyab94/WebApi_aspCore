using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DemoContaxt:DbContext
    {
        public DemoContaxt(DbContextOptions<DemoContaxt> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(s => s.ID).HasColumnName("CustomerID");
                entity.Property(x => x.Address).HasColumnType("varchar(50)");

                entity.Property(s => s.City).HasColumnType("varchar(50)");
                
                entity.Property(x => x.Email).HasColumnType("varchar(50)");

                entity.Property(s => s.State).HasColumnType("varchar(50)");


                entity.Property(x => x.firstName).HasColumnType("varchar(50)");

                entity.Property(x => x.firstName).HasMaxLength(20);
                entity.Property(s => s.lastName).HasColumnType("varchar(50)");

                entity.Property(x => x.Phone).HasColumnType("varchar(50)");

                entity.Property(s => s.ZipCode).HasColumnType("varchar(50)");
            });



            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(s => s.ID).HasColumnName("OrderID");

                entity.Property(x => x.CustomerId).HasColumnName("CustomerID");

                entity.Property(x => x.Date).HasColumnType("datetime");
                entity.Property(x => x.SalePersonId).HasColumnName("SalePersonID");
                entity.Property(s => s.Status).HasColumnType("varchar(50)");

                entity.Property(x => x.TotalDue).HasColumnType("money");


                entity.HasOne(s => s.Customer)
                .WithMany(s => s.Orders).HasForeignKey(x => x.CustomerId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior
                .Restrict).HasConstraintName("FK_Order_Customer");


                entity.HasOne(x => x.SalePerson).WithMany(x => x.Orders).
                HasForeignKey(x => x.SalePersonId).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasConstraintName("FK_Order_SalePerson");
            });


            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(s => s.Id).HasColumnName("OrderItemID");

                entity.Property(s => s.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                .IsRequired()
                .HasColumnName("ProductID").HasMaxLength(10);


                entity.HasOne(s => s.Order)
                .WithMany(s => s.OrderItems).HasForeignKey(s => s.OrderId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(p => p.Product).WithMany(s => s.OrderItems)
                 .HasForeignKey(s => s.ProductId).OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                 .HasConstraintName("FK_OrdetItem_Product");
            });




            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(s => s.ProductId).HasColumnName("ProductID").HasMaxLength(10);

                entity.Property(s => s.Price).HasColumnType("money");
                
                entity.Property(s => s.ProductName).HasColumnType("varchar(50)");

                entity.Property(s => s.Status).HasColumnType("varchar(50)");

                entity.Property(s => s.Variety).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SalePerson>(entity =>
            {
                entity.Property(s => s.Id).HasColumnName("SalePersonID");


                entity.Property(e => e.Address).HasColumnType("varchar(50)");

                entity.Property(e => e.City).HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirstName).HasColumnType("varchar(50)");

                entity.Property(e => e.LastName).HasColumnType("varchar(50)");

                entity.Property(e => e.Phone).HasColumnType("varchar(50)");

                entity.Property(e => e.State).HasColumnType("varchar(50)");

                entity.Property(e => e.Zipcode).HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<Customer> Customers { get; set; }


        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<SalePerson> SalePersons { get; set; }
    }
}
