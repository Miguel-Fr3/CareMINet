using CareMiAPIAuth.Data;
using CareMiAPIAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMiAPIAuth.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Paciente.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paciente newPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Paciente.Add(newPaciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newPaciente);
        }

        public IActionResult Edit(int ID)
        {
            var paciente = _context.Paciente.Find(ID);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(paciente).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public IActionResult Delete(int ID)
        {
            var paciente = _context.Paciente.Find(ID);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var paciente = _context.Paciente.Find(ID);
            if (paciente == null)
            {
                return NotFound();
            }
            _context.Paciente.Remove(paciente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}