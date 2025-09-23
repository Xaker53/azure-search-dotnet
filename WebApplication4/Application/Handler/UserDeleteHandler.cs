using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Application.Interface.CQRS.DeleteUser;

using MediatR;
using Core.Interfaces;

namespace Application.Handler
{
    public class UserDeleteHandler (IDelete _userDelete) : IRequestHandler<UserDeleteCQRS, bool>
    {
        async Task<bool> IRequestHandler<UserDeleteCQRS, bool>.Handle(UserDeleteCQRS request, CancellationToken cancellationToken)
        {
            return await _userDelete.DeleteUser(request.Gmail);
        }
    }

}
