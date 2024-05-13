using Microsoft.AspNetCore.Mvc;

namespace CareMI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
