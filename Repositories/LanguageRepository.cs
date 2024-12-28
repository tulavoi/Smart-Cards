using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;

        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Language>> GetAllAsync(LanguageQueryObject query)
        {
            var languages = _context.Languages.AsQueryable();
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                languages = query.IsDecsending ? languages.OrderByDescending(x => x.Name)
                    : languages.OrderBy(x => x.Name);
            }
            return await languages.ToListAsync();
        }
    }
}
