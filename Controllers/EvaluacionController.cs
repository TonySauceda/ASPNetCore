using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCore.DbEntities;
using ASPNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class EvaluacionController : BaseController
    {
        public EvaluacionController(EscuelaContext context) : base(context) { }

        public IActionResult Index()
        {
            return View(_context.Evaluaciones);
        }
    }
}