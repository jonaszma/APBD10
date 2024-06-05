using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("weight")]
    [Precision(5,2)]
    public double Weight { get; set; }

    [Column("width")]
    [Precision(5,2)]
    public double Width { get; set; }
    
    [Column("height")]
    [Precision(5,2)]
    public double Height { get; set; }
    
    [Column("depth")]
    [Precision(5,2)]
    public double Depth { get; set; }

    public virtual ICollection<ProductCategorie> ProductCategorie { get; set; } = null;

    public virtual ICollection<ShoppingCart> ShoppingCarts { set; get; } = null;
}