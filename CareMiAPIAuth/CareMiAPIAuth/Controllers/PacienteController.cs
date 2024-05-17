using CareMiAPIAuth.Data;
using CareMiAPIAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CareMiAPIAuth.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.Include(p => p.cdUsuario).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.cdUsuario = _context.Paciente.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdPaciente,nmPaciente,nrPeso,nrAltura,nmGrupoSanguineo,flSexoBiologico")] Paciente paciente)
        {
            try
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return View(paciente);
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