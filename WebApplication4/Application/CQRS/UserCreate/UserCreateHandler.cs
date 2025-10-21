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
        private readonly IGenerateSaltAndHash _generateSaltAndHash;

        public UserCreateHandler(ICreate create, IUserService userService, IGenerateSaltAndHash generateSaltAndHash)
        {
            _create = create;
            _generateSaltAndHash= generateSaltAndHash;
        }

        async Task IRequestHandler<UserCreateCQRS>.Handle(UserCreateCQRS request, CancellationToken cancellationToken)
        {
            _generateSaltAndHash.Generate(request.user.Password);
            request.user.Salt = _generateSaltAndHash.ReturnSalt;
            request.user.Password = _generateSaltAndHash.ReturnHash;
            await _create.Add(request.user);
        }
    }
}
