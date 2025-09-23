using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

using MediatR;
using Core.Interfaces;
using Application.CQRS.DeleteUser;

namespace Application.CQRS.Handler
{
    public class UserDeleteHandler (IDelete _userDelete) : IRequestHandler<UserDeleteCQRS, bool>
    {
        async Task<bool> IRequestHandler<UserDeleteCQRS, bool>.Handle(UserDeleteCQRS request, CancellationToken cancellationToken)
        {
            return await _userDelete.DeleteUser(request.Gmail);
        }
    }

}
