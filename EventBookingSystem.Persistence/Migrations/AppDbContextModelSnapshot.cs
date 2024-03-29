﻿// <auto-generated />
using System;
using EventBookingSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventBookingSystem.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Career Development"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Social Activities"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Study Abroad"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Computer Science"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Information Security"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Artificial Intelligence"
                        });
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VenueId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.EventSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("integer");

                    b.Property<int>("Row")
                        .HasColumnType("integer");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId")
                        .IsUnique();

                    b.ToTable("EventSeat");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.SpeakerEvent", b =>
                {
                    b.Property<int>("SpeakerId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("SpeakerId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("SpeakerEvent");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ali@email.com",
                            FirstName = "Ali",
                            LastName = "Aliyev",
                            Password = "pasS!2345",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "vali@email.com",
                            FirstName = "Vali",
                            LastName = "Hasanli",
                            Password = "pasS!23456",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "hasanova@email.com",
                            FirstName = "Nargiz",
                            LastName = "Hasanova",
                            Password = "pasS!23457",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RowCapacity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Venue");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 400,
                            Name = "Event Hall",
                            RowCapacity = 16
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 100,
                            Name = "Room 201",
                            RowCapacity = 10
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 80,
                            Name = "Room 506",
                            RowCapacity = 10
                        });
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Event", b =>
                {
                    b.HasOne("EventBookingSystem.Domain.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBookingSystem.Domain.Entities.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.EventSeat", b =>
                {
                    b.HasOne("EventBookingSystem.Domain.Entities.Event", "Event")
                        .WithMany("EventSeats")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBookingSystem.Domain.Entities.Participant", "Participant")
                        .WithOne("EventSeat")
                        .HasForeignKey("EventBookingSystem.Domain.Entities.EventSeat", "ParticipantId");

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Participant", b =>
                {
                    b.HasOne("EventBookingSystem.Domain.Entities.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBookingSystem.Domain.Entities.User", "User")
                        .WithMany("Participants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.SpeakerEvent", b =>
                {
                    b.HasOne("EventBookingSystem.Domain.Entities.Event", "Event")
                        .WithMany("SpeakerEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventBookingSystem.Domain.Entities.Speaker", "Speaker")
                        .WithMany("SpeakerEvents")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.User", b =>
                {
                    b.HasOne("EventBookingSystem.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Event", b =>
                {
                    b.Navigation("EventSeats");

                    b.Navigation("Participants");

                    b.Navigation("SpeakerEvents");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Participant", b =>
                {
                    b.Navigation("EventSeat")
                        .IsRequired();
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Speaker", b =>
                {
                    b.Navigation("SpeakerEvents");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.User", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("EventBookingSystem.Domain.Entities.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
