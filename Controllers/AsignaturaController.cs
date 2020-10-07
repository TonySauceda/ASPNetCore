using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCore.DbEntities;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Create()
        {
            ViewBag.Cursos = _context.Cursos.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            if (!ModelState.IsValid)
                return View(asignatura);

            _context.Asignaturas.Add(asignatura);
            _context.SaveChanges();

            ViewBag.Mensaje = "Asignatura Creada";

            return View("Index", asignatura);
        }

        public IActionResult Update(Guid id)
        {
            ViewBag.Cursos = _context.Cursos.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            });

            var asignatura = _context.Asignaturas
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();
            return View(asignatura);
        }

        [HttpPost]
        public IActionResult Update(Asignatura asignatura, Guid id)
        {
            if (!ModelState.IsValid)
                return View(asignatura);

            var asignaturaBd = _context.Asignaturas
                            .Where(x =>
                                x.Id == id)
                            .FirstOrDefault();

            asignaturaBd.Nombre = asignatura.Nombre;
            asignaturaBd.CursoId = asignatura.CursoId;

            _context.SaveChanges();

            ViewBag.Mensaje = "Asignatura Editada";

            return View("Index", asignaturaBd);
        }
        public IActionResult Delete(Guid id)
        {
            var asignatura = _context.Asignaturas
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();

            return View(asignatura);
        }

        [HttpPost]
        public IActionResult Delete(Asignatura asignatura, Guid id)
        {
            var asignaturaBd = _context.Asignaturas
                            .Where(x =>
                                x.Id == id)
                            .FirstOrDefault();

            _context.Asignaturas.Remove(asignaturaBd);
            _context.SaveChanges();

            return RedirectToAction("", "Asignatura");
        }
    }
}