﻿// <auto-generated />
using System;
using GoodHabits.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodHabits.Persistence.Migrations
{
    [DbContext(typeof(GoodHabitsDbContext))]
    [Migration("20231104052431_AdditionalEntities")]
    partial class AdditionalEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HabitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitId")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Id");

                    b.ToTable("Habits");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            Description = "Become a francophone",
                            Duration = 0,
                            Name = "Learn French",
                            TenantName = "CloudSphere",
                            UserId = 0
                        },
                        new
                        {
                            Id = 101,
                            Description = "Get really fit",
                            Duration = 0,
                            Name = "Run a marathon",
                            TenantName = "CloudSphere",
                            UserId = 0
                        },
                        new
                        {
                            Id = 102,
                            Description = "Finish your book project",
                            Duration = 0,
                            Name = "Write every day",
                            TenantName = "CloudSphere",
                            UserId = 0
                        });
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.HasIndex("Id");

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<int>("HabitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.HasIndex("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Goal", b =>
                {
                    b.HasOne("GoodHabits.Persistence.Entities.Habit", "Habit")
                        .WithOne("Goal")
                        .HasForeignKey("GoodHabits.Persistence.Entities.Goal", "HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Progress", b =>
                {
                    b.HasOne("GoodHabits.Persistence.Entities.Habit", "Habit")
                        .WithMany("ProgressUpdates")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Reminder", b =>
                {
                    b.HasOne("GoodHabits.Persistence.Entities.Habit", "Habit")
                        .WithMany("Reminders")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("GoodHabits.Persistence.Entities.Habit", b =>
                {
                    b.Navigation("Goal")
                        .IsRequired();

                    b.Navigation("ProgressUpdates");

                    b.Navigation("Reminders");
                });
#pragma warning restore 612, 618
        }
    }
}
