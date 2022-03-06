using System.Collections.Generic;
using System.IO;
using System.Linq;
using banan72.DrinkingGame.Core;
using banan72.DrinkingGame.Domain;

namespace banan72.DrinkingGame.DataAccess
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MainDBContext _ctx;

        public PlayerRepository(MainDBContext ctx)
        {
            if (ctx == null)
            {
                throw new InvalidDataException("Player Repository must have a DBContext");
            }

            _ctx = ctx;
        }

        public List<Player> FindAll()
        {
            return _ctx.Player.Select(pe => new Player
            {
                id = pe.id,
                name = pe.name,
                isAdmin = pe.isAdmin,
                totalSips = pe.totalSips
            }).ToList();
        }

        public Player FindById(int id)
        {
            PlayerEntity pe = _ctx.Player.Find(id);
            return new Player
            {
                id = pe.id,
                name = pe.name,
                isAdmin = pe.isAdmin,
                totalSips = pe.totalSips
            };
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
            var pe = new PlayerEntity
            {
                id = player.id,
                name = player.name,
                isAdmin = player.isAdmin,
                totalSips = player.totalSips
            };
            _ctx.Player.Add(pe);
            _ctx.SaveChanges();
            return new Player
            {
                id = pe.id,
                name = pe.name,
                isAdmin = pe.isAdmin,
                totalSips = pe.totalSips
            };
        }

        public Player UpdatePlayer(int id, Player player)
        {
            PlayerEntity pe = _ctx.Player.Find(id);
            pe.name = player.name;
            pe.isAdmin = player.isAdmin;
            pe.totalSips = player.totalSips;
            PlayerEntity returnEntity = _ctx.Player.Update(pe).Entity;
            _ctx.SaveChanges();
            return new Player
            {
                id = returnEntity.id,
                name = returnEntity.name,
                isAdmin = returnEntity.isAdmin,
                totalSips = pe.totalSips
            };
        }
    }
}