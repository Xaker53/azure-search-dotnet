using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.MappingProfiles
{
    [Index(nameof(Gmail), IsUnique = true)]
    public class UserRequest
    {
        
        public string? Name { get; set; } = null;

        [Required(ErrorMessage = "Incorrect Email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Email")]
        public string? Gmail { get; set; } = null;

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Email")]
        public string? OtherGmail { get; set; } = null;

        public string? Password { get; set; } = null;

        public string? IndexName { get; set; } = null;

        public string? ApiKey { get; set; } = null;

        //public ICollection<History>? histories { get; set; } = new List<History>();
    }
}
