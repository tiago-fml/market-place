using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalog_service.Models;

public class Product : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public bool IsDiscontinued { get; set; }
    
    [ForeignKey(nameof(UnitOfMeasure))]
    public Guid UnitOfMeasureId { get; set; }
    
    public UnitOfMeasure UnitOfMeasure { get; set; }
}