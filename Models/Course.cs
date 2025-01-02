using SmartCards.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
        public List<CourseFolder> CourseFolders { get; set; } = new List<CourseFolder>();
    }
}
