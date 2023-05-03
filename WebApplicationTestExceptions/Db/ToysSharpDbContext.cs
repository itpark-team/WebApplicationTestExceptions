using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Db;

public partial class ToysSharpDbContext : DbContext
{
    public ToysSharpDbContext()
    {
    }

    public ToysSharpDbContext(DbContextOptions<ToysSharpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Toy> Toys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=194.67.105.79:5432;Database=toys_sharp_db;Username=toys_sharp_user;Password=12345");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Toy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("toys_pk");

            entity.ToTable("toys");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgeLimit)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("age_limit");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}