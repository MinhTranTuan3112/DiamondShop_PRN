﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Models;

public partial class FlashyCarbonDbContext : DbContext
{
    public FlashyCarbonDbContext()
    {
    }

    public FlashyCarbonDbContext(DbContextOptions<FlashyCarbonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Diamond> Diamonds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPart> ProductParts { get; set; }

    public virtual DbSet<StakeHolder> StakeHolders { get; set; }

    public virtual DbSet<Warranty> Warranties { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07ECC6BFF9");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__A9D105345B7DCE4F").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0765CF3DB6");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0751CC4B86");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.AccountId, "UQ__Customer__349DA5A7E728D89E").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E385D1625D6").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Account).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__Accoun__2E1BDC42");
        });

        modelBuilder.Entity<Diamond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond__3214EC076D5789DA");

            entity.ToTable("Diamond");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CaratWeight).HasMaxLength(20);
            entity.Property(e => e.Clarity).HasMaxLength(20);
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Cut).HasMaxLength(20);
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07415649DD");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Note).HasDefaultValue("nothing here");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("InCart");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__571DF1D5");

            entity.HasOne(d => d.DeliveryStaff).WithMany(p => p.OrderDeliveryStaffs)
                .HasForeignKey(d => d.DeliveryStaffId)
                .HasConstraintName("FK__Order__DeliveryS__59063A47");

            entity.HasOne(d => d.SalesStaff).WithMany(p => p.OrderSalesStaffs)
                .HasForeignKey(d => d.SalesStaffId)
                .HasConstraintName("FK__Order__SalesStaf__5812160E");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC070897B6F8");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.SumSizePrice).HasColumnType("money");

            entity.HasOne(d => d.Diamond).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__OrderDeta__Diamo__619B8048");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__5FB337D6");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__60A75C0F");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Picture__3214EC070D7BEBE6");

            entity.ToTable("Picture");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__Picture__Diamond__7E37BEF6");

            entity.HasOne(d => d.Product).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Picture__Product__7F2BE32F");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC076E015BCE");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__4316F928");
        });

        modelBuilder.Entity<ProductPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC07C78B2CD6");

            entity.ToTable("ProductPart");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.DiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPa__Diamo__4F7CD00D");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPa__Produ__4E88ABD4");
        });

        modelBuilder.Entity<StakeHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StakeHol__3214EC07F2D6B1F7");

            entity.ToTable("StakeHolder");

            entity.HasIndex(e => e.AccountId, "UQ__StakeHol__349DA5A70EE30E50").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__StakeHol__85FB4E3831D90121").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateHired).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Account).WithOne(p => p.StakeHolder)
                .HasForeignKey<StakeHolder>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StakeHold__Accou__35BCFE0A");
        });

        modelBuilder.Entity<Warranty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warranty__3214EC07B4DE4B56");

            entity.ToTable("Warranty");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Warranties)
                .HasForeignKey(d => d.OrderDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warranty__OrderD__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
