using Microsoft.EntityFrameworkCore;
using PriceBuddy.Data.Models;

namespace PriceBuddy.Data;

public class PriceBuddyDbContext : DbContext
{
    public PriceBuddyDbContext()
    {
    }

    public PriceBuddyDbContext(DbContextOptions<PriceBuddyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductPriceHistory> ProductsPricesHistories { get; set; }
    public virtual DbSet<Store> Stores { get; set; }

}
