using System.ComponentModel.DataAnnotations;

namespace TechaApiIdentity
{
    public class LoginModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "{0} field max {1}, at least {2} chars", MinimumLength = 6)]
        public string Username { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "{0} field max {1}, at least {2} chars", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
