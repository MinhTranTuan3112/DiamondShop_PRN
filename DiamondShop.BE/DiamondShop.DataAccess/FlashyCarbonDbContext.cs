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

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerPromotion> CustomerPromotions { get; set; }

    public virtual DbSet<Diamond> Diamonds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPart> ProductParts { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<StakeHolder> StakeHolders { get; set; }

    public virtual DbSet<Warranty> Warranties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC0761904FAF");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__A9D10534EF66273F").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07DE15BBB4");

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

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC07D1BD440C");

            entity.ToTable("Certificate");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CaratWeight).HasMaxLength(50);
            entity.Property(e => e.Clarity).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Cut).HasMaxLength(50);
            entity.Property(e => e.DateOfIssue)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.Shape).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0785180978");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Point, "IX_Customer_Point");

            entity.HasIndex(e => e.AccountId, "UQ__Customer__349DA5A79E15F082").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E380CD83D6F").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Account).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__Accoun__412EB0B6");
        });

        modelBuilder.Entity<CustomerPromotion>(entity =>
        {
            entity.HasKey(e => new { e.PromotionId, e.CustomerId }).HasName("PK__Customer__C88EC982311BAF86");

            entity.ToTable("CustomerPromotion");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerPromotion_CustomerId");

            entity.HasIndex(e => e.PromotionId, "IX_CustomerPromotion_PromotionId");

            entity.Property(e => e.CollectedDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("collected");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerPromotions)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerP__Custo__7C4F7684");

            entity.HasOne(d => d.Promotion).WithMany(p => p.CustomerPromotions)
                .HasForeignKey(d => d.PromotionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerP__Promo__7B5B524B");
        });

        modelBuilder.Entity<Diamond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond__3214EC0760D38AD4");

            entity.ToTable("Diamond");

            entity.HasIndex(e => e.CertificateId, "UQ__Diamond__BBF8A7C0B7F08DEF").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CaratWeight).HasMaxLength(50);
            entity.Property(e => e.Clarity).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Cut).HasMaxLength(50);
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Shape).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");

            entity.HasOne(d => d.Certificate).WithOne(p => p.Diamond)
                .HasForeignKey<Diamond>(d => d.CertificateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diamond__Certifi__656C112C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC079E6C117F");

            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Note).HasDefaultValue("Nothing!");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PayMethod).HasMaxLength(20);
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("InCart");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__72C60C4A");

            entity.HasOne(d => d.DeliveryStaff).WithMany(p => p.OrderDeliveryStaffs)
                .HasForeignKey(d => d.DeliveryStaffId)
                .HasConstraintName("FK__Order__DeliveryS__74AE54BC");

            entity.HasOne(d => d.SalesStaff).WithMany(p => p.OrderSalesStaffs)
                .HasForeignKey(d => d.SalesStaffId)
                .HasConstraintName("FK__Order__SalesStaf__73BA3083");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07C9C91467");

            entity.ToTable("OrderDetail");

            entity.HasIndex(e => e.OrderId, "IX_OrderDetail_OrderId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("InCart");
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.SumSizePrice).HasColumnType("money");

            entity.HasOne(d => d.Diamond).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__OrderDeta__Diamo__06CD04F7");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__04E4BC85");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__05D8E0BE");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Picture__3214EC070BD5BE8A");

            entity.ToTable("Picture");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__Picture__Diamond__114A936A");

            entity.HasOne(d => d.Product).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Picture__Product__123EB7A3");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07242E13C4");

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
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC073AF5E8CB");

            entity.ToTable("ProductPart");

            entity.HasIndex(e => e.ProductId, "IX_ProductPart_ProductId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Diamond).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.DiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPa__Diamo__6B24EA82");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPa__Produ__6A30C649");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promotio__3214EC0765C156EF");

            entity.ToTable("Promotion");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("available");
        });

        modelBuilder.Entity<StakeHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StakeHol__3214EC07EC5DA7FF");

            entity.ToTable("StakeHolder");

            entity.HasIndex(e => e.AccountId, "UQ__StakeHol__349DA5A79B5A9661").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__StakeHol__85FB4E38E4846241").IsUnique();

            entity.HasIndex(e => e.Id, "idx_StakeHolderId");

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
            entity.HasKey(e => e.Id).HasName("PK__Warranty__3214EC079C69C7F3");

            entity.ToTable("Warranty");

            entity.HasIndex(e => e.OrderDetailId, "IX_Warranty_OrderDetailId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Temporary");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Warranties)
                .HasForeignKey(d => d.OrderDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Warranty__OrderD__0D7A0286");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
