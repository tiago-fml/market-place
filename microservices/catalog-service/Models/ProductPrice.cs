using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalog_service.Models;

public class ProductPrice
{
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public double Price { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public Product Product { get; set; }
    
    // Method to get the current price based on the current date
    public static double? GetCurrentPrice(List<ProductPrice> prices)
    {
        var currentDate = DateTimeOffset.Now;
        
        // Find the active price based on the current date
        var currentPrice = prices.FirstOrDefault(p =>
            p.StartDate <= currentDate && p.EndDate >= currentDate);
        
        return currentPrice?.Price; // Return the price or null if no active price found
    }
}