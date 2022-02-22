using System.Collections.Generic;
using banan72.DrinkingGame.Core;

namespace banan72.DrinkingGame.Domain
{
    public interface IPlayerRepository
    {
        List<Player> FindAll();
        Player FindById(int id);
        bool DeleteById(int id);
        Player CreatePlayer(Player player);
        Player UpdatePlayer(int id, Player player);
    }
}