using System;
using System.Collections.Generic;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess;

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

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Diamond> Diamonds { get; set; }

    public virtual DbSet<DiamondProduct> DiamondProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<StakeHolder> StakeHolders { get; set; }

    public virtual DbSet<Warranty> Warranties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07FF84C912");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__A9D105343EA15EB7").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07766302BD");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC07252D917E");

            entity.ToTable("Certification");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__Certifica__Diamo__619B8048");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07C16347A7");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E384396CC7E").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Account).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Customer__Accoun__3D5E1FD2");
        });

        modelBuilder.Entity<Diamond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond__3214EC0792C478B9");

            entity.ToTable("Diamond");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CaratWeight).HasMaxLength(20);
            entity.Property(e => e.Clarity).HasMaxLength(20);
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Cut).HasMaxLength(20);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<DiamondProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiamondP__3214EC079032350A");

            entity.ToTable("DiamondProduct");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.DiamondProducts)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__DiamondPr__Diamo__5070F446");

            entity.HasOne(d => d.Product).WithMany(p => p.DiamondProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__DiamondPr__Produ__4F7CD00D");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07B215DF1B");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
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
            entity.HasKey(e => new { e.OrderId, e.ProductId, e.WarrantyId }).HasName("PK__OrderDet__1AFE44BBF1536777");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.SubTotal).HasColumnType("money");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__5BE2A6F2");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__5CD6CB2B");

            entity.HasOne(d => d.Warranty).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.WarrantyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Warra__5DCAEF64");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Picture__3214EC0786B77899");

            entity.ToTable("Picture");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__Picture__Diamond__656C112C");

            entity.HasOne(d => d.Product).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Picture__Product__66603565");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07629ACF28");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__48CFD27E");
        });

        modelBuilder.Entity<StakeHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StakeHol__3214EC07DEDB45E0");

            entity.ToTable("StakeHolder");

            entity.HasIndex(e => e.PhoneNumber, "UQ__StakeHol__85FB4E3861395F63").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Account).WithMany(p => p.StakeHolders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__StakeHold__Accou__4222D4EF");
        });

        modelBuilder.Entity<Warranty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warranty__3214EC07FC87E0D8");

            entity.ToTable("Warranty");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
