using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Core.Models;
using Persistence.Models;

namespace Persistence.Interactions
{
    public class UserUpdate : IUpdate
    {
        public async Task<User> UpdateUser(string email, PropertyInfo NewChanges, string NewSomething)
        {
            using (var DbContext = new UserdbContext())
            {
                var emailUser = new UserGetByGmail().GetByGmail(email);

                if (emailUser.Result != null)
                {
                    foreach (var Change in typeof(User).GetProperties())
                    {
                        if (Change.Name == NewChanges.Name || NewChanges.Name == nameof(UserDTO.OtherEmail) && Change.Name == nameof(User.UserGmail))
                        {
                            Change.SetValue(emailUser.Result, NewSomething);
                            break;
                        }
                    }
                    DbContext.Update(emailUser.Result);
                    await DbContext.SaveChangesAsync();
                }
                return emailUser.Result;
            }
        }
    }
}
