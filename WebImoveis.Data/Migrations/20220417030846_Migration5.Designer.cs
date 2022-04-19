﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebImoveis.Data.Contexts;

namespace WebImoveis.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220417030846_Migration5")]
    partial class Migration5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebImoveis.Domain.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<short>("Number")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("PropertyId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Property");
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.Rent", b =>
                {
                    b.Property<int>("RentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentingDate")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("RentingExpiration")
                        .HasColumnType("DATE");

                    b.Property<decimal?>("RentingPrice")
                        .HasColumnType("DECIMAL(20,2)");

                    b.HasKey("RentId");

                    b.HasIndex("RenterId");

                    b.ToTable("Rent");
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.RentProperty", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("RentId")
                        .HasColumnType("int");

                    b.Property<int>("RentPropertyId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId", "RentId");

                    b.HasIndex("RentId");

                    b.ToTable("RentProperty");
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Cpf")
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("DATE");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.Property", b =>
                {
                    b.HasOne("WebImoveis.Domain.Entities.Address", "Address")
                        .WithOne("Property")
                        .HasForeignKey("WebImoveis.Domain.Entities.Property", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.Rent", b =>
                {
                    b.HasOne("WebImoveis.Domain.Entities.User", "Renter")
                        .WithMany("Rents")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebImoveis.Domain.Entities.RentProperty", b =>
                {
                    b.HasOne("WebImoveis.Domain.Entities.Property", "Property")
                        .WithMany("RentedProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebImoveis.Domain.Entities.Rent", "Rent")
                        .WithMany("RentedProperties")
                        .HasForeignKey("RentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}