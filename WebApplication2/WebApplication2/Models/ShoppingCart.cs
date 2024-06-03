﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;
[Table("Shopping_Carts"),PrimaryKey("Account","Product")]
public class ShoppingCart
{
    
    [ForeignKey("Account")]
    [Column("FK_account")]
    public int AccountId { get; set; }
    public Account Account { get; set; }

    
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    [Column("amount")]
    public int Amount { get; set; }
}