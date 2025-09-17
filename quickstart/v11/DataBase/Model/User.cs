using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    [Index(nameof(UserGmail), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        public string UserName { get; set; }

        //[Required]
        [Required(ErrorMessage = "Incorrect Email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Email")]
        public string UserGmail { get; set; }


        [Required]
        public string Password { get; set; }

        public ICollection<History> histories { get; set; }
    }
}
