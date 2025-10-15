using System.ComponentModel.DataAnnotations;

namespace NicheHospital.Models
{
    public class EmailLog
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string ToEmail { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public DateTime SentDate { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; } = "No Enviado";

        [StringLength(255)]
        public string Reason { get; set; } = string.Empty;
    }
}