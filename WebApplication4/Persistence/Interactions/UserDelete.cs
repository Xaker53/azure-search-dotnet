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
        public async Task<bool> DeleteUser(string email)
        {
            var EmailUser = new UserGetByGmail().GetByGmail(email);
            if (EmailUser.Result != null)
            {
                using (var DbContex = new UserdbContext())
                {
                    DbContex.users.Remove(EmailUser.Result);
                    await DbContex.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
