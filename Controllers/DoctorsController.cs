using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NicheHospital.Data;
using NicheHospital.Models;

namespace NicheHospital.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HospitalContext _context;

        public DoctorsController(HospitalContext context)
        {
            _context = context;
        }

        // 🔹 GET: Doctors (con filtro por especialidad)
        public async Task<IActionResult> Index(string? specialty)
        {
            // Obtener todas las especialidades disponibles en la base de datos
            var specialties = await _context.Doctors
                .Select(d => d.Specialty)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();

            ViewBag.Specialties = specialties;

            // Filtrar médicos según la especialidad seleccionada
            var doctors = from d in _context.Doctors select d;

            if (!string.IsNullOrEmpty(specialty) && specialty != "Todas")
            {
                doctors = doctors.Where(d => d.Specialty == specialty);
            }

            ViewData["CurrentFilter"] = specialty;
            return View(await doctors.ToListAsync());
        }

        // 🔹 GET: Doctors/Create
        public IActionResult Create()
        {
            ViewBag.Specialties = GetSpecialties();
            return View();
        }

        // 🔹 POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            ViewBag.Specialties = GetSpecialties();

            if (await _context.Doctors.AnyAsync(d => d.Document == doctor.Document))
                ModelState.AddModelError("Document", "Ya existe un médico con este documento.");

            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Médico registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(doctor);
        }

        // 🔹 GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return NotFound();

            ViewBag.Specialties = GetSpecialties();
            return View(doctor);
        }

        // 🔹 POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            if (id != doctor.Id) return NotFound();

            ViewBag.Specialties = GetSpecialties();

            if (await _context.Doctors.AnyAsync(d => d.Document == doctor.Document && d.Id != id))
                ModelState.AddModelError("Document", "Otro médico ya usa este documento.");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Médico actualizado correctamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Doctors.Any(d => d.Id == doctor.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            return View(doctor);
        }

        // 🔹 GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // 🔹 POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Médico eliminado correctamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        // 🔹 Método auxiliar: lista de especialidades para el combo de Create/Edit
        private List<string> GetSpecialties()
        {
            return new List<string>
            {
                "Medicina General",
                "Pediatría",
                "Cardiología",
                "Dermatología",
                "Neurología",
                "Traumatología",
                "Ginecología",
                "Oftalmología",
                "Psiquiatría",
                "Urología"
            };
        }
    }
}
