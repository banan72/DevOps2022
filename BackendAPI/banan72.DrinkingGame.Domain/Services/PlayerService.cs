using System.Collections.Generic;
using System.IO;
using System.Linq;
using banan72.DrinkingGame.Core;

namespace banan72.DrinkingGame.Domain
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository ?? throw new InvalidDataException();
        }
        public List<Player> GetPlayers()
        {
            return _playerRepository.FindAll();
        }

        public Player GetPlayerById(int id)
        {
            return _playerRepository.FindById(id);
        }

        public bool DeletePlayerById(int id)
        {
            return _playerRepository.DeleteById(id);
        }

        public Player CreatePlayer(Player player)
        {
            return _playerRepository.CreatePlayer(player);
        }

        public Player UpdateCustomer(int id, Player player)
        {
            return _playerRepository.UpdatePlayer(id, player);
        }

        public List<Player> GetTopPlayers(int topPlayers)
        {
            List<Player> SortedList = _playerRepository.FindAll().OrderBy(o => o.totalSips).Reverse().ToList();
            List<Player> returnList = new List<Player>();

            if (topPlayers >= SortedList.Count)
                return SortedList;
            
            for (int i = 0; i < topPlayers; i++)
            {
                returnList.Add(SortedList[i]);
            }

            return returnList;
        }
    }
}