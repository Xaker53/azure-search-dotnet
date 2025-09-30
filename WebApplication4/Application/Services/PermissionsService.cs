using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Core.Enums;
using Core.Interface;

namespace Application.Services.Interface
{
    public class PermissionsService : IPermissionService
    {
        private readonly IUserGetPermissionsRepository _userGet;

        public PermissionsService (IUserGetPermissionsRepository userGet)
        {
            _userGet = userGet;
        }

        public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
        {
            return _userGet.GetUserPermissions(userId);
        }
    }
}
