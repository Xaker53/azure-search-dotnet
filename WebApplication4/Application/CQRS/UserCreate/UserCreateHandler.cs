using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Services;
using Core.Interfaces;
using Core.Models;
using MediatR;

namespace Application.CQRS.UserCreate
{
    public class UserCreateHandler : IRequestHandler<UserCreateCQRS>
    {
        private readonly ICreate _create;
        private readonly IUserService _UserService;
        private readonly ISalt _Salt;

        public UserCreateHandler(ICreate create, IUserService userService, ISalt Salt)
        {
            _create = create;
            _UserService = userService;
            _Salt = Salt;
        }

        async Task IRequestHandler<UserCreateCQRS>.Handle(UserCreateCQRS request, CancellationToken cancellationToken)
        {
            request.user.Salt = _Salt.GetSalt();
            request.user.Password = await _UserService.Register(request.user.UserGmail, request.user.Password, request.user.Salt);
            await _create.Add(request.user);
        }
    }
}
