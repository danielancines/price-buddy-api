namespace PriceBuddy.Data.Models;

public class ProductPriceHistory
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public virtual Store Store { get; set; }
}