using System.Collections.Generic;
using banan72.DrinkingGame.Core;
using WebApplication.Dto;

namespace WebApplication.Converters
{
    public class PlayerDtoConverter
    {
        public Player Convert(PlayerDto dto)
        {
            return new Player
            {
                id = dto.id,
                name = dto.name,
                totalSips = dto.totalSips,
                isAdmin = dto.isAdmin
            };
        }
        
        public PlayerDto Convert(Player player)
        {
            return new PlayerDto
            {
                id = player.id,
                name = player.name,
                totalSips = player.totalSips,
                isAdmin = player.isAdmin
            };
        }

        public List<PlayerDto> Convert(List<Player> playerList)
        {
            List<PlayerDto> returnList = new List<PlayerDto>();
            foreach (Player p in playerList)
            {
                returnList.Add(Convert(p));
            }

            return returnList;
        }
    }
}