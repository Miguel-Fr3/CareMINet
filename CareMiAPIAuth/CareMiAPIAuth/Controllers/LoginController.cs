using CareMiAPIAuth.Data;
using CareMiAPIAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMiAPIAuth.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Login.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Login newLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Login.Add(newLogin);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newLogin);
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