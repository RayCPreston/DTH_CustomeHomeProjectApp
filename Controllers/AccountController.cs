using System.Security.Claims;
using DTH.App.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DTH.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(ILogger<AccountController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("user-client");

                HttpContext.Session.SetString("Username", model.Username);
                HttpContext.Session.SetString("Password", model.Password);
                HttpResponseMessage response = await client.GetAsync("login");
                if (response.IsSuccessStatusCode)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties authProperties = new AuthenticationProperties { IsPersistent = true };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Dashboard", "Projects");
                }
                HttpContext.Session.Clear();
                ModelState.AddModelError("", "Invalid credentials.  Please try again.");
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AccountController.Login Exception: {ex.Message}");
                return RedirectToAction("Error", "Home", new { ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
