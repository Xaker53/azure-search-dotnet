using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Incorrect Email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Email")]
        public string UserGmail { get; set; }

        [Required]
        public string Password { get; set; }

    }
}

