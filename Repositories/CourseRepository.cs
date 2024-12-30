using Microsoft.EntityFrameworkCore;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Models;
using System.Runtime.InteropServices;

namespace SmartCards.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Course course, int viewPerId, int ediPerId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                var coursePermission = new CoursePermission
                {
                    CourseId = course.Id,
                    ViewPermissionId = viewPerId,
                    EditPermissionId = ediPerId,
                };

                await _context.CoursePermissions.AddAsync(coursePermission);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(x => x.Flashcards).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
