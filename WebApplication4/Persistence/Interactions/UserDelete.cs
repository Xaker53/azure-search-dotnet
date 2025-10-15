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

        public async Task<bool> DeleteUser(string email)
        {
            var EmailUser = new UserGetByGmail(DbContex).GetByGmail(email);
            if (EmailUser.Result != null)
            {
                DbContex.users.Remove(EmailUser.Result);
                await DbContex.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
