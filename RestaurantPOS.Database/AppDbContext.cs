using Microsoft.EntityFrameworkCore;

namespace RestaurantPOS.Database;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TblRole> TblRoles { get; set; }
    public DbSet<TblUser> TblUsers { get; set; }
    public DbSet<TblMainCategory> TblMainCategories { get; set; }
    public DbSet<TblCategory> TblCategories { get; set; }
    public DbSet<TblItem> TblItems { get; set; }
    public DbSet<TblServingTable> TblServingTables { get; set; }
    public DbSet<TblOrder> TblOrders { get; set; }
    public DbSet<TblOrderItem> TblOrderItems { get; set; }
    public DbSet<TblPayment> TblPayments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblRole>()
                .ToTable("tblrole", "public")
                .HasKey(r => r.RoleId);
        modelBuilder.Entity<TblRole>()
            .Property(e => e.RoleId)
            .HasColumnName("roleid");

        modelBuilder.Entity<TblRole>()
            .HasIndex(r => r.rolecode)
            .IsUnique();

        modelBuilder.Entity<TblUser>()
            .ToTable("tbluser", "public")
            .HasKey(u => u.UserId);

        modelBuilder.Entity<TblUser>()
            .HasOne<TblRole>()
            .WithMany()
            .HasForeignKey(u => u.RoleCode)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblMainCategory>()
            .ToTable("tblMainCategory", "public")
            .HasKey(mc => mc.MainCategoryID);

        modelBuilder.Entity<TblCategory>()
            .ToTable("tblCategory", "public")
            .HasKey(c => c.CategoryID);

        modelBuilder.Entity<TblCategory>()
            .HasOne<TblMainCategory>()
            .WithMany()
            .HasForeignKey(c => c.MainCategoryCode)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblCategory>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblCategory>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(c => c.ModifiedBy)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblItem>()
            .ToTable("tblItem", "public")
            .HasKey(i => i.ItemId);

        modelBuilder.Entity<TblItem>()
            .HasOne<TblCategory>()
            .WithMany()
            .HasForeignKey(i => i.CategoryCode)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblItem>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(i => i.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblItem>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(i => i.ModifiedBy)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblServingTable>()
            .ToTable("tblServingTable", "public")
            .HasKey(st => st.ServingTableID);

        modelBuilder.Entity<TblOrder>()
            .ToTable("tblOrder", "public")
            .HasKey(o => o.OrderID);

        modelBuilder.Entity<TblOrder>()
            .HasOne<TblServingTable>()
            .WithMany()
            .HasForeignKey(o => o.TableNumber);

        modelBuilder.Entity<TblOrder>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(o => o.CreatedBy);

        modelBuilder.Entity<TblOrder>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(o => o.ClosedBy);

        modelBuilder.Entity<TblOrderItem>()
            .ToTable("tblOrderItem", "public")
            .HasKey(oi => oi.OrderItemID);

        modelBuilder.Entity<TblOrderItem>()
            .HasOne<TblOrder>()
            .WithMany()
            .HasForeignKey(oi => oi.OrderID);

        modelBuilder.Entity<TblOrderItem>()
            .HasOne<TblItem>()
            .WithMany()
            .HasForeignKey(oi => oi.ItemCode);

        modelBuilder.Entity<TblPayment>()
            .ToTable("tblPayment", "public")
            .HasKey(p => p.PaymentID);

        modelBuilder.Entity<TblPayment>()
            .HasOne<TblOrder>()
            .WithMany()
            .HasForeignKey(p => p.OrderID);

        modelBuilder.Entity<TblPayment>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(p => p.RecivedBy);
    }
}
