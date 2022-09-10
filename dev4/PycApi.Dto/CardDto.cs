using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    public class CardDto
    {
        public virtual int AccountId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Card Holder Name")]
        public virtual string CardHolderName { get; set; }

        [Required]
        public virtual int CardLimit { get; set; }
    }
}
