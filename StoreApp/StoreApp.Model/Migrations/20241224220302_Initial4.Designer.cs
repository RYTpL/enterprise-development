﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.Model;

#nullable disable

namespace StoreApp.Model.Migrations
{
    [DbContext(typeof(StoreAppContext))]
    [Migration("20241224220302_Initial4")]
    partial class Initial4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("CustomerCardNumber")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerCardNumber = 111111,
                            CustomerName = "Michelle Padilla"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerCardNumber = 222222,
                            CustomerName = "Manuel Gomez"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerCardNumber = 333333,
                            CustomerName = "Raymond Oliver"
                        },
                        new
                        {
                            CustomerId = 4,
                            CustomerCardNumber = 444444,
                            CustomerName = "Enrique Morgan"
                        },
                        new
                        {
                            CustomerId = 5,
                            CustomerCardNumber = 555555,
                            CustomerName = "Walter Mullins"
                        });
                });

            modelBuilder.Entity("StoreApp.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<DateTime>("DateStorage")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductGroup")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("double");

                    b.Property<bool>("ProductType")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("ProductWeight")
                        .HasColumnType("double");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            DateStorage = new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductGroup = 1,
                            ProductName = "Milk",
                            ProductPrice = 89.0,
                            ProductType = false,
                            ProductWeight = 0.93999999999999995
                        },
                        new
                        {
                            ProductId = 2,
                            DateStorage = new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductGroup = 1,
                            ProductName = "Butter",
                            ProductPrice = 159.0,
                            ProductType = false,
                            ProductWeight = 0.93999999999999995
                        },
                        new
                        {
                            ProductId = 3,
                            DateStorage = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductGroup = 2,
                            ProductName = "Pasta",
                            ProductPrice = 109.0,
                            ProductType = true,
                            ProductWeight = 0.40000000000000002
                        },
                        new
                        {
                            ProductId = 4,
                            DateStorage = new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductGroup = 3,
                            ProductName = "Eggs",
                            ProductPrice = 96.0,
                            ProductType = false,
                            ProductWeight = 0.59999999999999998
                        },
                        new
                        {
                            ProductId = 5,
                            DateStorage = new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductGroup = 3,
                            ProductName = "Bread",
                            ProductPrice = 36.0,
                            ProductType = false,
                            ProductWeight = 0.44
                        });
                });

            modelBuilder.Entity("StoreApp.Model.ProductSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("ProductSales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Quantity = 1,
                            SaleId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Quantity = 1,
                            SaleId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Quantity = 1,
                            SaleId = 1
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Quantity = 1,
                            SaleId = 2
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Quantity = 1,
                            SaleId = 2
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 1,
                            Quantity = 1,
                            SaleId = 2
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 2,
                            Quantity = 1,
                            SaleId = 3
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 3,
                            Quantity = 1,
                            SaleId = 3
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 4,
                            Quantity = 1,
                            SaleId = 3
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 5,
                            Quantity = 1,
                            SaleId = 4
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 1,
                            Quantity = 1,
                            SaleId = 4
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 2,
                            Quantity = 1,
                            SaleId = 4
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 3,
                            Quantity = 1,
                            SaleId = 5
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 4,
                            Quantity = 1,
                            SaleId = 5
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 5,
                            Quantity = 1,
                            SaleId = 5
                        },
                        new
                        {
                            Id = 16,
                            ProductId = 2,
                            Quantity = 1,
                            SaleId = 6
                        },
                        new
                        {
                            Id = 17,
                            ProductId = 3,
                            Quantity = 1,
                            SaleId = 6
                        },
                        new
                        {
                            Id = 18,
                            ProductId = 4,
                            Quantity = 1,
                            SaleId = 6
                        },
                        new
                        {
                            Id = 19,
                            ProductId = 5,
                            Quantity = 1,
                            SaleId = 7
                        },
                        new
                        {
                            Id = 20,
                            ProductId = 1,
                            Quantity = 1,
                            SaleId = 7
                        },
                        new
                        {
                            Id = 21,
                            ProductId = 4,
                            Quantity = 1,
                            SaleId = 7
                        });
                });

            modelBuilder.Entity("StoreApp.Model.ProductStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductStores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Quantity = 10,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Quantity = 2,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Quantity = 5,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 3,
                            Quantity = 15,
                            StoreId = 3
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 4,
                            Quantity = 0,
                            StoreId = 2
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 4,
                            Quantity = 20,
                            StoreId = 3
                        });
                });

            modelBuilder.Entity("StoreApp.Model.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<double>("Sum")
                        .HasColumnType("double");

                    b.HasKey("SaleId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StoreId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            SaleId = 1,
                            CustomerId = 2,
                            DateSale = new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 1,
                            Sum = 357.0
                        },
                        new
                        {
                            SaleId = 2,
                            CustomerId = 1,
                            DateSale = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 2,
                            Sum = 221.0
                        },
                        new
                        {
                            SaleId = 3,
                            CustomerId = 2,
                            DateSale = new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 1,
                            Sum = 364.0
                        },
                        new
                        {
                            SaleId = 4,
                            CustomerId = 3,
                            DateSale = new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 3,
                            Sum = 284.0
                        },
                        new
                        {
                            SaleId = 5,
                            CustomerId = 4,
                            DateSale = new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 4,
                            Sum = 241.0
                        },
                        new
                        {
                            SaleId = 6,
                            CustomerId = 5,
                            DateSale = new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 2,
                            Sum = 364.0
                        },
                        new
                        {
                            SaleId = 7,
                            CustomerId = 5,
                            DateSale = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreId = 1,
                            Sum = 284.0
                        });
                });

            modelBuilder.Entity("StoreApp.Model.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            StoreAddress = "Polevaya 123",
                            StoreName = "Walmart"
                        },
                        new
                        {
                            StoreId = 2,
                            StoreAddress = "Pushkina 1837",
                            StoreName = "Pyaterochka"
                        },
                        new
                        {
                            StoreId = 3,
                            StoreAddress = "Kolotushkina 0",
                            StoreName = "Shestorochka"
                        },
                        new
                        {
                            StoreId = 4,
                            StoreAddress = "Moskovskoye shosse 666",
                            StoreName = "Magnit"
                        },
                        new
                        {
                            StoreId = 5,
                            StoreAddress = "Revolyutsionnaya 1917",
                            StoreName = "Perekrestok"
                        });
                });

            modelBuilder.Entity("StoreApp.Model.ProductSale", b =>
                {
                    b.HasOne("StoreApp.Model.Product", null)
                        .WithMany("ProductSales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApp.Model.Sale", null)
                        .WithMany("ProductSales")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreApp.Model.ProductStore", b =>
                {
                    b.HasOne("StoreApp.Model.Product", null)
                        .WithMany("ProductStores")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApp.Model.Store", null)
                        .WithMany("ProductStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreApp.Model.Sale", b =>
                {
                    b.HasOne("StoreApp.Model.Customer", null)
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApp.Model.Store", null)
                        .WithMany("Sales")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreApp.Model.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("StoreApp.Model.Product", b =>
                {
                    b.Navigation("ProductSales");

                    b.Navigation("ProductStores");
                });

            modelBuilder.Entity("StoreApp.Model.Sale", b =>
                {
                    b.Navigation("ProductSales");
                });

            modelBuilder.Entity("StoreApp.Model.Store", b =>
                {
                    b.Navigation("ProductStores");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
