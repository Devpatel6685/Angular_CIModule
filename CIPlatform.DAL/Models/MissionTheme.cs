using System;
using System.Collections.Generic;

namespace CIPlatform.DAL.Models
{
    public partial class MissionTheme
    {
        public MissionTheme()
        {
            Missions = new HashSet<Mission>();
        }

        public long MissionThemeId { get; set; }
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }
    }
}
