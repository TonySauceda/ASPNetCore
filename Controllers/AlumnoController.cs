using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new AlumnoModel()
            {
                Nombre = "Programación"
            };
            return View(asignatura);
        }

        public IActionResult ListaAlumnos()
        {
            return View(CargarAlumnos());
        }

        private List<AlumnoModel> CargarAlumnos()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = (from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new AlumnoModel() { Nombre = $"{n1} {n2} {a1}" });

            return listaAlumnos.OrderBy(x => x.Id).ToList();
        }
    }
}