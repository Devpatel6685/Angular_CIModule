using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;

namespace CIPlatform.BAL.Interfaces
{
    public interface ICommonService
    {
        List<Banner> GetAllBanners();
        List<Country> GetAllCountries();

         List<City> GetCitiesByCountry(string countryIds);

         List<MissionTheme> GetAllThemes();

         List<Skill> GetAllSkills();

         
    }
}