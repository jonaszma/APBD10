using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[Table("Shopping_Carts"),PrimaryKey("Account","Product")]
public class ShoppingCart
{
    
    [ForeignKey("Account")]
    [Column("FK_account")]
    public int AccountId { get; set; }

    public Account Account { get; set; } = null!;

    
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;
    
    [Column("amount")]
    public int Amount { get; set; }
}