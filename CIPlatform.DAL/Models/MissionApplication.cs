﻿using System;
using System.Collections.Generic;

namespace CIPlatform.DAL.Models
{
    public partial class MissionApplication
    {
        public long MissionApplicationId { get; set; }
        public long? MissionId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AppliedAt { get; set; }
        public string? ApprovalStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission? Mission { get; set; }
        public virtual User? User { get; set; }
    }
}
