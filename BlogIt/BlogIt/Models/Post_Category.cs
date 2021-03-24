using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogIt.Models
{
    [Table("post_category")]
    public class Post_Category
    {
        public System.Guid id { get; set; }
        public System.Guid postId { get; set; }
        public System.Guid categoryId { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }

        public virtual Category category { get; set; }
        public virtual Posts post { get; set; }
    }
}