using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shop_api.Models;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mall> Malls { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<ShopTag> ShopTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CMTR-62001622\\SQLEXPRESS;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mall>(entity =>
        {
            entity.ToTable("Mall");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClosedHour).HasMaxLength(50);
            entity.Property(e => e.ContactNumber).HasMaxLength(50);
            entity.Property(e => e.MallAddress).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OpenHour).HasMaxLength(50);
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ShopAddress).HasMaxLength(255);

            entity.HasOne(d => d.Mall).WithMany(p => p.Shops)
                .HasForeignKey(d => d.MallId)
                .HasConstraintName("FK_Shop_Shop_Mall");
        });

        modelBuilder.Entity<ShopTag>(entity =>
        {
            entity.ToTable("ShopTag");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Shop).WithMany(p => p.ShopTags)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK_ShopTag_ShopTag_Shop");

            entity.HasOne(d => d.Tag).WithMany(p => p.ShopTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK_ShopTag_ShopTag_Tag");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tag");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
