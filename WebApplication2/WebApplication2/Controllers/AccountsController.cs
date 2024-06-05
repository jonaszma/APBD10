using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController:ControllerBase
{
    
    private readonly DatabaseContext _context;


    public AccountsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        var account= await _context.Accounts
            .Include(a=>a.ShoppingCarts)
            .ThenInclude(c => c.Product)
            .SingleOrDefaultAsync(a => a.AccountId == id);
        
        if (account == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            firstName = account.FirstName,
            lastName = account.LastName,
            email = account.Email,
            phone = account.Phone,
            role = account.Role.Name,
            cart = account.ShoppingCarts.Select(c => new
            {
                productId = c.ProductId,
                productName = c.Product.Name,
                amount = c.Amount
            }).ToList()
        });
    }
}