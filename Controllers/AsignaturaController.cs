using System.Collections.Generic;
using System.Linq;
using ASPNetCore.DbEntities;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class AsignaturaController : BaseController
    {
        public AsignaturaController(EscuelaContext context) : base(context) { }

        public IActionResult Index()
        {
            var asignatura = _context.Asignaturas.FirstOrDefault();
            return View(asignatura);
        }

        public IActionResult ListaAsignaturas()
        {
            return View(_context.Asignaturas);
        }
    }
}