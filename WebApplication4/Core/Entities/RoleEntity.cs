using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Entities
{
    public class RoleEntity
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<PermissionEntity> PermissionEntities { get; set; } = [];

        public ICollection<User> Users { get; set; } = [];
    }
}
