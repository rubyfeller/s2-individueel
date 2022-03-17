﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSystemWeb.Data;

#nullable disable

namespace TicketSystemWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220314094316_devices")]
    partial class devices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketSystemWeb.Models.Device", b =>
                {
                    b.Property<int>("deviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deviceId"), 1L, 1);

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<string>("deviceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deviceVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("osVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketId")
                        .HasColumnType("int");

                    b.HasKey("deviceId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("TicketSystemWeb.Models.Ticket", b =>
                {
                    b.Property<int>("ticketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketId"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("replyId")
                        .HasColumnType("int");

                    b.Property<int>("ticketCategory")
                        .HasColumnType("int");

                    b.Property<string>("ticketContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketPriority")
                        .HasColumnType("int");

                    b.Property<int>("ticketStatus")
                        .HasColumnType("int");

                    b.Property<string>("ticketSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ticketId");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
