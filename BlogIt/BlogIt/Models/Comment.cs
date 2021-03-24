using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogIt.Models
{
    [Table("comment")]
    public class Comment
    {
        public System.Guid id { get; set; }
        public System.Guid postId { get; set; }
        public Nullable<System.Guid> parentId { get; set; }
        public string title { get; set; }
        public bool isPublished { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public string content { get; set; }

        public virtual Posts post { get; set; }
    }
}