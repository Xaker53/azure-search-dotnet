using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Interface
{
    public interface IUserGetPermissionsRepository
    {
        public Task<HashSet<Permission>> GetUserPermissions(Guid userId);
    }
}
