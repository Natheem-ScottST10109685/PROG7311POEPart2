using Microsoft.AspNetCore.Mvc;
using ST10109685Prog7311.Models;
using System.Linq;
using System;
using ST10109685Prog7311.Data;

namespace ST10109685Prog7311.Controllers
{
    public class FarmerController : Controller
    {
        private readonly UserDbContext _context;

        public FarmerController(UserDbContext context)
        {
            _context = context;
        }

        public IActionResult MyProducts()
        {
            var products = _context.Products.ToList();
            ViewBag.FarmerName = "Farmer";
            return View(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductionDate = DateTime.Now; // Set ProductDate
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction("MyProducts");
            }

            return View("MyProducts", _context.Products.ToList());
        }

        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(updatedProduct.ProductId);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update fields
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Category = updatedProduct.Category;
                existingProduct.Price = updatedProduct.Price;

                // Keep the original ProductDate
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction("MyProducts");
            }

            return View(updatedProduct);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Product deleted successfully!";
            return RedirectToAction("MyProducts");
        }
    }
}
