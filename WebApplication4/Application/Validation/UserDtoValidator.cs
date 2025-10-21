using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Core.Models;

namespace Application.Validation
{
    public class UserDtoValidator : IUserDtoValidator
    {

        public bool HasOtherFieldsFilled (UserDTO Dto)
        {
            if (Dto == null || string.IsNullOrEmpty(Dto.UserGmail)) return false;

            var hasOther = typeof(UserDTO)
                .GetProperties()
                .Where(p => p.Name != nameof(UserDTO.UserGmail))
                .Any(p => p.GetValue(Dto) != null);
            return hasOther;
        }
    }
}
