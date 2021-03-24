using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogIt.Models
{
    [Table("post_tag")]
    public class Post_Tag
    {
        public System.Guid id { get; set; }
        public System.Guid postId { get; set; }
        public System.Guid tagId { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }

        public virtual Posts post { get; set; }
        public virtual Tags tag { get; set; }
    }
}