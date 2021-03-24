using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogIt.Models
{
    [Table("blog_user")]
    public class Users
    {
        public System.Guid id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string mobileNumber { get; set; }
        public string emailId { get; set; }
        public string passwordHash { get; set; }
        public System.DateTime registeredAt { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public string profileSummary { get; set; }
    }
}