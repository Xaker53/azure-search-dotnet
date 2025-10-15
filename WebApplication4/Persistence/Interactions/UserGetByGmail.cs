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
    public class UserGetByGmail : IRead
    {
        private readonly UserdbContext dbContext;
        public UserGetByGmail(UserdbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetByGmail(string email)
        {
            var userEmail = dbContext.users.FirstOrDefault(x => x.UserGmail == email);
            return userEmail;
        }
    }
}
