﻿// <auto-generated />
using BankTransfer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankTransfer.Migrations
{
    [DbContext(typeof(BankTransferDbContext))]
    partial class BankTransferDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BankTransfer.Models.Account", b =>
                {
                    b.Property<string>("Identifier")
                        .HasColumnType("text");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Identifier");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("AccountType").HasValue("Account");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BankTransfer.Models.Store", b =>
                {
                    b.HasBaseType("BankTransfer.Models.Account");

                    b.HasDiscriminator().HasValue("Store");
                });

            modelBuilder.Entity("BankTransfer.Models.User", b =>
                {
                    b.HasBaseType("BankTransfer.Models.Account");

                    b.HasDiscriminator().HasValue("User");
                });
#pragma warning restore 612, 618
        }
    }
}