using CareMI.Data;
using CareMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Usuario.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario newUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(newUsuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUsuario);
        }

        public IActionResult Edit(int ID)
        {
            var usuario = _context.Usuario.Find(ID);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Delete(int ID)
        {
            var usuario = _context.Usuario.Find(ID);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var usuario = _context.Usuario.Find(ID);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}