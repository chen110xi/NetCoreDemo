﻿// <auto-generated />
using EfCoreDemo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EfCoreDemo.Migrations
{
    [DbContext(typeof(DemoContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreDemo.Entities.ManyToMany.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.ManyToMany.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.ManyToMany.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToMany.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClassId");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnName("ClassName")
                        .HasMaxLength(50);

                    b.HasKey("ClassId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToMany.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassId");

                    b.Property<string>("StudentName")
                        .HasMaxLength(50);

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToOne.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AccountID");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnName("AccountName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasMaxLength(100);

                    b.Property<int?>("UserId");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToOne.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AccountID");

                    b.Property<int?>("ClassId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(100);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.HasIndex("ClassId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.ManyToMany.ProductCategory", b =>
                {
                    b.HasOne("EfCoreDemo.Entities.ManyToMany.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EfCoreDemo.Entities.ManyToMany.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToMany.Student", b =>
                {
                    b.HasOne("EfCoreDemo.Entities.OneToMany.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToOne.Account", b =>
                {
                    b.HasOne("EfCoreDemo.Entities.OneToOne.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("EfCoreDemo.Entities.OneToOne.Account", "UserId");
                });

            modelBuilder.Entity("EfCoreDemo.Entities.OneToOne.User", b =>
                {
                    b.HasOne("EfCoreDemo.Entities.OneToMany.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");
                });
#pragma warning restore 612, 618
        }
    }
}