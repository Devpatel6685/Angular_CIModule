using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;
using CIPLATFORM.Services;


namespace CIPLATFORM.Interfaces
{
    public interface IUserService
    {
        User Login(UserLoginDTO userLogin);

        bool IsUserExist(string email);
        void CreateUser(User model);
        bool ForgotPassword(string email);

        bool ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}