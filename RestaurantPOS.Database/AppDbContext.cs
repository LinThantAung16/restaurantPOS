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
            .HasKey(u => u.userid);

        modelBuilder.Entity<TblUser>()
            .HasOne<TblRole>()
            .WithMany()
            .HasForeignKey(u => u.rolecode)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblMainCategory>()
            .ToTable("tblMainCategory", "public")
            .HasKey(mc => mc.maincategoryid);

        modelBuilder.Entity<TblCategory>()
            .ToTable("tblCategory", "public")
            .HasKey(c => c.categoryid);

        modelBuilder.Entity<TblCategory>()
            .HasOne<TblMainCategory>()
            .WithMany()
            .HasForeignKey(c => c.maincategorycode)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblCategory>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(c => c.createdby)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblCategory>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(c => c.modifiedby)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblItem>()
            .ToTable("tblItem", "public")
            .HasKey(i => i.itemid);

        modelBuilder.Entity<TblItem>()
            .HasOne<TblCategory>()
            .WithMany()
            .HasForeignKey(i => i.categorycode)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblItem>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(i => i.createdby)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblItem>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(i => i.modifiedby)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TblServingTable>()
            .ToTable("tblServingTable", "public")
            .HasKey(st => st.servingtableid);

        modelBuilder.Entity<TblOrder>()
            .ToTable("tblOrder", "public")
            .HasKey(o => o.orderid);

        modelBuilder.Entity<TblOrder>()
            .HasOne<TblServingTable>()
            .WithMany()
            .HasForeignKey(o => o.tablenumber);

        modelBuilder.Entity<TblOrder>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(o => o.createdby);

        modelBuilder.Entity<TblOrder>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(o => o.closedby);

        modelBuilder.Entity<TblOrderItem>()
            .ToTable("tblOrderItem", "public")
            .HasKey(oi => oi.orderitemid);

        modelBuilder.Entity<TblOrderItem>()
            .HasOne<TblOrder>()
            .WithMany()
            .HasForeignKey(oi => oi.orderid);

        modelBuilder.Entity<TblOrderItem>()
            .HasOne<TblItem>()
            .WithMany()
            .HasForeignKey(oi => oi.itemcode);

        modelBuilder.Entity<TblPayment>()
            .ToTable("tblPayment", "public")
            .HasKey(p => p.paymentid);

        modelBuilder.Entity<TblPayment>()
            .HasOne<TblOrder>()
            .WithMany()
            .HasForeignKey(p => p.orderid);

        modelBuilder.Entity<TblPayment>()
            .HasOne<TblUser>()
            .WithMany()
            .HasForeignKey(p => p.recivedby);
    }
}
