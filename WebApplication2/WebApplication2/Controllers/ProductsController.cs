using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController: ControllerBase
{
    private readonly DatabaseContext _context;


    public ProductsController(DatabaseContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = new Product
        {
            Name = productDto.ProductName,
            Weight = productDto.ProductWeight,
            Width = productDto.ProductWidth,
            Height = productDto.ProductHeight,
            Depth = productDto.ProductDepth,
            ProductCategorie = productDto.ProductCategories
                .Select(categoryId => new ProductCategorie
                {
                    CategoryId = categoryId
                }).ToList()
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(AddProduct), new { id = product.ProductId }, product);
    }
}