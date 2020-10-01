using System.Collections.Generic;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new AsignaturaModel()
            {
                Nombre = "Programación"
            };
            return View(asignatura);
        }

        public IActionResult ListaAsignaturas()
        {
            var lsAsignaturas = new List<AsignaturaModel>()
                {
                    new AsignaturaModel(){ Nombre = "Matemáticas" },
                    new AsignaturaModel(){ Nombre = "Educación Física" },
                    new AsignaturaModel(){ Nombre = "Español" },
                    new AsignaturaModel(){ Nombre = "Ciencias Naturales" },
                    new AsignaturaModel(){ Nombre = "Programación Básica" },
                };
            return View(lsAsignaturas);
        }
    }
}