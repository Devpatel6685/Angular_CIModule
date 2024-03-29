using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIPlatform.BAL.Interfaces;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CIPlatform.BAL.Services
{
    public class MissionService : IMissionService
    {
        private readonly dbcontext _context;
        private readonly IMapper _mapper;

        public MissionService(dbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MissionListDTO> GetMissionsByFilter(MissionSearchDTO missionSearchDTO)
        {
            var missionCards = (from m in _context.Missions
                                where m.DeletedAt == null
                                select new MissionListDTO
                                {
                                    MissionId = m.MissionId,
                                    MissionImage = m.MissionMedia.Count > 0 ? m.MissionMedia.FirstOrDefault().MediaName : string.Empty,
                                    MissionImagePath = m.MissionMedia.Count > 0 ? m.MissionMedia.FirstOrDefault().MediaPath : string.Empty,
                                    City = m.City.Name,
                                    CityId = m.CityId,
                                    Country = m.Country.Name,
                                    CountryId = m.CountryId,
                                    Theme = m.Theme.Title,
                                    ThemeId = m.ThemeId,
                                    Title = m.Title,
                                    ShortDescription = m.ShortDescription,
                                    OrganizationName = m.OrganizationName,
                                    Rating = m.MissionRatings.Count > 0 ? Convert.ToInt32(m.MissionRatings.FirstOrDefault().Rating) : 0,
                                    MissionType = m.MissionType,
                                    GoalValue = m.GoalMissions.Count > 0 ? Convert.ToInt32(m.GoalMissions.FirstOrDefault().GoalValue) : 0,
                                    GoalObjectiveText = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalObjectiveText : string.Empty,
                                    StartDate = m.StartDate,
                                    CreatedAt = m.CreatedAt,
                                    EndDate = m.EndDate,
                                    SeatsLeft = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalValue - m.MissionApplications.Count() : 0,
                                    Skill = m.MissionSkills.Count > 0 ? m.MissionSkills.FirstOrDefault().Skill.SkillName : string.Empty,
                                    IsFavourite = m.FavouriteMissions.Count > 0 ? m.FavouriteMissions.Where(x => x.MissionId == m.MissionId && x.UserId == missionSearchDTO.UserId).Count() > 0 : false
                                }).OrderBy(x => x.MissionId).ToList();

            if (missionSearchDTO.CountryId.Count() > 0)
            {
                missionCards = missionCards.Where(m => missionSearchDTO.CountryId.Contains(m.CountryId)).ToList();
            }
            if (missionSearchDTO.CityId.Count() > 0)
            {
                missionCards = missionCards.Where(m => missionSearchDTO.CityId.Contains(m.CityId)).ToList();
            }
            if (missionSearchDTO.ThemeId.Count() > 0)
            {
                missionCards = missionCards.Where(m => missionSearchDTO.ThemeId.Contains(m.ThemeId)).ToList();
            }
            if (missionSearchDTO.SkillId.Count() > 0)
            {

                var x = _context.MissionSkills.Where(a => missionSearchDTO.SkillId.Contains(a.SkillId)).ToList();
                var list = new List<long>();

                foreach (var n in x)
                {
                    list.Add(n.MissionId);

                }
                missionCards = missionCards.Where(a => list.Contains(a.MissionId)).ToList();

            }

            if (!string.IsNullOrEmpty(missionSearchDTO.SearchByText))
            {
                missionCards = missionCards.Where(a => a.Title.ToLower().StartsWith(missionSearchDTO.SearchByText.ToLower()) || a.OrganizationName.ToLower().StartsWith(missionSearchDTO.SearchByText.ToLower())).ToList();
            }

            switch (missionSearchDTO.SortOrder)
            {
                case "Newest":
                    missionCards = missionCards.OrderBy(s => s.CreatedAt).ToList();
                    break;
                case "Oldest":
                    missionCards = missionCards.OrderByDescending(s => s.CreatedAt).ToList();
                    break;
                // case 3:
                //     missionCards = missionCards.OrderBy(s => s.EndDate).ToList();
                //     break;
            }
            switch (missionSearchDTO.ExploreBy)
            {
                //case 0:
                //    missionCards.Missions = missionCards.Missions.ToList();
                //    break;
                //case 1:
                //    missionCards.Missions = missionCards.Missions.GroupBy(m => m.ThemeId).OrderByDescending(a => a.Count()).SelectMany(a => a).ToList();
                //    break;
                //case 2:
                //    missionCards.Missions = missionCards.Missions.Where(a => a.MissionRatings.Any()).OrderByDescending(a => a.MissionRatings.Average(r => Convert.ToInt64(r.Rating))).ToList();
                //    break;
                //case 3:
                //    missionCards.Missions = missionCards.Missions.OrderByDescending(a => a.FavoriteMissions.Count()).ToList();
                //    break;
            }

            return missionCards;
        }
        public bool AddToFavourite(AddToFavouriteDTO addToFavouriteDTO)
        {
            if (addToFavouriteDTO != null)
            {
                FavouriteMission existingFavouriteMission = _context.FavouriteMissions.Where(x => x.MissionId == addToFavouriteDTO.MissionId && x.UserId == addToFavouriteDTO.UserId).FirstOrDefault();
                if (existingFavouriteMission != null)
                {
                    _context.FavouriteMissions.Remove(existingFavouriteMission);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    FavouriteMission favouriteMission = new()
                    {
                        MissionId = addToFavouriteDTO.MissionId,
                        UserId = addToFavouriteDTO.UserId,
                        CreatedAt = DateTime.Now
                    };
                    _context.FavouriteMissions.Add(favouriteMission);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}