using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.DeleteUser
{
    public record UserDeleteCQRS (string Gmail) : IRequest<bool>;
}
