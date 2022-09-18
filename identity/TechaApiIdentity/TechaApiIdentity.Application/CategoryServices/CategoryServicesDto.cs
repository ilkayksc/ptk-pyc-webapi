using System.ComponentModel.DataAnnotations;
using TechaApiIdentity.Base;

namespace TechaApiIdentity.Application
{
    public class CategoryDto : EntityDto
    {
        public string Name { get; set; }
        public string UrlName { get; set; }
    }
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlName { get; set; }

    }
    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
    }

}
