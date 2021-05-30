using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi1.Helpers;

namespace webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtHelpers helpers;
        public AccountController(JwtHelpers helpers)
        {
            this.helpers = helpers;
        }

        [HttpPost("login")]
        public ActionResult<LoginResult> PostTModel(LoginVM model)
        {
            if (CheckPassword(model.Username, model.Password))
            {
                return new LoginResult() { Token = helpers.GenerateToken(model.Username) };
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetClaims")]
        public ActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }

        [HttpGet("GetUsername")]
        public ActionResult GetUsername()
        {
            return Ok(User.Identity.Name);
        }


        private bool CheckPassword(string username, string password)
        {
            if (username == "will")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class LoginVM
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class LoginResult
        {
            public string Token { get; set; }
        }
    }
}