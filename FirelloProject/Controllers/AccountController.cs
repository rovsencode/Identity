using Microsoft.AspNetCore.Mvc;

namespace FirelloProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
