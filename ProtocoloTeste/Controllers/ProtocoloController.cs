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
    public class ProtocoloController : Controller
    {
        private readonly ProtocoloDbContext _context;

        public ProtocoloController(ProtocoloDbContext context)
        {
            _context = context;
        }

        // GET: Protocolo
        public async Task<IActionResult> Index()
        {
            var protocoloDbContext = _context.Protocolos.Include(p => p.Cliente).Include(p => p.ProtocoloStatus);
            return View(await protocoloDbContext.ToListAsync());
        }

        // GET: Protocolo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .Include(p => p.Cliente)
                .Include(p => p.ProtocoloStatus)
                .FirstOrDefaultAsync(m => m.IdProtocolo == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // GET: Protocolo/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente","Nome");
            ViewData["ProtocoloStatusId"] = new SelectList(_context.StatusProtocolos, "IdStatus", "NomeStatus");
            return View();
        }

        // POST: Protocolo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProtocolo,Titulo,Descricao,DataAbertura,DataFechamento,ClienteId,ProtocoloStatusId")] Protocolo protocolo)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(protocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Email", protocolo.ClienteId);
            ViewData["ProtocoloStatusId"] = new SelectList(_context.StatusProtocolos, "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);
            return View(protocolo);
        }

        // GET: Protocolo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos.FindAsync(id);
            if (protocolo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Email", protocolo.ClienteId);
            ViewData["ProtocoloStatusId"] = new SelectList(_context.StatusProtocolos, "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);
            return View(protocolo);
        }

        // POST: Protocolo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProtocolo,Titulo,Descricao,DataAbertura,DataFechamento,ClienteId,ProtocoloStatusId")] Protocolo protocolo)
        {
            if (id != protocolo.IdProtocolo)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(protocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloExists(protocolo.IdProtocolo))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Email", protocolo.ClienteId);
            ViewData["ProtocoloStatusId"] = new SelectList(_context.StatusProtocolos, "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);
            return View(protocolo);
        }

        // GET: Protocolo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .Include(p => p.Cliente)
                .Include(p => p.ProtocoloStatus)
                .FirstOrDefaultAsync(m => m.IdProtocolo == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // POST: Protocolo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocolo = await _context.Protocolos.FindAsync(id);
            if (protocolo != null)
            {
                _context.Protocolos.Remove(protocolo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolos.Any(e => e.IdProtocolo == id);
        }
    }
}
