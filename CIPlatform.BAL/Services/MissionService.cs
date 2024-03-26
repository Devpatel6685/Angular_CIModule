using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIPlatform.BAL.Interfaces;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;

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
            return (from m in _context.Missions
                    where (m.DeletedAt == null
                       || (missionSearchDTO.CityId.Count > 0 && missionSearchDTO.CityId.Contains(m.CityId))
                       || (missionSearchDTO.CountryId.Count > 0 && missionSearchDTO.CountryId.Contains(m.CountryId))
                       || (missionSearchDTO.ThemeId.Count > 0 && missionSearchDTO.ThemeId.Contains(m.ThemeId))
                       || (!string.IsNullOrEmpty(missionSearchDTO.SearchByText) && (m.Title.Contains(missionSearchDTO.SearchByText) || m.OrganizationName.Contains(missionSearchDTO.SearchByText))))
                    select new MissionListDTO
                    {
                        MissionId = m.MissionId,
                        MissionImage = m.MissionMedia.Count > 0 ? m.MissionMedia.FirstOrDefault().MediaName : string.Empty,
                        MissionImagePath = m.MissionMedia.Count > 0 ? m.MissionMedia.FirstOrDefault().MediaPath : string.Empty,
                        City = m.City.Name,
                        Theme = m.Theme.Title,
                        Title = m.Title,
                        ShortDescription = m.ShortDescription,
                        OrganizationName = m.OrganizationName,
                        Rating = m.MissionRatings.Count > 0 ? m.MissionRatings.FirstOrDefault().Rating : 0,
                        MissionType = m.MissionType,
                        GoalValue = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalValue : 0,
                        GoalObjectiveText = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalObjectiveText : string.Empty,
                        StartDate = m.StartDate,
                        EndDate = m.EndDate,
                        SeatsLeft = m.GoalMissions.Count > 0 ? m.GoalMissions.FirstOrDefault().GoalValue - m.MissionApplications.Count() : 0,
                        Skill = m.MissionSkills.Count > 0 ? m.MissionSkills.FirstOrDefault().Skill.SkillName : string.Empty,
                        IsFavourite = m.FavouriteMissions.Count > 0 ? m.FavouriteMissions.Where(x => x.MissionId == m.MissionId && x.UserId == missionSearchDTO.UserId).Count() > 0 : false
                    }).OrderBy(x => x.MissionId).ToList();
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