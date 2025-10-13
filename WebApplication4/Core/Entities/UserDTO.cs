using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Models
{
    [Index(nameof(UserGmail), IsUnique = true)]
    public class UserDTO
    {

        public string? UserName { get; set; }

        //[Required]
        [Required(ErrorMessage = "Incorrect Email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Email")]
        public string? UserGmail { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Email")]
        public string? OtherEmail { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }

        //public ICollection<History>? histories { get; set; } = new List<History>();
    }
}
