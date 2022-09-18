using System.ComponentModel.DataAnnotations.Schema;
using TechaApiIdentity.Base;

namespace TechaApiIdentity.Data
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlName { get; set; }
        public string ImageUrl { get; set; }


        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual int? CategoryId { get; set; }
    }
}
