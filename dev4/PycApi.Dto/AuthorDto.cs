using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    public class AuthorDto    
    {

        [Required]
        [MaxLength(500)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

    }
}
