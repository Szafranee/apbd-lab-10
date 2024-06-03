using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab_10.Models;

[Table("Products_Categories")]
[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategory
{
    [Column("FK_product")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    [Column("FK_category")]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}