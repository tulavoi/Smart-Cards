using api.Helpers;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SmartCards.Areas.Identity.Data;
using SmartCards.DTOs.Course;
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
            return await _context.Courses
                .Include(x => x.User)
                .Include(x => x.Flashcards)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public string GetErrorMessage(CreateCourseRequestDTO courseDTO)
        {
            List<string> messages = new List<string>();
            if (string.IsNullOrEmpty(courseDTO.Title)) // Nếu không có tiêu đề học phần
                messages.Add("nhập tiêu đề ");

            if (courseDTO.Flashcards.Count < 3) // Nếu ít hơn 3 flashcard
                messages.Add("nhiều hơn hai thẻ ");

            if (courseDTO.Flashcards[0].TermLanguageId == 0 || courseDTO.Flashcards[0].DefiLanguageId == 0) // Nếu chưa chọn term or definition language
                messages.Add("một ngôn ngữ cho thuật ngữ và một ngôn ngữ cho định nghĩa ");

            // Nếu như messages không có phần tử nào thì combinedMessage là chuỗi rỗng
            string combinedMessage = messages.Count != 0 ? $"bạn cần {string.Join(", ", messages)} để tạo 1 học phần." : "";

            return combinedMessage;
        }
    }
}
