using System;
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

        [Route("Asignatura")]
        [Route("Asignatura/{id}")]
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{id}")]
        public IActionResult Index(Guid? id)
        {
            if (id.HasValue)
            {
                var asignatura = _context.Asignaturas
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();
                return View(asignatura);
            }
            return View("ListaAsignaturas", _context.Asignaturas);
        }

        public IActionResult ListaAsignaturas()
        {
            return View(_context.Asignaturas);
        }
    }
}