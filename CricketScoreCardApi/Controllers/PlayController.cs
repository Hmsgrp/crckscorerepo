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
    public class PlayController : ControllerBase
    {
        private readonly IPlayerRepository _PRepo;
        public PlayController(IPlayerRepository PRepo)
        {
            _PRepo = PRepo;
        }

        // GET: api/<Team>
        [HttpGet]
        [Route("GetPlayerV1", Name = "GetPlayerV1")]
        public IActionResult Get()
        {
            return Ok(_PRepo.GetPlayers());
        }

        [HttpPost]
        [Route("AddPlayerV1", Name = "AddPlayerV1")]
        public IActionResult Post(Players Player)
        {
            _PRepo.AddPlayer(Player);
            return Ok(Player);
        }

        // PUT api/<Team>/5
        [HttpPut]
        [Route("UpdatePlayerV1", Name = "UpdatePlayerV1")]
        public IActionResult Put(Players PlayerParameter)
        {
            _PRepo.updatePlayer(PlayerParameter);
            return Ok(PlayerParameter);
        }

        [HttpDelete]
        [Route("DeletePlayerV1/{id}", Name = "DeletePlayerV1")]
        public IActionResult DeletePlayer(int id)
        {
            _PRepo.DeletePlayer(id);
            return NoContent();
        }
    }
}
