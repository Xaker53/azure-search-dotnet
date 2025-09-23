using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using MediatR;

namespace Application.CQRS.UserCreate
{
    public class UserCreateHandler : IRequestHandler<UserCreateCQRS>
    {
        private readonly ICreate _create;

        public UserCreateHandler(ICreate create)
        {
            _create = create;
        }

        async Task IRequestHandler<UserCreateCQRS>.Handle(UserCreateCQRS request, CancellationToken cancellationToken)
        {
            await _create.Add(request.user);
        }
    }
}
