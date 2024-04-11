using System;
using System.Collections.Generic;

namespace CIPlatform.DAL.Models
{
    public partial class Comment
    {
        public long CommentId { get; set; }
        public int? UserId { get; set; }
        public long? MissionId { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? CommentMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission? Mission { get; set; }
        public virtual User? User { get; set; }
    }
}
