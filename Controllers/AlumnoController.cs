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

        public IActionResult Index()
        {
            var alumno = _context.Alumnos.FirstOrDefault();

            return View(alumno);
        }

        public IActionResult ListaAlumnos()
        {
            return View(_context.Alumnos);
        }
    }
}