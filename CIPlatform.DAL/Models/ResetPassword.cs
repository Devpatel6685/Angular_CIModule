using System;
using System.Collections.Generic;

namespace CIPlatform.DAL.Models
{
    public partial class ResetPassword
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
