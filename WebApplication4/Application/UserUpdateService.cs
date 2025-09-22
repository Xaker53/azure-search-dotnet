using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Interface;
using Core.Interfaces;
using Core.Models;

namespace Application
{
    public class UserUpdateService (IUpdate updateService) : IUpdateService
    {

        public string Json(User UpdatedUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(UserDTO? NewChanges)
        {
            foreach (var prop in typeof(UserDTO).GetProperties())
            {
                if (prop.GetValue(NewChanges) != null && prop.Name != nameof(UserDTO.UserGmail))
                {
                    return updateService.UpdateUser(NewChanges.UserGmail, prop, prop.GetValue(NewChanges).ToString());
                }

            }

            return null;
        }
    }
}
