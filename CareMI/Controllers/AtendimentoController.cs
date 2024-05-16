using CareMI.Data;
using CareMI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareMI.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Atendimento.ToList());
        }

        public IActionResult Create()
        {
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
