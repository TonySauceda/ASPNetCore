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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            if (!ModelState.IsValid)
                return View(alumno);

            _context.Alumnos.Add(alumno);
            _context.SaveChanges();

            ViewBag.Mensaje = "Alumno Creado";

            return View("Index", alumno);
        }

        public IActionResult Update(Guid id)
        {
            var alumno = _context.Alumnos
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();
            return View(alumno);
        }

        [HttpPost]
        public IActionResult Update(Alumno alumno, Guid id)
        {
            if (!ModelState.IsValid)
                return View(alumno);

            var alumnoBd = _context.Alumnos
                            .Where(x =>
                                x.Id == id)
                            .FirstOrDefault();

            alumnoBd.Nombre = alumno.Nombre;

            _context.SaveChanges();

            ViewBag.Mensaje = "Alumno Editado";
            
            return View("Index", alumnoBd);
        }
        public IActionResult Delete(Guid id)
        {
            var alumno = _context.Alumnos
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();

            return View(alumno);
        }

        [HttpPost]
        public IActionResult Delete(Alumno alumno, Guid id)
        {
            var alumnoBd = _context.Alumnos
                            .Where(x =>
                                x.Id == id)
                            .FirstOrDefault();

            _context.Alumnos.Remove(alumnoBd);
            _context.SaveChanges();

            return RedirectToAction("", "Alumno");
        }
    }
}