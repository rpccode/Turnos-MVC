using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {

            _context = context;


        }

        public IActionResult Index()
        {
            return View(_context.Especialidad.ToList());
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Especialidad = _context.Especialidad.Find(id);
            if (Especialidad == null)
            {
                return NotFound();
            }
            return View(Especialidad);
        }

    }
}