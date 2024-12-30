using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course, int viewPerId, int editPerId);
        Task<Course?> GetByIdAsync(int id);
    }
}
