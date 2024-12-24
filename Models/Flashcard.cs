using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("Flashcards")]
    public class Flashcard
    {
        public int Id { get; set; }
        public string ImageFileName { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
        public bool IsMark { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int Term_LangId { get; set; }
        public Language? Term_Lang { get; set; }
        public int Definition_LangId { get; set; }
        public Language? Definition_Lang { get; set; }
    }
}
