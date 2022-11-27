using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using PriceBuddy.Data.Models;

namespace PriceBuddy.Data.Repositories;

public class ProductRepository
{
    private PriceBuddyDbContext _context;
    public ProductRepository(PriceBuddyDbContext context)
    {
        this._context = context;
    }

    public List<Product> Products { get; init; } = new List<Product>();

    public async Task<IList<Product>> Get()
    {
        return this._context.Products.ToList();
    }

    public Product GetById(Guid id)
    {
        return this._context.Products.FirstOrDefault(p => p.Id.Equals(id));
    }

    public async Task<Product> Add(Product product)
    {
        this._context.Products.Add(product);

        return await this._context.SaveChangesAsync() > 0 ? product : null;
    }
}
