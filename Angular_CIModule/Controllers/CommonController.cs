using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CIPlatform.BAL.Interfaces;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;
using CIPLATFORM.Common;
using Microsoft.AspNetCore.Mvc;

namespace Angular_CIModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("GetAllBanners")]
        public ActionResult GetAllBanners()
        {
            List<Banner> bannerList = _commonService.GetAllBanners();
            return bannerList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, bannerList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet("GetAllCountries")]
        public ActionResult GetAllCountries()
        {
            List<Country> countryList = _commonService.GetAllCountries();
            return countryList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, countryList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet("GetCitiesByCountry/{countryIds}")]
        public ActionResult GetCitiesByCountry(string countryIds)
        {
            List<City> cityList = _commonService.GetCitiesByCountry(countryIds);
            return cityList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, cityList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet("GetAllThemes")]
        public ActionResult GetAllThemes()
        {
            List<MissionTheme> themeList = _commonService.GetAllThemes();
            return themeList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, themeList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet("GetAllSkills")]
        public ActionResult GetAllSkills()
        {
            List<Skill> skillList = _commonService.GetAllSkills();
            return skillList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, skillList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }

        [HttpGet("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            List<RecommandUserDTO> userList = _commonService.GetAllUsers();
            return userList != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, userList))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.NoContent, new List<string> { Constants.NO_DATA }));
        }
    }
}