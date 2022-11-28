namespace PriceBuddy.Data.Models;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public virtual ICollection<ProductPriceHistory> PricesHistory { get; set; }
}
