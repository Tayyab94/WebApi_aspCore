using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DemoContaxt))]
    [Migration("20190208105612_Commit")]
    partial class Commit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerID");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("firstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("lastName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApplication1.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderID");

                    b.Property<int>("CustomerId")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("SalePersonId")
                        .HasColumnName("SalePersonID");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("TotalDue")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SalePersonId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderItemID");

                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnName("ProductID")
                        .HasMaxLength(10);

                    b.Property<int?>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("WebApplication1.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnName("ProductID")
                        .HasMaxLength(10);

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ProductName")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Size");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Variety")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApplication1.Models.SalePerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SalePersonID");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SalePersons");
                });

            modelBuilder.Entity("WebApplication1.Models.Order", b =>
                {
                    b.HasOne("WebApplication1.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_Customer");

                    b.HasOne("WebApplication1.Models.SalePerson", "SalePerson")
                        .WithMany("Orders")
                        .HasForeignKey("SalePersonId")
                        .HasConstraintName("FK_Order_SalePerson");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderItem", b =>
                {
                    b.HasOne("WebApplication1.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderItem_Order");

                    b.HasOne("WebApplication1.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrdetItem_Product");
                });
        }
    }
}
