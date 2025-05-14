using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ST10109685Prog7311.Models;
using ST10109685Prog7311.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly UserDbContext _context;

    public AccountController(UserDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user != null && PasswordHelper.VerifyPassword(model.Password, user.PasswordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("FullName", $"{user.FirstName} {user.Surname}")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                // Redirect based on role
                if (user.Role == "Farmer")
                {
                    return RedirectToAction("FarmerDash", "Dashboard");
                }
                else if (user.Role == "Employee")
                {
                    return RedirectToAction("EmployeeDash", "Dashboard");
                }
            }

            ModelState.AddModelError("", "Invalid email or password.");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
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

            return RedirectToAction("Login", "Account");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
