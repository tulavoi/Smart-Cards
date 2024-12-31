using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface ICoursePermissionRepository
    {
        Task CreateAsync(CoursePermission coursePermission);
    }
}
