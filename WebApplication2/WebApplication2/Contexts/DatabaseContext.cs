using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Contexts;

public class DatabaseContext: DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Categorie> Categories { get; set; }
    public DbSet<ProductCategorie> ProductCategories { get; set; }
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var roles = new List<Role>
        {
            new Role
            {
                Role_Id = 1,
                Name = "created"
            },
            new Role
            {
                Role_Id = 2,
                Name = "finished"
            },
            new Role
            {
                Role_Id = 3,
                Name = "removed"
            }
        };
        modelBuilder.Entity<Role>().HasData(roles);
        
        var accunts = new List<Account>
        {
            new Account
            {
                AccountId = 1,
                RoleId = 1,
                FirstName = "ll",
                LastName = "zz",
                Phone = "999999999",
                Email = "lllla"
                
            },
            new Account
            {
                AccountId = 2,
                RoleId = 1,
                FirstName = "ll",
                LastName = "zz",
                Phone = "999999999",
                Email = "lllla"
                
            }
        };

        modelBuilder.Entity<Account>().HasData(accunts);

        var categories = new List<Categorie>
        {
            new Categorie
            {
                CategoryId = 1,
                Name = "222"
            }
        };
        
        modelBuilder.Entity<Categorie>().HasData(categories);

        var products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                Name = "dfs",
                Depth = 22,
                Height = 23,
                Width = 11,
                Weight = 21
            }
        };
        modelBuilder.Entity<Product>().HasData(products);

        var productcategories = new List<ProductCategorie>
        {
            new ProductCategorie
            {
                CategoryId = 1,
                ProductId = 1
            }
        };
        modelBuilder.Entity<ProductCategorie>().HasData(productcategories);

        var shoppingcarts = new List<ShoppingCart>
        {
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 1,
                Amount = 20
            }
        };
        modelBuilder.Entity<ShoppingCart>().HasData(shoppingcarts);
    }
}