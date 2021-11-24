using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Especialidad = await _context.Especialidad.FindAsync(id);
            if (Especialidad == null)
            {
                return NotFound();
            }
            return View(Especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,Descripccion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
        public async Task<IActionResult> Delect(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Especialidad = await _context.Especialidad.FirstOrDefaultAsync(e => e.IdEspecialidad == id);
            if (Especialidad == null)
            {
                return NotFound();
            }
            return View(Especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delect(int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Remove(especialidad);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }


        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,Descripccion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }



    }
}