using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    public class StoreDto
    {

        [Required]
        [MaxLength(500)]
        [MinLength(5)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Range(minimum: 10, maximum: 68000, ErrorMessage = "Invalid Inventory value. Please provide a number between 10-68000")]
        public int Inventory { get; set; }

    }
}
