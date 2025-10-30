using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

using MediatR;
using Core.Interfaces;
using Core.Interface;

namespace Application.CQRS.DeleteUser
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCQRS, bool>
    {
        private readonly IDelete _userDelete;
        private readonly IRead _userRead;
        private readonly IConnectAzure _connectAzure;

        public UserDeleteHandler (IDelete delete, IRead read, IConnectAzure connect)
        {
            _userDelete = delete;
            _userRead = read;
            _connectAzure = connect;
        }

        async Task<bool> IRequestHandler<UserDeleteCQRS, bool>.Handle(UserDeleteCQRS request, CancellationToken cancellationToken)
        {
            var result = await _userRead.GetByGmail(request.Gmail);
            if (result != null)
            {
                await _connectAzure.DeleteAllByUserIdAsync(result.UserId.ToString());
                return await _userDelete.DeleteUser(result);
            }
            return false;
            //return await _userDelete.DeleteUser(request.Gmail);
        }
    }

}
