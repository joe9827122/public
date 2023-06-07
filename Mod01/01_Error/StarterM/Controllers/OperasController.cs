using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarterM.Data;
using StarterM.Models;

namespace StarterM.Controllers
{
    public class OperasController : Controller
    {
        private readonly OperaContext _context;

        // /Operas/DetailsByTitle?title=Rigoletto
        // custom route : /operatitle/Rigoletto
        // 此方法無法使用原路徑規則
        [Route("operatitle/{title}", Name ="custom")]
        public async Task<IActionResult> DetailsByTitle(String? title)
        {
            if (title == null) return NotFound();
            var opera = await _context.Operas.FirstOrDefaultAsync(o => o.Title == title);
            if (opera == null) return NotFound();
            return View(nameof(Details), opera);
        }

        public OperasController(OperaContext context)
        {
            _context = context;
        }

        // GET: Operas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Operas.ToListAsync());
        }

        // GET: Operas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Operas == null)
            {
                return NotFound();
            }

            var opera = await _context.Operas
                .FirstOrDefaultAsync(m => m.OperaID == id);
            if (opera == null)
            {
                return NotFound();
            }

            return View(opera);
        }

        // GET: Operas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperaID,Title,Year,Composer")] Opera opera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opera);
        }

        // GET: Operas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Operas == null)
            {
                return NotFound();
            }

            var opera = await _context.Operas.FindAsync(id);
            if (opera == null)
            {
                return NotFound();
            }
            return View(opera);
        }

        // POST: Operas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperaID,Title,Year,Composer")] Opera opera)
        {
            if (id != opera.OperaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperaExists(opera.OperaID))
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
            return View(opera);
        }

        // GET: Operas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Operas == null)
            {
                return NotFound();
            }

            var opera = await _context.Operas
                .FirstOrDefaultAsync(m => m.OperaID == id);
            if (opera == null)
            {
                return NotFound();
            }

            return View(opera);
        }

        // POST: Operas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operas == null)
            {
                return Problem("Entity set 'OperaContext.Opera'  is null.");
            }
            var opera = await _context.Operas.FindAsync(id);
            if (opera != null)
            {
                _context.Operas.Remove(opera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperaExists(int id)
        {
          return _context.Operas.Any(e => e.OperaID == id);
        }
    }
}
