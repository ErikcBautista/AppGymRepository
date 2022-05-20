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
    public class EmpleadosController : Controller
    {
        GymDatabaseContext _context = new GymDatabaseContext();
        //private readonly GymDatabaseContext _context;

        //public EmpleadosController(GymDatabaseContext context)
        //{
        //    _context = context;
        //}

        // GET: Empleados
        //public async Task<IActionResult> Index()
        //{
        //    var gymDatabaseContext = _context.Empleados.Include(e => e.IdJornadaEmpleadoNavigation);
        //    return View(await gymDatabaseContext.ToListAsync());
        //}
        public IActionResult Index()
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            return View(
                _context.Empleados
                .Include(e => e.IdJornadaEmpleadoNavigation)
                .ToList()
            );
        }
        // GET: Empleados/Details/5
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

            var empleados = await _context.Empleados
                .Include(e => e.IdJornadaEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            ViewData["IdJornadaEmpleado"] = new SelectList(_context.Jornadas, "IdJornada", "NombreDias");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,NombresEmpleado,ApellidosEmpleado,TelefonoEmpleado,NombreSesionEmpleado,PasswordEmpleado,IdJornadaEmpleado")] Empleados empleados)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJornadaEmpleado"] = new SelectList(_context.Jornadas, "IdJornada", "NombreDias", empleados.IdJornadaEmpleado);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
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

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            ViewData["IdJornadaEmpleado"] = new SelectList(_context.Jornadas, "IdJornada", "NombreDias", empleados.IdJornadaEmpleado);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,NombresEmpleado,ApellidosEmpleado,TelefonoEmpleado,NombreSesionEmpleado,PasswordEmpleado,IdJornadaEmpleado")] Empleados empleados)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            if (id != empleados.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.IdEmpleado))
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
            ViewData["IdJornadaEmpleado"] = new SelectList(_context.Jornadas, "IdJornada", "NombreDias", empleados.IdJornadaEmpleado);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
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

            var empleados = await _context.Empleados
                .Include(e => e.IdJornadaEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                return Redirect("~/InicioSesion/Index");
            }
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            string empleadoEnSesion = HttpContext.Session.GetString("empleadoEnSesion");
            if (empleadoEnSesion == null)
            {
                Redirect("~/InicioSesion/Index");
            }
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
