using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new EscuelaModel("Platzi Academy", 2014);

            ViewBag.CosaDinamica = "La Monja";

            return View(escuela);
        }
    }
}