using AppGym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppGym.Controllers
{
    public class InicioSesionController : Controller
    {
        GymDatabaseContext _context = new GymDatabaseContext();
        // GET: InicioSesion
        public IActionResult Index()
        {
            return View();
        }

        // GET: InicioSesion/Details/5

        // GET: InicioSesion/Create
        [HttpPost]
        public IActionResult Validation(InicioSesion  inicioSesion)
        {
            Empleados empleadoEncontrado = _context.Empleados.ToList().Find( x =>
            x.NombreSesionEmpleado.Equals(inicioSesion.NombreSesionEmpleado) &&
            x.PasswordEmpleado.Equals(inicioSesion.PasswordEmpleado)
            );
            if( empleadoEncontrado == null )
            {
                ViewData["errorInicioSesion"] = "Usuario o contraseña incorrecta";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetString("empleadoEnSesion", empleadoEncontrado.NombresEmpleado);
            return Redirect("/Jornadas/Index");
        }

        //// POST: InicioSesion/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: InicioSesion/Edit/5

        // POST: InicioSesion/Edit/5

        // GET: InicioSesion/Delete/5

        // POST: InicioSesion/Delete/5
    }
}
