using System.Collections.Generic;

namespace banan72.DrinkingGame.Core
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();
        Player GetPlayerById(int id);
        bool DeletePlayerById(int id);
        Player CreatePlayer(Player player);
        Player UpdateCustomer(int id, Player player);
        List<Player> GetTopPlayers(int topPlayers);
    }
}