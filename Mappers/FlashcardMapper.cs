using SmartCards.DTOs.Flashcard;
using SmartCards.Models;

namespace SmartCards.Mappers
{
    public static class FlashcardMapper
    {
        public static FlashcardDTO ToFlashcardDTO(this Flashcard flashcard)
        {
            return new FlashcardDTO
            {
                Id = flashcard.Id,
                Term = flashcard.Term,
                TermLanguageId = flashcard.Term_LangId,
                Definition = flashcard.Definition,
                DefiLanguageId = flashcard.Definition_LangId
            };
        }
    }
}
