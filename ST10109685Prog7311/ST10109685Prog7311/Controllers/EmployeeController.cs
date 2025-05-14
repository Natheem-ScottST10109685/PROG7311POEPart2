using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10109685Prog7311.Data;

[Authorize(Roles = "Employee")]
public class EmployeeController : Controller
{
    private readonly UserDbContext _context;

    public EmployeeController(UserDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageProducts(string category, string farmerEmail, string status)
    {
        var products = _context.Products.Include(p => p.User).AsQueryable();

        if (!string.IsNullOrEmpty(category))
            products = products.Where(p => p.Category == category);

        if (!string.IsNullOrEmpty(farmerEmail))
            products = products.Where(p => p.User.Email == farmerEmail);

        return View(products.ToList());
    }
}
