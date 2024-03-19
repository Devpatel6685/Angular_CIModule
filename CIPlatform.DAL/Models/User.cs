using System;
using System.Collections.Generic;

namespace CIPlatform.DAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long Phonenumber { get; set; }
        public string? Avatar { get; set; }
        public string? Whyivolunteer { get; set; }
        public string? Employeeid { get; set; }
        public string? Department { get; set; }
        public int? Cityid { get; set; }
        public int? Countryid { get; set; }
        public string? Profiletext { get; set; }
        public string? Linkedinurl { get; set; }
        public string? Title { get; set; }
        public int? Status { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public DateTime? Deletedate { get; set; }
        public string? Role { get; set; }
    }
}
