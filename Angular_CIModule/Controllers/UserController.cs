using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CIPLATFORM.Interfaces;
using CIPlatform.DAL.Models;
using System.Net;
using CIPLATFORM.Common;
using Microsoft.AspNetCore.Authorization;
using CIPlatform.DAL.ViewModels;

namespace CIPLATFORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        private readonly IConfiguration _config;


        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] UserLoginDTO userLogin)
        {
            User user = _userService.Login(userLogin);
            return user != null
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.SUCCESS }, new { token = Helper.GenerateToken(user, _config), data = user }))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.USER_NOT_FOUND }));
        }

        [HttpPost]
        [Route("register")]
        public void RegisterUser(User model)
        {
            _userService.CreateUser(model);
        }

        [HttpGet]
        [Route("IsUserExist")]
        public IActionResult IsUserExist(string? email)
        {
            return Ok(_userService.IsUserExist(email));
        }

        [HttpGet("ForgotPassword")]
        public ActionResult ForgotPassword(string email)
        {
            bool result = _userService.ForgotPassword(email);
            return result
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.RESET_PASSWORD_EMAIL_SUCCESS }))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.USER_NOT_FOUND }));
        }

        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            bool result = _userService.ResetPassword(resetPasswordDTO);
            return result
                ? this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Constants.RESET_PASSWORD_SUCCESS }))
                : (ActionResult)this.Ok(new ApiResponse(HttpStatusCode.InternalServerError, new List<string> { Constants.ERROR }));
        }

    }
}