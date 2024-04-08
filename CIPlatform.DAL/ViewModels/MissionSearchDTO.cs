using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class MissionSearchDTO
    {
        public List<long>? CityId { get; set; }
        public List<long>? CountryId { get; set; }
        public List<long>? ThemeId { get; set; }
        public List<long>? SkillId { get; set; }
        public string? SortOrder { get; set; }
        public long? ExploreBy { get; set; }
        public string? SearchByText { get; set; }
        public long? UserId { get; set; }
    }
}