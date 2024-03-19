using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIPlatform.DAL.Models;
using CIPLATFORM.Services;


namespace CIPLATFORM.Interfaces
{
    public interface IUserService
    {
        User Login(UserLoginDTO userLogin);
    }      
}