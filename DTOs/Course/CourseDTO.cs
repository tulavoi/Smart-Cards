using SmartCards.Areas.Identity.Data;
using SmartCards.DTOs.Flashcard;

namespace SmartCards.DTOs.Course
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Slug { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public List<FlashcardDTO> Flashcards { get; set; } = new List<FlashcardDTO>();
    }
}
