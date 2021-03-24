using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogIt.Models
{
    [Table("post")]
    public class Posts
    {
        public System.Guid id { get; set; }
        public System.Guid authorId { get; set; }
        public Nullable<System.Guid> parentId { get; set; }
        public string title { get; set; }
        public string metaTitle { get; set; }
        public string slug { get; set; }
        public bool isPublished { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public Nullable<System.DateTime> publishedAt { get; set; }
        public string content { get; set; }
    }
}