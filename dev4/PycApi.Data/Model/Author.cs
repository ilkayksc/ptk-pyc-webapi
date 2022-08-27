using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PycApi.Data
{
    public class Author 
    {
        public virtual string Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
