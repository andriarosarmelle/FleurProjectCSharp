using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoutiqueFleurs.Data;
using BoutiqueFleurs.Models;

namespace BoutiqueFleurs.Controllers
{
    public class FleursController : Controller
    {
        private readonly BoutiqueFleursContext _context;

        public FleursController(BoutiqueFleursContext context)
        {
            _context = context;
        }

        // GET: Fleurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fleurs.ToListAsync());
        }

        // GET: Fleurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var fleur = await _context.Fleurs.FirstOrDefaultAsync(m => m.Id == id);
            if (fleur == null) return NotFound();
            return View(fleur);
        }

        // GET: Fleurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fleurs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomF,Couleurs,PrixF")] Fleur fleur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fleur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fleur);
        }

        // GET: Fleurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var fleur = await _context.Fleurs.FindAsync(id);
            if (fleur == null) return NotFound();
            return View(fleur);
        }

        // POST: Fleurs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomF,Couleurs,PrixF")] Fleur fleur)
        {
            if (id != fleur.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fleur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FleurExists(fleur.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fleur);
        }

        // GET: Fleurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var fleur = await _context.Fleurs.FindAsync(id);
            if (fleur == null) return NotFound();
            return View(fleur);
        }

        // POST: Fleurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fleur = await _context.Fleurs.FindAsync(id);
            if (fleur != null)
            {
                _context.Fleurs.Remove(fleur);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FleurExists(int id)
        {
            return _context.Fleurs.Any(e => e.Id == id);
        }
    }
}