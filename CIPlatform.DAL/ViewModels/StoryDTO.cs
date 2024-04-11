using CIPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class StoryDTO
    {
        public long StoryId { get; set; }
        public long MissionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? StoryImage { get; set; }
        public string? Theme { get; set; }
        public User? User { get; set; }
        //public List<StoryMedium>? storyMedia { get; set; }

    }
}
