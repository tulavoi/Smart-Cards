using Microsoft.Identity.Client;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Models;

namespace SmartCards.Repositories
{
    public class CoursePermissionRepository : ICoursePermissionRepository
    {
        private readonly AppDbContext _context;

        public CoursePermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CoursePermission coursePermission)
        {
            if (coursePermission == null) return;
            await _context.CoursePermissions.AddAsync(coursePermission);
            await _context.SaveChangesAsync();
        }
    }
}
