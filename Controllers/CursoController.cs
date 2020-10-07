using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCore.DbEntities;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class CursoController : BaseController
    {
        public CursoController(EscuelaContext context) : base(context) { }

        [Route("Curso")]
        [Route("Curso/{id}")]
        [Route("Curso/Index")]
        [Route("Curso/Index/{id}")]
        public IActionResult Index(Guid? id)
        {
            if (id.HasValue)
            {
                var curso = _context.Cursos
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();

                return View(curso);
            }
            return View("ListaCursos", _context.Cursos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            if (!ModelState.IsValid)
                return View(curso);

            var escuela = _context.Escuelas.FirstOrDefault();
            curso.EscuelaId = escuela.Id;
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            ViewBag.Mensaje = "Curso Creado";
            return View("Index", curso);
        }
        public IActionResult Update(Guid id)
        {
            var curso = _context.Cursos
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();
            return View(curso);
        }

        [HttpPost]
        public IActionResult Update(Curso curso, Guid id)
        {
            if (!ModelState.IsValid)
                return View(curso);

            var cursoBd = _context.Cursos
                            .Where(x =>
                                x.Id == id)
                            .FirstOrDefault();
                            
            cursoBd.Nombre = curso.Nombre;
            cursoBd.Dirección = curso.Dirección;
            cursoBd.TipoCurso = curso.TipoCurso;

            _context.SaveChanges();
            ViewBag.Mensaje = "Curso Editado";
            return View("Index", cursoBd);
        }
        public IActionResult Delete(Guid id)
        {
            var curso = _context.Cursos
                .Where(x =>
                    x.Id == id)
                .FirstOrDefault();
            return View(curso);
        }

        [HttpPost]
        public IActionResult Delete(Curso curso, Guid id)
        {
            var cursoBd = _context.Cursos
                            .Where(x =>
                                x.Id == id)
                            .FirstOrDefault();
            _context.Cursos.Remove(cursoBd);
            _context.SaveChanges();

            return RedirectToAction("", "Curso");
        }
    }
}