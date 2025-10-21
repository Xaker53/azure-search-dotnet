using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Interfaces;
using Core.Models;
using Persistence.Models;

namespace Persistence.Interactions
{
    public class UserUpdate : IUpdate
    {

        private readonly UserdbContext DbContext;
        private readonly IMapper _mapper;
        public UserUpdate(UserdbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<User> UpdateUser(string email, UserDTO newChanges)
        {

            var emailUser = await new UserGetByGmail(DbContext).GetByGmail(email);

            if (emailUser != null)
            {
                _mapper.Map(newChanges, emailUser);
                //foreach (var propDto in typeof(UserDTO).GetProperties())
                //{
                //    var valueDto = propDto.GetValue(newChanges);
                //    if (valueDto != null)
                //    {
                //        var propUser = typeof(User).GetProperty(propDto.Name);
                //        if (propUser != null)
                //        {
                //            propUser.SetValue(emailUser, valueDto);
                //        }
                //        else if (propDto.Name == nameof(UserDTO.OtherEmail))
                //        {
                //            var targetProp = typeof(User).GetProperty(nameof(User.UserGmail));
                //            if (targetProp !=null)
                //            {
                //                targetProp.SetValue(emailUser, valueDto);
                //            }
                //        }
                //    }
                //}
                //DbContext.Update(emailUser);
                await DbContext.SaveChangesAsync();
            }
            return emailUser;

        }
    }
}
