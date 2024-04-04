using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIPlatform.DAL.Models;

namespace CIPlatform.DAL.ViewModels
{
    public class VolunteeringMissionDTO
    {
        public long MissionId { get; set; }
        public string? City { get; set; }
        public long? CityId { get; set; }
        public string? Theme { get; set; }
        public long? ThemeId { get; set; }
        public long? CountryId { get; set; }

        public string? Title { get; set; }
        public string? ShortDescription { get; set; }

        public string? Description { get; set; }

        public string? OrganizationName { get; set; }
        public int UserRating { get; set; }
        public int Rating { get; set; }
        public int CountOfUsersRated { get; set; }
        public string? MissionType { get; set; }
        public int GoalValue { get; set; }
        public string? GoalObjectiveText { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SeatsLeft { get; set; }
        public bool IsFavourite { get; set; } = false;

        public List<MissionMedium>? missionMedias { get; set; }

        public List<string>? missionSkills { get; set; }

        public List<Comment>? comments { get; set; }
        public List<User>? volunteres { get; set; }

    }
}