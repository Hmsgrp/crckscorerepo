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
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _MRepo;
        public MatchController(IMatchRepository MRepo)
        {
            _MRepo = MRepo;
        }

        // GET: api/<Team>
        [HttpGet]
        [Route("GetMatch", Name = "GetMatch")]
        public IActionResult Get()
        {
            return Ok(_MRepo.GetMatches());
        }

        [HttpPost]
        [Route("AddMatch", Name = "AddMatch")]
        public IActionResult Post(Matches MatchParameter)
        {
            _MRepo.AddMatch(MatchParameter);
            return Ok(MatchParameter);
        }

        // PUT api/<Team>/5
        [HttpPut]
        [Route("UpdateMatch", Name = "UpdateMatch")]
        public IActionResult Put(Matches MatchParameter)
        {
            _MRepo.updateMatch(MatchParameter);
            return Ok(MatchParameter);
        }

        [HttpDelete]
        [Route("DeleteMatch/{id}", Name = "DeleteMatch")]
        public IActionResult DeleteMatch(int id)
        {
            _MRepo.DeleteMatch(id);
            return NoContent();
        }
    }
}
