using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreCardDB.Repositories;
using CricketScoreCardDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace CricketScoreCardApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _SRepo;
        public ScoreController(IScoreRepository SRepo)
        {
            _SRepo = SRepo;
        }

        // GET: api/<Team>
        [HttpGet]
        [Route("GetScores", Name = "GetScores")]
        public IActionResult Get()
        {
            return Ok(_SRepo.GetScores());
        }

        [HttpPost]
        [Route("AddScore", Name = "AddScore")]
        public IActionResult Post(Scores ScoreParameter)
        {
            _SRepo.AddScore(ScoreParameter);
            return Ok(ScoreParameter);
        }

        // PUT api/<Team>/5
        [HttpPut]
        [Route("UpdateScore", Name = "UpdateScore")]
        public IActionResult Put(Scores ScoreParameter)
        {
            _SRepo.updateScore(ScoreParameter);
            return Ok(ScoreParameter);
        }

        [HttpDelete]
        [Route("DeleteScore/{id}", Name = "DeleteScore")]
        public IActionResult DeleteScore(int id)
        {
            _SRepo.DeleteScore(id);
            return NoContent();
        }
    }
}
