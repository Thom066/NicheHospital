using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NicheHospital.Data;
using NicheHospital.Models;

namespace NicheHospital.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HospitalContext _context;

        public AppointmentsController(HospitalContext context)
        {
            _context = context;
        }

        // 🔹 Listar todas las citas
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();

            return View(appointments);
        }

        // 🔹 GET: Agendar nueva cita
        public IActionResult Create()
        {
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name");
            return View();
        }

        // 🔹 POST: Guardar nueva cita
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name", appointment.PatientId);
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name", appointment.DoctorId);

            // Validar duplicados
            bool doctorBusy = await _context.Appointments.AnyAsync(a =>
                a.DoctorId == appointment.DoctorId &&
                a.Date == appointment.Date &&
                a.Status != "Cancelada");

            bool patientBusy = await _context.Appointments.AnyAsync(a =>
                a.PatientId == appointment.PatientId &&
                a.Date == appointment.Date &&
                a.Status != "Cancelada");

            if (doctorBusy)
                ModelState.AddModelError("", "El médico ya tiene una cita en ese horario.");

            if (patientBusy)
                ModelState.AddModelError("", "El paciente ya tiene una cita en ese horario.");

            if (ModelState.IsValid)
            {
                appointment.Status = "Pendiente";
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Cita agendada correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(appointment);
        }

        // 🔹 Cambiar estado a Cancelada
        public async Task<IActionResult> Cancel(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            appointment.Status = "Cancelada";
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Cita cancelada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // 🔹 Cambiar estado a Atendida
        public async Task<IActionResult> Attend(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            appointment.Status = "Atendida";
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Cita marcada como atendida.";
            return RedirectToAction(nameof(Index));
        }
    }
}
