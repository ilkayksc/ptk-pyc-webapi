using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechaApiIdentity.Base
{   
    public class EntityDto<T> : CommonEntityDto
    {
        public T Id { get; set; }
    }
    public class EntityDto : CommonEntityDto
    {
        public int Id { get; set; }
    }

    public class CommonEntityDto
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedById { get; set; }
    }
}
