using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Persistence.Models;

namespace Persistence.Interactions
{
    public class UserDelete : IDelete
    {
        private readonly UserdbContext DbContex;
        public UserDelete(UserdbContext dbContext)
        {
            this.DbContex = dbContext;
        }

        public async Task<bool> DeleteUser(User _user)
        {
            //var EmailUser = new UserGetByGmail(DbContex).GetByGmail(email);
            if (_user != null)
            {
                DbContex.users.Remove(_user);
                await DbContex.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
