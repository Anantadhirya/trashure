﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using trashure.components;

namespace trashure.Migrations
{
    [DbContext(typeof(TrashureContext))]
    [Migration("20241026070303_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("trashure.Item", b =>
                {
                    b.Property<int>("itemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("available")
                        .HasColumnType("boolean");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("itemName")
                        .HasColumnType("text");

                    b.Property<int?>("owneruserID")
                        .HasColumnType("integer");

                    b.HasKey("itemID");

                    b.HasIndex("owneruserID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("trashure.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("userName")
                        .HasColumnType("text");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("trashure.Item", b =>
                {
                    b.HasOne("trashure.User", "owner")
                        .WithMany("items")
                        .HasForeignKey("owneruserID");
                });
#pragma warning restore 612, 618
        }
    }
}
