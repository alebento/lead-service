using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadsService.Domain.Entities
{
    [Table("Leads")]
    public class DbLead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ContactFirstName { get; set; } // 🔹 Agora pode ser nulo

        [Required]
        [MaxLength(200)]
        public string? ContactFullName { get; set; }

        [Required]
        [MaxLength(15)]
        public string? ContactPhone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string? ContactEmail { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [MaxLength(100)]
        public string? Suburb { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Status { get; set; } // 🔹 Agora pode ser nulo
    }
}
