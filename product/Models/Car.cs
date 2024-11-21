namespace product.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Car
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
}