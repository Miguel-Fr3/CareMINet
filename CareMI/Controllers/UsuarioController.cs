using Microsoft.AspNetCore.Mvc;

namespace CareMI.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
