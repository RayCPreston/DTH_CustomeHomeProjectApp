using Microsoft.AspNetCore.Mvc;

namespace DTH.App.Controllers
{
    public class GetHomeProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
