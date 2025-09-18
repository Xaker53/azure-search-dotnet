using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Core.Interfaces;
using Core.Models;

namespace Application
{
    public class UserReadService: IUserGetInfoService
    {
        private readonly IRead GetByIntfo;

        public UserReadService(IRead post)
        {
            this.GetByIntfo = post;
        }

        public async Task<User> GetInfoGmail(string Gmail)
        {
            return await GetByIntfo.GetByGmail(Gmail);
        }
    }
}
