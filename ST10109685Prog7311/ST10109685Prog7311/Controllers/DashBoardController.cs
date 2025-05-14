using Microsoft.AspNetCore.Mvc;
using ST10109685Prog7311.Models;

namespace ST10109685Prog7311.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult FarmerDash()
        {
            return View();
        }

        public IActionResult EmployeeDash()
        {
            return View();
        }
        public IActionResult Training()
        {
            return View();
        }

        public IActionResult Collaboration()
        {
            return View();
        }
    }
}