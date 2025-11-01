using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface;
using Core.Interfaces;
using MediatR;
using MediatR.Pipeline;

namespace Application.CQRS.UserDeleteIndex
{
    public class UserDeleteIndexHandler : IRequestHandler<UserDeleteIndexCQRS, bool>
    {
        private readonly IRead _userRead;
        private readonly IConnectAzure _connectAzure;
        public UserDeleteIndexHandler(IRead read, IConnectAzure connectAzure)
        {
            _userRead = read;
            _connectAzure = connectAzure;
        }
        public async Task<bool> Handle(UserDeleteIndexCQRS request, CancellationToken cancellationToken)
        {
            var result = await _userRead.GetByGmail(request.UserGmail);
            if (result != null)
            {
                await _connectAzure.DeleteAllByUserIdAsync(result.UserId.ToString());
                return true;
            }
            return false;
        }
    }
}
