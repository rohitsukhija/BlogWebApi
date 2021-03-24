using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogIt.Models
{
    [Table("tags")]
    public class Tags
    {
        public System.Guid id { get; set; }
        public string tagTitle { get; set; }
        public string metaTitle { get; set; }
        public string slug { get; set; }
        public bool isPublished { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public Nullable<System.DateTime> publishedAt { get; set; }
    }
}