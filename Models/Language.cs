using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("Languages")]
    public class Language
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Code { get; set; } = string.Empty;
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}
