using System.Linq;
using ASPNetCore.DbEntities;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class EscuelaController : BaseController
    {
        public EscuelaController(EscuelaContext context) : base(context) { }

        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La Monja";

            var escuela = _context.Escuelas.FirstOrDefault();

            return View(escuela);
        }
    }
}