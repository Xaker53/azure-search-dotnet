using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class UserAddService: IUserAddService
    {
        private readonly ICreate create;

        public UserAddService(ICreate create)
        {
            this.create = create;
        }

        public async Task Add(User user)
        {
            await create.Add(user);
        }
    }
}
