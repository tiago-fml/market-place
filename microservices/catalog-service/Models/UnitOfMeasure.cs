using System.ComponentModel.DataAnnotations;

namespace catalog_service.Models;

public class UnitOfMeasure : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IntegerQuantity { get; set; }
}