using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("weight", TypeName = "decimal(5, 2)")]
    public double Weight { get; set; }
    
    [Column("width", TypeName = "decimal(5, 2)")]
    public double Width { get; set; }
    
    [Column("height", TypeName = "decimal(5, 2)")]
    public double Height { get; set; }
    
    [Column("depth", TypeName = "decimal(5, 2)")]
    public double Depth { get; set; }
    
    public IEnumerable<ProductCategory> ProductsCategories {get; set; } = [];

    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; } = [];
}