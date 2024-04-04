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
    public class CommonService : ICommonService
    {
        private readonly dbcontext _context;
        private readonly IMapper _mapper;

        public CommonService(dbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Banner> GetAllBanners()
        {
            return _context.Banners.OrderBy(x => x.SortOrder).ToList();
        }

        public List<City> GetCitiesByCountry(string countryIds)
        {
            long[] countries = countryIds.Split(",").Select(long.Parse).ToArray();
            return _context.Cities.Where(x => countries.Contains(x.CountryId)).ToList();
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public List<Skill> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        public List<MissionTheme> GetAllThemes()
        {
            return _context.MissionThemes.ToList();
        }

        public List<RecommandUserDTO> GetAllUsers()
        {
            var users = _context.Users.Where(a => a.Deletedate == null).ToList();
            var recommandUsers = _mapper.Map<List<RecommandUserDTO>>(users);
            return recommandUsers;
        }

    }
}