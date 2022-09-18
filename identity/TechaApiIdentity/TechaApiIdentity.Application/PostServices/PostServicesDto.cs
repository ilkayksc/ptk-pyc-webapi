using System.ComponentModel.DataAnnotations;
using TechaApiIdentity.Base;

namespace TechaApiIdentity.Application
{

    public class CreatePostDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string UrlName { get; set; }
        [Required]
        public int? CategoryId { get; set; }

    }
    public class PostDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlName { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string PlainContent { get; set; }
    }
    public class UpdatePostDto : CreatePostDto
    {
        public int Id { get; set; }

    }

}
