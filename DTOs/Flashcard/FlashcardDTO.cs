using System.ComponentModel.DataAnnotations;

namespace SmartCards.DTOs.Flashcard
{
    public class FlashcardDTO
    {
		public int Id { get; set; }
        public string? Term { get; set; } = string.Empty;
        public string? Definition { get; set; } = string.Empty;
        [Required]
		public int TermLanguageId { get; set; }
        [Required]
		public int DefiLanguageId { get; set; }
    }
}
