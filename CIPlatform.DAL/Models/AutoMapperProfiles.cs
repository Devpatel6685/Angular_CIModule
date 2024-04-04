using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;

namespace CIPLATFORM.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserRegisterDTO>().ReverseMap();

            CreateMap<RecommandUserDTO, User>().ReverseMap();
        }

    }
}