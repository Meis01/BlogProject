﻿// <auto-generated />
using System;
using BlogProject.MODEL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogProject.MODEL.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20210516101042_CommentUserFK")]
    partial class CommentUserFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogProject.MODEL.Entities.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CreatedComputerName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CreatedIP")
                        .HasMaxLength(15);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("ModifiedComputerName")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ModifiedIP")
                        .HasMaxLength(15);

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogProject.MODEL.Entities.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("CreatedComputerName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CreatedIP")
                        .HasMaxLength(15);

                    b.Property<string>("ModifiedComputerName")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ModifiedIP")
                        .HasMaxLength(15);

                    b.Property<Guid>("PostID");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogProject.MODEL.Entities.Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryID");

                    b.Property<string>("CreatedComputerName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CreatedIP")
                        .HasMaxLength(15);

                    b.Property<string>("Imagepath");

                    b.Property<string>("ModifiedComputerName")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ModifiedIP")
                        .HasMaxLength(15);

                    b.Property<string>("PostDetail")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("Tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("UserID");

                    b.Property<int>("ViewCount");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogProject.MODEL.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedComputerName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CreatedIP")
                        .HasMaxLength(15);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ImageURL")
                        .HasMaxLength(255);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastIPAddress")
                        .HasMaxLength(24);

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ModifiedComputerName")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("ModifiedIP")
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogProject.MODEL.Entities.Comment", b =>
                {
                    b.HasOne("BlogProject.MODEL.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogProject.MODEL.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogProject.MODEL.Entities.Post", b =>
                {
                    b.HasOne("BlogProject.MODEL.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogProject.MODEL.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
