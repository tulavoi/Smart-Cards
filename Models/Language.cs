using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("Languages")]
    public class Language
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}
