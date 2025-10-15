using Microsoft.EntityFrameworkCore;
using NicheHospital.Models;

namespace NicheHospital.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        // 🔹 Tablas del sistema
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }

        // 🔹 Configuraciones adicionales (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evita duplicados en documentos de pacientes y médicos
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Document)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.Document)
                .IsUnique();

            // Relación: 1 Paciente - muchas Citas
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: 1 Médico - muchas Citas
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}