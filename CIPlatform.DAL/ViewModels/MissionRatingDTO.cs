using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class MissionRatingDTO
    {
        public long MissionId { get; set; }
        public int UserId { get; set; }
        public int Ratings { get; set; }
    }
}