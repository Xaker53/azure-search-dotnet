using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserGmail { get; set; }


        [Required]
        public string Password { get; set; }

        public ICollection<History> histories { get; set; }
    }
}
