using DemoCrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DemoCrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        AppDbContext _dbContext;
        public PlayersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ReadPlayers")]
        public List<PlayersModel> ReadPlayers()
        {
            var players = _dbContext.Players.ToList();
            _dbContext.SaveChanges();
            return players;
        }

        [HttpGet]
        [Route("ReadPlayerById")]
        public PlayersModel ReadPlayerById(int id)
        {
            var player = _dbContext.Players.Where(p => p.PlayerID == id).FirstOrDefault();
            _dbContext.SaveChanges();
            return player;
        }

        [HttpPost]
        [Route("CreatePlayer")]
        public IActionResult CreatePlayer(PlayersModel player)
        {
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();
            return Created("CreatePlayer",player);
        }

        [HttpPut]
        [Route("UpdatePlayer")]
        public IActionResult UpdatePlayer(int id, PlayersModel player)
        {
            if (id != player.PlayerID) 
                return BadRequest("Please correct category Id");

            if (ModelState.IsValid)
            {
                try
                {
                    PlayersModel play = new PlayersModel()
                    {
                        PlayerID = player.PlayerID,
                        PlayerName = player.PlayerName,
                        PlayerAddress = player.PlayerAddress,
                        PlayerAge = player.PlayerAge,
                        PlayerJoiningDate = player.PlayerJoiningDate
                    };
                    _dbContext.Players.Update(play);
                    _dbContext.SaveChanges();
                    return Ok(play);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
                }
            }
            return BadRequest("Please enter the correct PlayerID!");
        }

        [HttpDelete]
        [Route("DeltePlayer")]
        public IActionResult DeletePlayer(int id)
        {
            PlayersModel player = _dbContext.Players.Where(p => p.PlayerID==id).FirstOrDefault();
            if (player != null)
            {
                _dbContext.Players.Remove(player);
                _dbContext.SaveChanges();
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
