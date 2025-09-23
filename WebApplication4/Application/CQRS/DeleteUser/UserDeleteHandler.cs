using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

using MediatR;
using Core.Interfaces;

namespace Application.CQRS.DeleteUser
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCQRS, bool>
    {
        private readonly IDelete _userDelete;

        public UserDeleteHandler (IDelete delete)
        {
            _userDelete = delete;
        }

        async Task<bool> IRequestHandler<UserDeleteCQRS, bool>.Handle(UserDeleteCQRS request, CancellationToken cancellationToken)
        {
            return await _userDelete.DeleteUser(request.Gmail);
        }
    }

}
