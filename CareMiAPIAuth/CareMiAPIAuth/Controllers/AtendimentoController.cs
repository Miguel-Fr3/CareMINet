using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareMiAPIAuth.Data;
using CareMiAPIAuth.Models;

namespace CareMiAPIAuth.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Atendimento.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .FirstOrDefaultAsync(m => m.cdAtendimento == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cdAtendimento,dsDescricao,qtDias,dsHabito,dsTempoSono,dsHereditario,dtEnvio,fgAtivo")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atendimento);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return View(atendimento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cdAtendimento,dsDescricao,qtDias,dsHabito,dsTempoSono,dsHereditario,dtEnvio,fgAtivo")] Atendimento atendimento)
        {
            if (id != atendimento.cdAtendimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.cdAtendimento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(atendimento);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .FirstOrDefaultAsync(m => m.cdAtendimento == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimento.Remove(atendimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(int id)
        {
            return _context.Atendimento.Any(e => e.cdAtendimento == id);
        }
    }
}
