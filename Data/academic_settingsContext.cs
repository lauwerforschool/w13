﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Group_4_DB.Models;

namespace Group_4_DB.Data
{
    public partial class academic_settingsContext : DbContext
    {
        public academic_settingsContext()
        {
        }

        public academic_settingsContext(DbContextOptions<academic_settingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<classes> classes { get; set; }
        public virtual DbSet<instructors> instructors { get; set; }
        public virtual DbSet<major> major { get; set; }
        public virtual DbSet<majorclasses> majorclasses { get; set; }
        public virtual DbSet<studentclasses> studentclasses { get; set; }
        public virtual DbSet<students> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<classes>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttendanceType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClassID)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstructorsID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<instructors>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IEmail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ILastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstructorsID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<major>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EstimatedCompletion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MajorID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MajorName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<majorclasses>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ClassID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MajorID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<studentclasses>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ClassID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<students>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GradYear).HasColumnType("date");

                entity.Property(e => e.MajorID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}