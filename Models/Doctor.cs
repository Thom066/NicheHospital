using System.ComponentModel.DataAnnotations;

namespace NicheHospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento es obligatorio")]
        [StringLength(20)]
        public string Document { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(50)]
        public string Specialty { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Número de teléfono inválido")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string? Email { get; set; }
    }
}