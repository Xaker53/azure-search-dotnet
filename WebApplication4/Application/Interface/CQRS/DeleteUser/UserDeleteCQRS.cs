using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Interface.CQRS.DeleteUser
{
    public record UserDeleteCQRS (string Gmail) : IRequest<bool>;
}
