using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocoloTeste.Models;

namespace ProtocoloTeste.Controllers
{
    public class StatusProtocoloesController : Controller
    {
        private readonly ProtocoloDbContext _context;

        public StatusProtocoloesController(ProtocoloDbContext context)
        {
            _context = context;
        }

        // GET: StatusProtocoloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusProtocolos.ToListAsync());
        }

        // GET: StatusProtocoloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }

            return View(statusProtocolo);
        }

        // GET: StatusProtocoloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusProtocoloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatus,NomeStatus")] StatusProtocolo statusProtocolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusProtocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusProtocolo);
        }

        // GET: StatusProtocoloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos.FindAsync(id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }
            return View(statusProtocolo);
        }

        // POST: StatusProtocoloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatus,NomeStatus")] StatusProtocolo statusProtocolo)
        {
            if (id != statusProtocolo.IdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusProtocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusProtocoloExists(statusProtocolo.IdStatus))
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
            return View(statusProtocolo);
        }

        // GET: StatusProtocoloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }

            return View(statusProtocolo);
        }

        // POST: StatusProtocoloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusProtocolo = await _context.StatusProtocolos.FindAsync(id);
            if (statusProtocolo != null)
            {
                _context.StatusProtocolos.Remove(statusProtocolo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusProtocoloExists(int id)
        {
            return _context.StatusProtocolos.Any(e => e.IdStatus == id);
        }
    }
}
