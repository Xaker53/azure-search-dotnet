using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Interfaces;
using Persistence.Models;

namespace Persistence.Interactions
{
    public class UserCreate : ICreate
    {
        public async Task Add(User user)
        {
            using (var dbContext = new UserdbContext())
            {
                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
