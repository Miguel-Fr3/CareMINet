using Microsoft.AspNetCore.Mvc;

namespace CareMI.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
