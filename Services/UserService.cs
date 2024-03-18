using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIPLATFORM.Interfaces;
using CIPLATFORM.Models;

namespace CIPLATFORM.Services
{
    public class UserService : IUserService
    {
        private readonly CiplatformContext _context;
        private readonly IMapper mapper;
 
        public UserService(CiplatformContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
    }
}