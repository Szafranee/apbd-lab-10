using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab_10.Models;

[Table("Shopping_Carts")]
[PrimaryKey(nameof(AccountId), nameof(ProductId))]
public class ShoppingCart
{
    [Column("FK_account")]
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public Account Account { get; set; }
    
    [Column("FK_product")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Column("amount")]
    public int Amount { get; set; }
}