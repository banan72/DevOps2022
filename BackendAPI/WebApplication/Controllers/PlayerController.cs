using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banan72.DrinkingGame.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Converters;
using WebApplication.Dto;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly PlayerDtoConverter _playerConverter;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
            _playerConverter = new PlayerDtoConverter();
        }
        
        [HttpGet]
        public ActionResult<List<PlayerDto>> GetAll()
        {
            try
            {
                return Ok(_playerConverter.Convert(_playerService.GetPlayers()));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet(nameof(GetTopSippers))]
        public ActionResult<List<PlayerDto>> GetTopSippers(int topPlayers)
        {
            try
            {
                return Ok(_playerConverter.Convert(_playerService.GetTopPlayers(topPlayers)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<PlayerDto> GetPlayerById(int id)
        {
            try
            {
                return Ok(_playerConverter.Convert(_playerService.GetPlayerById(id)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public ActionResult<bool> DeletePlayerById(int id)
        {
            try
            {
                return Ok(_playerService.DeletePlayerById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<PlayerDto> CreatePlayer(PlayerDto playerDto)
        {
            try
            {
                return Ok(_playerConverter.Convert(_playerService.CreatePlayer(_playerConverter.Convert(playerDto))));
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        [HttpPut]
        public ActionResult<PlayerDto> UpdatePlayer(int id, PlayerDto playerDto)
        {
            try
            {
                return Ok(_playerConverter.Convert(_playerService.UpdateCustomer(id, _playerConverter.Convert(playerDto))));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}