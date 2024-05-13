using CareMI.Data;
using CareMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMI.Controllers
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
            return View(_context.pacientes.ToList());
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
                _context.pacientes.Add(newPaciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newPaciente);
        }

        public IActionResult Edit(int ID)
        {
            var paciente = _context.pacientes.Find(ID);
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
            var paciente = _context.pacientes.Find(ID);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var paciente = _context.pacientes.Find(ID);
            if (paciente == null)
            {
                return NotFound();
            }
            _context.pacientes.Remove(paciente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}