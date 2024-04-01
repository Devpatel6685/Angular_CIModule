using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIPlatform.DAL.Models;
using CIPlatform.DAL.ViewModels;
using CIPLATFORM.Interfaces;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto;

namespace CIPLATFORM.Services
{
    public class UserService : IUserService
    {
        private readonly dbcontext _context;
        private readonly IMapper _mapper;

        public UserService(dbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User Login(UserLoginDTO userLogin)
        {
            bool verified = false;
            var user = _context.Users.Where(u => u.Email == userLogin.Email).FirstOrDefault();
            if (user != null)
            {
                verified = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);
                if (verified)
                    return user;
            }
            return null;
        }

        public bool CreateUser(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                User user = _mapper.Map<User>(userRegisterDTO);
                user.Createdate = DateTime.Now;
                string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password);
                user.Password = encryptedPassword;

                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public bool IsUserExist(string email)
        {
            var userExists = _context.Users.Where(u => u.Email == email && u.Deletedate == null).FirstOrDefault();
            if (userExists != null)
                return true;
            else
                return false;
        }

        public bool ForgotPassword(string email)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            if (user != null)
            {
                ResetPassword resetPassword = new()
                {
                    UserId = user.Id,
                    Token = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                };

                _context.ResetPasswords.Add(resetPassword);
                _context.SaveChanges();

                var mailBody = "<h1>Click below link to reset password</h1><br><h2><a href='" + "http://localhost:4200/reset-password/" + resetPassword.Token + "'>Reset Password</a></h2>";
                Helper.SendEmail(mailBody, user.Email);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            ResetPassword resetPassword = _context.ResetPasswords.FirstOrDefault(x => x.Token == resetPasswordDTO.Token);
            if (resetPassword == null || (DateTime.Now - resetPassword.CreatedAt).TotalMinutes > 30)
                return false;

            User user = _context.Users.FirstOrDefault(x => x.Id == resetPassword.UserId);
            if (user == null)
                return false;

            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(resetPasswordDTO.Password);
            user.Password = encryptedPassword;
            _context.Users.Update(user);
            _context.SaveChanges();

            var tokenList = _context.ResetPasswords.Where(a => a.Id == user.Id).ToList();
            if (tokenList != null)
                _context.ResetPasswords.RemoveRange(tokenList);
            return true;
        }

        public bool CheckPassWord(string? token, string? password)
        {
            var data = _context.ResetPasswords.Where( a => a.Token == token).FirstOrDefault();
            if(data != null)
            {
                var user = _context.Users.Where(u => u.Id == data.UserId).FirstOrDefault();
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    return true;
            }
            return false;            
        }

    }
}