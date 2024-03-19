using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIPlatform.DAL.Models;
using CIPLATFORM.Interfaces;

namespace CIPLATFORM.Services
{
    public class UserService : IUserService
    {
        private readonly dbcontext _context;
        private readonly IMapper mapper;

        public UserService(dbcontext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public User Login(UserLoginDTO userLogin)
        {
            return _context.Users.Where(x => x.Email.Equals(userLogin.Email) && x.Password.Equals(userLogin.Password)).FirstOrDefault();
        }
    }
}