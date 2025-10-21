using Application.Interface;
using Application.Interface.Auth;
using Application.Services.GeneratePasswordSalt;
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
    public class UserUpdateService (IUpdate updateService, IGenerateSaltAndHash _PasswordAndSalt, IUserDtoValidator dtoValidator) : IUpdateService
    {
        private User user;
        public async Task<User> UpdateUser(UserDTO? NewChanges)
        {
            if (dtoValidator.HasOtherFieldsFilled(NewChanges))
            {
                foreach (var prop in typeof(UserDTO).GetProperties())
                {
                    if (prop.GetValue(NewChanges) != null && prop.Name != nameof(UserDTO.UserGmail))
                    {
                        if (prop.Name == nameof(UserDTO.Password))
                        {
                            _PasswordAndSalt.Generate(NewChanges.Password);
                            NewChanges.Salt = _PasswordAndSalt.ReturnSalt;
                            NewChanges.Password = _PasswordAndSalt.ReturnHash;
                        }
                        //user = await updateService.UpdateUser(NewChanges.UserGmail, prop, prop.GetValue(NewChanges).ToString());
                    }
                }
                user = await updateService.UpdateUser(NewChanges.UserGmail, NewChanges);
            }
            return user;
        }
    }
}
