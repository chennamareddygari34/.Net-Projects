﻿// <auto-generated />
using System;
using BankAcountEstatementApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankAcountEstatementApp.Migrations
{
    [DbContext(typeof(EStatementContext))]
    partial class EStatementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BankAcountEstatementApp.Models.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountNumber"));

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AccountHolderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountNumber");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("BankAcountEstatementApp.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("integer");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("currency");
                });

            modelBuilder.Entity("BankAcountEstatementApp.Models.Statement", b =>
                {
                    b.Property<int>("StatementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatementId"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PeriodEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("PeriodStart")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("StatementId");

                    b.HasIndex("AccountNumber");

                    b.ToTable("statements");
                });

            modelBuilder.Entity("BankAcountEstatementApp.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<byte[]>("Key")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("UserName");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BankAcountEstatementApp.Models.Statement", b =>
                {
                    b.HasOne("BankAcountEstatementApp.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}