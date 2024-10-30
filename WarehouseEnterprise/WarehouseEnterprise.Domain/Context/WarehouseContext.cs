using Microsoft.EntityFrameworkCore;

namespace WarehouseEnterprise.Domain.Context;

public class WarehouseContext(DbContextOptions<WarehouseContext> options) : DbContext(options)
{
    public DbSet<Cell> Cells { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Supply> Supplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cell>(entity =>
        {
            entity.HasOne(c => c.Product)
                  .WithMany()
                  .HasForeignKey("product")
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Navigation(c => c.Product);
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasOne(s => s.Product)
                  .WithMany()
                  .HasForeignKey("product")
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Organization)
                  .WithMany()
                  .HasForeignKey("organization")
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Navigation(s => s.Product);

            entity.Navigation(s => s.Organization);
        });
    }
}
