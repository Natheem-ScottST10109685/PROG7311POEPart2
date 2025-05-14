using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10109685Prog7311.Data;
using ST10109685Prog7311.Models;

[Authorize(Roles = "Employee")]
public class EmployeeController : Controller
{
    private readonly UserDbContext _context;

    public EmployeeController(UserDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageProducts(string category)
    {
        var products = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(category))
            products = products.Where(p => p.Category == category);

        return View(products.ToList());
    }

    // GET: Add Farmer
    public IActionResult AddFarmer()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> AddFarmer(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Role = "Farmer"; 

            var user = new User
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                Email = model.Email,
                Role = model.Role,
                PasswordHash = PasswordHelper.HashPassword(model.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Farmer added successfully!";
            return RedirectToAction("AddFarmer");
        }

        return View(model);
    }

}
