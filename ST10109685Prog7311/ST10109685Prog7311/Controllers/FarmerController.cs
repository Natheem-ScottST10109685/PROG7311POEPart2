using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ST10109685Prog7311.Data;
using ST10109685Prog7311.Models;
using System.Linq;

[Authorize(Roles = "Farmer")]
public class FarmerController : Controller
{
    private readonly UserDbContext _context;

    public FarmerController(UserDbContext context)
    {
        _context = context;
    }

    public IActionResult MyProducts()
    {
        var userEmail = User.Identity?.Name;
        var farmerName = _context.Users
            .Where(u => u.Email == userEmail)
            .Select(u => u.FirstName)
            .FirstOrDefault() ?? "Farmer";

        ViewBag.FarmerName = farmerName;

        var myProducts = _context.Products
            .Where(p => p.FarmerEmail == userEmail)
            .ToList();

        return View(myProducts);
    }

    // POST: Farmer/AddProduct
    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Product added successfully!";
            return RedirectToAction("MyProducts");
        }

        var products = _context.Products.ToList();
        return View("MyProducts", products);
    }


    public IActionResult EditProduct(int id)
    {
        var userEmail = User.Identity?.Name;
        var product = _context.Products
            .FirstOrDefault(p => p.ProductId == id && p.FarmerEmail == userEmail);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult EditProduct(Product product)
    {
        var userEmail = User.Identity?.Name;

        // Ensure the product belongs to the current farmer
        var existingProduct = _context.Products
            .FirstOrDefault(p => p.ProductId == product.ProductId && p.FarmerEmail == userEmail);

        if (existingProduct == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            // Update the existing product with new values
            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Product updated successfully!";
            return RedirectToAction(nameof(MyProducts));
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult DeleteProduct(int id)
    {
        var userEmail = User.Identity?.Name;
        var product = _context.Products
            .FirstOrDefault(p => p.ProductId == id && p.FarmerEmail == userEmail);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Product deleted successfully!";
        return RedirectToAction(nameof(MyProducts));
    }
}