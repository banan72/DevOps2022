using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banan72.DrinkingGame.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dto;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            try
            {
                return Ok(_playerService.GetPlayers());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet(nameof(GetTopSippers))]
        public ActionResult<List<Player>> GetTopSippers(int topPlayers)
        {
            try
            {
                return Ok(_playerService.GetTopPlayers(topPlayers));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}