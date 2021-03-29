using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreCardDB.Repositories;
using CricketScoreCardDB.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CricketScoreCardApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _RRepo;
        public RoleController(IRoleRepository RRepo)
        {
            _RRepo = RRepo;
        }

        // GET: api/<Team>
        [HttpGet]
        [Route("GetRole", Name = "GetRole")]
        public IActionResult Get()
        {
            return Ok(_RRepo.GetRoles());
        }

        [HttpPost]
        [Route("AddRole", Name = "AddRole")]
        public IActionResult Post(Roles RoleParameter)
        {
            _RRepo.AddRole(RoleParameter);
            return Ok(RoleParameter);
        }

        // PUT api/<Team>/5
        [HttpPut]
        [Route("UpdateRole", Name = "UpdateRole")]
        public IActionResult Put(Roles RoleParameter)
        {
            _RRepo.updateRole(RoleParameter);
            return Ok(RoleParameter);
        }

        [HttpDelete]
        [Route("DeleteRole/{id}", Name = "DeleteRole")]
        public IActionResult DeleteRole(int id)
        {
            _RRepo.DeleteRole(id);
            return NoContent();
        }
    }
}
