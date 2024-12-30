namespace SmartCards.DTOs.Flashcard
{
    public class FlashcardDTO
    {
        public string Term { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
		public int TermLanguageId { get; set; }
		public int DefiLanguageId { get; set; }
	}
}
