using System.ComponentModel.DataAnnotations;

namespace NicheHospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Document { get; set; } = string.Empty;

        [Range(0, 120)]
        public int Age { get; set; }

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}