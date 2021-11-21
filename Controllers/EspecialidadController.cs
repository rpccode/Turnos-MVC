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

        [HttpPost]
        public IActionResult Edit(int id, [Bind("IdEspecialidad,Descripccion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
        public IActionResult Delect(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Especialidad = _context.Especialidad.FirstOrDefault(e => e.IdEspecialidad == id);
            if (Especialidad == null)
            {
                return NotFound();
            }
            return View(Especialidad);
        }

        [HttpPost]
        public IActionResult Delect(int id)
        {
            var especialidad = _context.Especialidad.Find(id);
            _context.Remove(especialidad);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }



    }
}