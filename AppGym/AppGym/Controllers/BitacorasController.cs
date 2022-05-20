using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppGym.Models;
using Microsoft.AspNetCore.Http;

namespace AppGym.Controllers
{
    public class BitacorasController : Controller
    {
        GymDatabaseContext _context = new GymDatabaseContext();
        //private readonly GymDatabaseContext _context;

        //public BitacorasController(GymDatabaseContext context)
        //{
        //    _context = context;
        //}

        //// GET: Bitacoras
        //public async Task<IActionResult> Index()
        //{
        //    var gymDatabaseContext = _context.Bitacoras.Include(b => b.IdEmpleadoBitacoraNavigation);
        //    return View(await gymDatabaseContext.ToListAsync());
        //}
        
        public IActionResult Index()
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            return View(_context.Bitacoras.ToList());
        }
        // GET: Bitacoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var bitacoras = await _context.Bitacoras
                .Include(b => b.IdEmpleadoBitacoraNavigation)
                .FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacoras == null)
            {
                return NotFound();
            }

            return View(bitacoras);
        }

        // GET: Bitacoras/Create
        public IActionResult Create()
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            ViewData["IdEmpleadoBitacora"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado");
            return View();
        }

        // POST: Bitacoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBitacora,Asistencia,IdEmpleadoBitacora")] Bitacoras bitacoras)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (ModelState.IsValid)
            {
                _context.Add(bitacoras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleadoBitacora"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", bitacoras.IdEmpleadoBitacora);
            return View(bitacoras);
        }

        // GET: Bitacoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var bitacoras = await _context.Bitacoras.FindAsync(id);
            if (bitacoras == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleadoBitacora"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", bitacoras.IdEmpleadoBitacora);
            return View(bitacoras);
        }

        // POST: Bitacoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBitacora,Asistencia,IdEmpleadoBitacora")] Bitacoras bitacoras)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (id != bitacoras.IdBitacora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bitacoras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BitacorasExists(bitacoras.IdBitacora))
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
            ViewData["IdEmpleadoBitacora"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", bitacoras.IdEmpleadoBitacora);
            return View(bitacoras);
        }

        // GET: Bitacoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var bitacoras = await _context.Bitacoras
                .Include(b => b.IdEmpleadoBitacoraNavigation)
                .FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacoras == null)
            {
                return NotFound();
            }

            return View(bitacoras);
        }

        // POST: Bitacoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            var bitacoras = await _context.Bitacoras.FindAsync(id);
            _context.Bitacoras.Remove(bitacoras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BitacorasExists(int id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                Redirect("~/InicioSesion/Index");
            }
            return _context.Bitacoras.Any(e => e.IdBitacora == id);
        }
    }
}
