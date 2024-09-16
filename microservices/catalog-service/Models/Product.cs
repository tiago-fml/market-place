using System.ComponentModel.DataAnnotations;

namespace catalog_service.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public bool IsDiscontinued { get; set; }
    public double AvailableStock { get; set; }
}