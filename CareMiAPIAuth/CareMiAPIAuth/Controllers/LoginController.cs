using CareMiAPIAuth.Data;
using CareMiAPIAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CareMiAPIAuth.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            return View(await _context.Login.Include(p => p.cdUsuario).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.cdUsuario = _context.Login.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdLogin,nrCpf,dsSenha,fgAtivo")] Login login)
        {
            try
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return View(login);
        }

        public IActionResult Edit(int ID)
        {
            var login = _context.Login.Find(ID);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        [HttpPost]
        public IActionResult Edit(Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(login).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        public IActionResult Delete(int ID)
        {
            var login = _context.Login.Find(ID);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var login = _context.Login.Find(ID);
            if (login == null)
            {
                return NotFound();
            }
            _context.Login.Remove(login);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}