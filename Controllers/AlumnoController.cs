using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCore.DbEntities;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class AlumnoController : BaseController
    {
        public AlumnoController(EscuelaContext context) : base(context) { }

        [Route("Alumno")]
        [Route("Alumno/{id}")]
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
        public IActionResult Index(Guid? id)
        {
            if (id.HasValue)
            {
                var alumno = _context.Alumnos
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();

                return View(alumno);
            }
            return View("ListaAlumnos", _context.Alumnos);
        }

        public IActionResult ListaAlumnos()
        {
            return View(_context.Alumnos);
        }
    }
}