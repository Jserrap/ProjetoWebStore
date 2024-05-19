using Microsoft.EntityFrameworkCore;
using WebStoreApi.Entities;

namespace WebStoreApi.Data;

public class WebStoreContext : DbContext
{
    public WebStoreContext(DbContextOptions options) : base(options) {}
    public DbSet<SellerEntity> Sellers {get; set;} = null!;
    public DbSet<ProductEntity> Products {get; set;} = null!;
}
