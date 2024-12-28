using SmartCards.Helpers;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllAsync(LanguageQueryObject query);
    }
}
