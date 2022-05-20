
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

    public class JornadasController : Controller
    {
        //private readonly GymDatabaseContext _context;
        GymDatabaseContext _context = new GymDatabaseContext();
        //public JornadasController(GymDatabaseContext context)
        //{
        //    _context = context;
        //}

        // GET: Jornadas
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Jornadas.ToListAsync());
        //}
        public IActionResult Index()
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if( empleadoEnSesion == null )
            {
                return Redirect("~/InicioSesion/Index");
            }
            return View(_context.Jornadas.ToList());
        }

        // GET: Jornadas/Details/5
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

            var jornadas = await _context.Jornadas
                .FirstOrDefaultAsync(m => m.IdJornada == id);
            if (jornadas == null)
            {
                return NotFound();
            }

            return View(jornadas);
        }

        // GET: Jornadas/Create
        public IActionResult Create()
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            return View();
        }

        // POST: Jornadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJornada,NombreJornada,DiasJornada,NombreDias")] Jornadas jornadas)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (ModelState.IsValid)
            {
                _context.Add(jornadas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jornadas);
        }

        // GET: Jornadas/Edit/5
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

            var jornadas = await _context.Jornadas.FindAsync(id);
            if (jornadas == null)
            {
                return NotFound();
            }
            return View(jornadas);
        }

        // POST: Jornadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJornada,NombreJornada,DiasJornada,NombreDias")] Jornadas jornadas)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (id != jornadas.IdJornada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornadas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornadasExists(jornadas.IdJornada))
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
            return View(jornadas);
        }

        // GET: Jornadas/Delete/5
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

            var jornadas = await _context.Jornadas
                .FirstOrDefaultAsync(m => m.IdJornada == id);
            if (jornadas == null)
            {
                return NotFound();
            }

            return View(jornadas);
        }

        // POST: Jornadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            var jornadas = await _context.Jornadas.FindAsync(id);
            _context.Jornadas.Remove(jornadas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornadasExists(int id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                Redirect("~/InicioSesion/Index");
            }
            return _context.Jornadas.Any(e => e.IdJornada == id);
        }
    }
}
