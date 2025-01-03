﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using services_backend;

#nullable disable

namespace services_backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241118052347_modifications")]
    partial class modifications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<int>("IdClients")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ban")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EstablishmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("IdClients");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Establishment", b =>
                {
                    b.Property<int>("IdEstablishment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CancellationPolicy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EstablishmentVarchar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("IdEstablishment");

                    b.ToTable("Establishments");
                });

            modelBuilder.Entity("services_backend.Models.Reservation", b =>
                {
                    b.Property<int>("IdReservations")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cancel")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EstablishmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InitTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("IdReservations");

                    b.HasIndex("ClientId");

                    b.HasIndex("EstablishmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("services_backend.Models.Service", b =>
                {
                    b.Property<int>("IdServices")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EstablishmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TypeServiceId")
                        .HasColumnType("int");

                    b.HasKey("IdServices");

                    b.HasIndex("EstablishmentId");

                    b.HasIndex("TypeServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("services_backend.Models.Times", b =>
                {
                    b.Property<int>("IdTimes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InitTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("IdTimes");

                    b.HasIndex("ServiceId");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("services_backend.Models.TypeService", b =>
                {
                    b.Property<int>("IdTypeServices")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EstablishmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PolicyCancelation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("IdTypeServices");

                    b.HasIndex("EstablishmentId");

                    b.ToTable("TypeServices");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.HasOne("Establishment", "Establishment")
                        .WithMany("Clients")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establishment");
                });

            modelBuilder.Entity("services_backend.Models.Reservation", b =>
                {
                    b.HasOne("Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Establishment", "Establishment")
                        .WithMany()
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("services_backend.Models.Service", "Service")
                        .WithMany("Reservations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Establishment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("services_backend.Models.Service", b =>
                {
                    b.HasOne("Establishment", "Establishment")
                        .WithMany("Services")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("services_backend.Models.TypeService", "TypeService")
                        .WithMany("Services")
                        .HasForeignKey("TypeServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establishment");

                    b.Navigation("TypeService");
                });

            modelBuilder.Entity("services_backend.Models.Times", b =>
                {
                    b.HasOne("services_backend.Models.Service", "Service")
                        .WithMany("Times")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("services_backend.Models.TypeService", b =>
                {
                    b.HasOne("Establishment", "Establishment")
                        .WithMany("TypeServices")
                        .HasForeignKey("EstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establishment");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Establishment", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Services");

                    b.Navigation("TypeServices");
                });

            modelBuilder.Entity("services_backend.Models.Service", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Times");
                });

            modelBuilder.Entity("services_backend.Models.TypeService", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
