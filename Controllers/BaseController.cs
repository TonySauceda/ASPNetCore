using ASPNetCore.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.Controllers
{
    public class BaseController : Controller
    {
        public readonly EscuelaContext _context;
        public BaseController(EscuelaContext context)
        {
            _context = context;
        }
    }
}