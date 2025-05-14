using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10109685Prog7311.Data;
using ST10109685Prog7311.Models;
using System.Linq;

public class MarketController : Controller
{
    private readonly UserDbContext _context;

    public MarketController(UserDbContext context)
    {
        _context = context;
    }

    // GET: /Market/AllProducts
    public IActionResult AllProducts()
    {
        var products = _context.Products
            .Include(p => p.User)
            .ToList();

        ViewBag.Username = HttpContext.Session.GetString("Username") ?? "User";
        ViewBag.Categories = _context.Products
            .Select(p => p.Category)
            .Distinct()
            .ToList();

        return View(products);
    }

    // GET: /Market/ProductDetails/5
    public IActionResult ProductDetails(int id)
    {
        var product = _context.Products
            .Include(p => p.User)
            .FirstOrDefault(p => p.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }

        ViewBag.Username = HttpContext.Session.GetString("Username") ?? "User";
        return View(product);
    }

    // GET: /Market/FilterProducts?category=Solar
    public IActionResult FilterProducts(string category)
    {
        var productsQuery = _context.Products
            .Include(p => p.User)
            .AsQueryable();

        if (!string.IsNullOrEmpty(category) && category != "All")
        {
            productsQuery = productsQuery.Where(p => p.Category == category);
        }

        var products = productsQuery.ToList();

        ViewBag.Username = HttpContext.Session.GetString("Username") ?? "User";
        ViewBag.SelectedCategory = category ?? "All";
        ViewBag.Categories = _context.Products
            .Select(p => p.Category)
            .Distinct()
            .ToList();

        return View("AllProducts", products);
    }
}
