using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreCardDB.Repositories;
using cricDBModels = CricketScoreCardDB.Models;
using System.Net;
using CricketScoreCardDB.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CricketScoreCardApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Team : ControllerBase
    {
        private readonly ITeamRepository _TeamRepo;
        public Team(ITeamRepository TeamRepo)
        {
            _TeamRepo = TeamRepo;
        }

        // GET: api/<Team>
        [HttpGet]
        [Route("GetTeams", Name = "GetTeams")]
        public IActionResult Get()
        {
            return Ok(_TeamRepo.GetTeams());
        }

        [HttpPost]
        [Route("AddTeam", Name = "AddTeam")]
        public IActionResult Post(cricDBModels.Teams TeamParameter)
        {
            _TeamRepo.AddTeam(TeamParameter);
           return Ok(TeamParameter);
        }

        // PUT api/<Team>/5
        [HttpPut]
        [Route("UpdateTeam", Name = "UpdateTeam")]
        public IActionResult Put(cricDBModels.Teams TeamParameter)
        {
            _TeamRepo.updateTeam(TeamParameter);
            return Ok(TeamParameter);
        }

        [HttpDelete]
        [Route("DeleteTeam/{id}", Name = "DeleteTeam")]
        public IActionResult DeleteTeam(int id)
        {
            _TeamRepo.DeleteTeam(id);
            return NoContent();
        }
    }
}
