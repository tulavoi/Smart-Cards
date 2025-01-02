using api.Helpers;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SmartCards.Areas.Identity.Data;
using SmartCards.Interfaces;
using SmartCards.Models;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace SmartCards.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        private readonly ICoursePermissionRepository _coursePerRepo;

        public CourseRepository(AppDbContext context, ICoursePermissionRepository coursePerRepo)
        {
            _context = context;
            _coursePerRepo = coursePerRepo;
        }

        public async Task CreateAsync(Course course, int viewPerId, int ediPerId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                course.Slug = this.GenerateSlug(course.Title, course.CreatedAt);
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                var coursePermission = new CoursePermission
                {
                    CourseId = course.Id,
                    ViewPermissionId = viewPerId,
                    EditPermissionId = ediPerId,
                };

                await _coursePerRepo.CreateAsync(coursePermission); // Tạo course permission

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private string GenerateSlug(string title, DateTime createdAt)
        {
            // Bỏ dấu tiếng Việt
            var noDiacritics = RemoveDiacritics(title);

            // Chuyển thành slug
            var slug = string.Join("-", noDiacritics.ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            // Xóa các dấu '-' dư thừa
            slug = System.Text.RegularExpressions.Regex.Replace(slug, "-{2,}", "-").Trim('-');

            var createdAtString = createdAt.ToString("yyyyMMddhhmmssfff");

            return $"{slug}-{createdAtString}";
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        public async Task<List<Course>> GetAllAsync(CourseQueryObject query)
        {
            var courses = _context.Courses
                .Include(x => x.User)
                .Include(x => x.Flashcards).AsQueryable();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                courses = query.IsDecsending ? courses.OrderByDescending(x => x.CreatedAt)
                    : courses.OrderBy(x => x.CreatedAt);
            }

            if (query.MaxItem > 0)
                courses = courses.Take(query.MaxItem);

            return await courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(x => x.Flashcards).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
