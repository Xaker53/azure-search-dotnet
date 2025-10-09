using Application.Interface;
using Application.Interface.Auth;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserUpdateService (IUpdate updateService, IGenerateSaltAndHash GenerateSaltAndHash) : IUpdateService
    {
        private User user;
        public async Task<User> UpdateUser(UserDTO? NewChanges)
        {
            foreach (var prop in typeof(UserDTO).GetProperties())
            {
                if (prop.GetValue(NewChanges) != null && prop.Name != nameof(UserDTO.UserGmail))
                {
                    if (prop.Name == nameof(UserDTO.Password))
                    {
                        GenerateSaltAndHash.Generate(prop.GetValue(NewChanges).ToString());
                        NewChanges.Salt = GenerateSaltAndHash.ReturnSalt;
                        NewChanges.Password = GenerateSaltAndHash.ReturnHash;
                    }
                    user = await updateService.UpdateUser(NewChanges.UserGmail, prop, prop.GetValue(NewChanges).ToString());
                }
            }
            return user;
        }
    }
}
