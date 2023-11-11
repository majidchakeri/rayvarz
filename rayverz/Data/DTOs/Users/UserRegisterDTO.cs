using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Maharat.Data.DTOs.Users
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required] public string Password { get; set; } = string.Empty;

    }
}
