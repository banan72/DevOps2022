using System.Collections.Generic;
using System.IO;
using System.Linq;
using banan72.DrinkingGame.Core;
using banan72.DrinkingGame.DataAccess.Converters;
using banan72.DrinkingGame.Domain;

namespace banan72.DrinkingGame.DataAccess
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MainDBContext _ctx;
        private readonly PlayerEntityConverter _playerConverter;

        public PlayerRepository(MainDBContext ctx)
        {
            if (ctx == null)
            {
                throw new InvalidDataException("Player Repository must have a DBContext");
            }

            _playerConverter = new PlayerEntityConverter();
            

            _ctx = ctx;
        }

        public List<Player> FindAll()
        {
            return _ctx.Player.Select(pe => _playerConverter.Convert(pe)).ToList();
        }

        public Player FindById(int id)
        {
            PlayerEntity pe = _ctx.Player.Find(id);
            return _playerConverter.Convert(pe);
        }

        public bool DeleteById(int id)
        {
            var p = _ctx.Player.Find(id);
            _ctx.Player.Remove(p);
            _ctx.SaveChanges();
            return true;
        }

        public Player CreatePlayer(Player player)
        {
            var pe = _playerConverter.Convert(player);
            _ctx.Player.Add(pe);
            _ctx.SaveChanges();
            return _playerConverter.Convert(pe);
        }

        public Player UpdatePlayer(int id, Player player)
        {
            PlayerEntity pe = _ctx.Player.Find(id);
            pe.name = player.name;
            pe.isAdmin = player.isAdmin;
            pe.totalSips = player.totalSips;
            PlayerEntity returnEntity = _ctx.Player.Update(pe).Entity;
            _ctx.SaveChanges();
            return _playerConverter.Convert(returnEntity);
        }
    }
}