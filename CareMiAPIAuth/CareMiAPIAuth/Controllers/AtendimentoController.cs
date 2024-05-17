using CareMiAPIAuth.Data;
using CareMiAPIAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMiAPIAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            return View(await _context.Atendimento.Include(p => p.cdPaciente).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.cdPacientes = _context.Atendimento.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Atendimento newAtendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Atendimento.Add(newAtendimento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newAtendimento);
        }

        public IActionResult Edit(int ID)
        {
            var atendimento = _context.Atendimento.Find(ID);
            if (atendimento == null)
            {
                return NotFound();
            }
            return View(atendimento);
        }

        [HttpPost]
        public IActionResult Edit(Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(atendimento).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atendimento);
        }

        public IActionResult Delete(int ID)
        {
            var atendimento = _context.Atendimento.Find(ID);
            if (atendimento == null)
            {
                return NotFound();
            }
            return View(atendimento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var atendimento = _context.Atendimento.Find(ID);
            if (atendimento == null)
            {
                return NotFound();
            }
            _context.Atendimento.Remove(atendimento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}