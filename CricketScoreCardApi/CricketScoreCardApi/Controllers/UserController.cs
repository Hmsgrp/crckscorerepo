using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreCardDB.Repositories;
using CricketScoreCardDB.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CricketScoreCardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _URepo;
        public UserController(IUserRepository URepo)
        {
            _URepo = URepo;
        }

        [Authorize]
        // GET: api/<Team>
        [HttpGet]
        [Route("GetUsers", Name = "GetUsers")]
        public IActionResult Get()
        {
            return Ok(_URepo.GetUsers());
        }

        [HttpPost]
        [Route("AddUser", Name = "AddUser")]
        public IActionResult Post(Users UserParameter)
        {
            _URepo.AddUser(UserParameter);
            return Ok(UserParameter);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteUser/{id}", Name = "DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _URepo.DeleteUser(id);
            return NoContent();
        }

        [Authorize]
        // GET: api/<Team>
        [HttpGet]
        [Route("GetSumaryInfo", Name = "GetSumaryInfo")]
        public IActionResult GetSumaryInfo()
        {
            return Ok(_URepo.GetSumaryInfo());
        }

        [Authorize]
        // GET: api/<Team>
        [HttpGet]
        [Route("GetSumary", Name = "GetSumary")]
        public IActionResult GetSumary()
        {
            return Ok(_URepo.GetSumary());
        }

        [HttpPost]
        [Route("Auth/Login", Name = "Login")]
        public IActionResult Login(Users UserParameter)
        {
            if (UserParameter == null)
                return BadRequest("Not Found");


           var result = _URepo.GetUsersLoginAuth(UserParameter.UserName, UserParameter.Password);
            if (!string.IsNullOrEmpty(result.UserName))
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismytestpleaseusesecretkey@123"));
                var signingCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

                var claimsList = new[]
                 {
                    new Claim(ClaimTypes.Role, result.RoleID.ToString())
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44367",
                    audience: "https://localhost:4200",
                    claims: claimsList,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

            _URepo.AddUser(UserParameter);
            return Ok(UserParameter);
        }


    }
}
