using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Interfaces;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Core.Enums;

namespace Persistence.Interactions
{
    public class UserCreate : ICreate
    {
        private readonly UserdbContext dbContext;
        public UserCreate(UserdbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Add(User user)
        {
            var role = await dbContext.Roles.SingleOrDefaultAsync(r => r.Id == (int)Role.User) ?? throw new InvalidOperationException();
            user.Roles = [role];

            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
