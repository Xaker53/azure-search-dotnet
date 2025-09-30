using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Interactions
{
    public class GetUserIDPermissions: IUserGetPermissionsRepository
    {
        public async Task<HashSet<Permission>> GetUserPermissions (Guid userId)
        {
            using (var _context = new UserdbContext())
            {
                var roles = await _context.users
                    .AsNoTracking()
                    .Include(u => u.Roles)
                    .ThenInclude(r => r.PermissionEntities)
                    .Where(u => u.UserId == userId)
                    .Select(u => u.Roles)
                    .ToArrayAsync();

                return roles
                    .SelectMany(r => r)
                    .SelectMany(r => r.PermissionEntities)
                    .Select(p => (Permission)p.Id)
                    .ToHashSet();
            }
        }
    }
}
