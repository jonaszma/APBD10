using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[Table("Products_categories"),PrimaryKey("Product","Categorie")]
public class ProductCategorie
{
    
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    
    
    [ForeignKey("Categorie")]
    [Column("FK_category")]
    public int CategoryId { get; set; }

    public virtual Categorie Categorie { get; set; } = null!;

}