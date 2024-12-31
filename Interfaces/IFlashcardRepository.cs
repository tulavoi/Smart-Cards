using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IFlashcardRepository
    {
        Task CreateListAsync(List<Flashcard> flashcards);
    }
}
