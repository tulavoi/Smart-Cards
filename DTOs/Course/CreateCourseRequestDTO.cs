using SmartCards.DTOs.Flashcard;
using System.ComponentModel.DataAnnotations;

namespace SmartCards.DTOs.Course
{
    public class CreateCourseRequestDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
		public int ViewPermissionId { get; set; }
		public int EditPermissionId { get; set; }
        public List<FlashcardDTO> Flashcards { get; set; } = new List<FlashcardDTO>();
    }
}
