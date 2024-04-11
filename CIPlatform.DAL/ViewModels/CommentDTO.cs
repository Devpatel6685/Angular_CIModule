using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class CommentDTO
    {
        public long MissionId { get; set; }
        public int UserId { get; set; }

        public string? ApprovalStatus { get; set; }
        public string? commentMessage { get; set; }
    }
}