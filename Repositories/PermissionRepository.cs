using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Helpers;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetAllAsync(PermissionQueryObject query)
        {
            var permissions = _context.Permissions.AsQueryable();

            if (query.IsEdit.HasValue) // nếu IsEdit có giá trị thì lấy ra các permission có IsEdit = query.IsEdit.Value
                permissions = permissions.Where(x => x.IsEdit == query.IsEdit.Value);
            return await permissions.ToListAsync();
        }
    }
}
