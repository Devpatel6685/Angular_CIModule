using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPlatform.DAL.ViewModels
{
    public class MissionListDTO
    {
        public long MissionId { get; set; }
        public string? MissionImage { get; set; }
        public string? MissionImagePath { get; set; }
        public string? City { get; set; }
        public long CityId { get; set; }
        public string? Country { get; set; }
        public long CountryId { get; set; }
        public string? Theme { get; set; }
        public long ThemeId { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? OrganizationName { get; set; }
        public int Rating { get; set; }
        public string? MissionType { get; set; }
        public int GoalValue { get; set; }
        public string? GoalObjectiveText { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? SeatsLeft { get; set; }
        public string? Skill { get; set; }
        public bool IsFavourite { get; set; } = false;
        public bool MissionApplied { get; set; } = false;
    }
}