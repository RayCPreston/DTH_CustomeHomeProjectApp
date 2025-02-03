using Microsoft.AspNetCore.Mvc;

namespace DTH.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(Exception ex)
        {
            ViewData["ErrorMessage"] = ex.Message;
            return View();
        }
    }
}
