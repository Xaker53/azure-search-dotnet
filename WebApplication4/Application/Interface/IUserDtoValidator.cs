using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Application.Interface
{
    public interface IUserDtoValidator
    {
        public bool HasOtherFieldsFilled(UserDTO Dto);
    }
}
