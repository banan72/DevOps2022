using banan72.DrinkingGame.Core;

namespace banan72.DrinkingGame.DataAccess.Converters
{
    public class PlayerEntityConverter
    {
        public Player Convert(PlayerEntity entity)
            {
                return new Player
                {
                    id = entity.id,
                    name = entity.name,
                    totalSips = entity.totalSips,
                    isAdmin = entity.isAdmin
                };
            }
        
            public PlayerEntity Convert(Player player)
            {
                return new PlayerEntity
                {
                    id = player.id,
                    name = player.name,
                    totalSips = player.totalSips,
                    isAdmin = player.isAdmin
                };
            }
    }
}