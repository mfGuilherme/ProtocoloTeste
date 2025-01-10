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
    public class ProtocoloFollowsController : Controller
    {
        private readonly ProtocoloDbContext _context;

        public ProtocoloFollowsController(ProtocoloDbContext context)
        {
            _context = context;
        }

        // GET: ProtocoloFollows
        public async Task<IActionResult> Index()
        {
            var protocoloDbContext = _context.ProtocoloFollows.Include(p => p.Protocolo);
            return View(await protocoloDbContext.ToListAsync());
        }

        // GET: ProtocoloFollows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows
                .Include(p => p.Protocolo)
                .FirstOrDefaultAsync(m => m.IdFollow == id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }

            return View(protocoloFollow);
        }

        // GET: ProtocoloFollows/Create
        public IActionResult Create()
        {
            ViewData["ProtocoloId"] = new SelectList(_context.Protocolos, "IdProtocolo", "Titulo");
            return View();
        }

        // POST: ProtocoloFollows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFollow,ProtocoloId,DataAcao,DescricaoAcao")] ProtocoloFollow protocoloFollow)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(protocoloFollow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["ProtocoloId"] = new SelectList(_context.Protocolos, "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        // GET: ProtocoloFollows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows.FindAsync(id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }
            ViewData["ProtocoloId"] = new SelectList(_context.Protocolos, "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        // POST: ProtocoloFollows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFollow,ProtocoloId,DataAcao,DescricaoAcao")] ProtocoloFollow protocoloFollow)
        {
            if (id != protocoloFollow.IdFollow)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(protocoloFollow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloFollowExists(protocoloFollow.IdFollow))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["ProtocoloId"] = new SelectList(_context.Protocolos, "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        // GET: ProtocoloFollows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows
                .Include(p => p.Protocolo)
                .FirstOrDefaultAsync(m => m.IdFollow == id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }

            return View(protocoloFollow);
        }

        // POST: ProtocoloFollows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocoloFollow = await _context.ProtocoloFollows.FindAsync(id);
            if (protocoloFollow != null)
            {
                _context.ProtocoloFollows.Remove(protocoloFollow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloFollowExists(int id)
        {
            return _context.ProtocoloFollows.Any(e => e.IdFollow == id);
        }
    }
}
