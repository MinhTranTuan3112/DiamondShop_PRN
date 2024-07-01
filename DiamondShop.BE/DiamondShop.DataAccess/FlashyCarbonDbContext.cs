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
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07225322B5");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__A9D10534CB595E60").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0759103F76");

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

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC0701FB4D5D");

            entity.ToTable("Certification");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.DiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__Diamo__7E37BEF6");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0790303EFF");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.AccountId, "UQ__Customer__349DA5A750254733").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E384E7DF8FF").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Account).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__Accoun__412EB0B6");
        });

        modelBuilder.Entity<Diamond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond__3214EC07BE90C6F2");

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
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07BF8B88AE");

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
                .HasDefaultValue("created");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__6A30C649");

            entity.HasOne(d => d.DeliveryStaff).WithMany(p => p.OrderDeliveryStaffs)
                .HasForeignKey(d => d.DeliveryStaffId)
                .HasConstraintName("FK__Order__DeliveryS__6C190EBB");

            entity.HasOne(d => d.SalesStaff).WithMany(p => p.OrderSalesStaffs)
                .HasForeignKey(d => d.SalesStaffId)
                .HasConstraintName("FK__Order__SalesStaf__6B24EA82");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07B684B8B4");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.SumSizePrice).HasColumnType("money");

            entity.HasOne(d => d.Diamond).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__OrderDeta__Diamo__74AE54BC");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__72C60C4A");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__73BA3083");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Picture__3214EC07DB22D9D2");

            entity.ToTable("Picture");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__Picture__Diamond__02084FDA");

            entity.HasOne(d => d.Product).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Picture__Product__02FC7413");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07C6FBB3FD");

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
                .HasConstraintName("FK__Product__Categor__5629CD9C");
        });

        modelBuilder.Entity<ProductPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC07EE11C8D7");

            entity.ToTable("ProductPart");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.DiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPa__Diamo__628FA481");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPa__Produ__619B8048");
        });

        modelBuilder.Entity<StakeHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StakeHol__3214EC077FAF71C8");

            entity.ToTable("StakeHolder");

            entity.HasIndex(e => e.AccountId, "UQ__StakeHol__349DA5A7DC41BC9B").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__StakeHol__85FB4E381AC4E7B8").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateHired).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Account).WithOne(p => p.StakeHolder)
                .HasForeignKey<StakeHolder>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StakeHold__Accou__48CFD27E");
        });

        modelBuilder.Entity<Warranty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warranty__3214EC0718AFBCD5");

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
                .HasConstraintName("FK__Warranty__OrderD__7A672E12");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
