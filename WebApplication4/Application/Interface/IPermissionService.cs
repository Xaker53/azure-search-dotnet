using Core.Enums;

namespace Application.Interface
{
    public interface IPermissionService
    {
        public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}