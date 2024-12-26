using SmartCards.Helpers;
using SmartCards.Models;

namespace SmartCards.Interfaces
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllAsync(PermissionQueryObject query);
    }
}
