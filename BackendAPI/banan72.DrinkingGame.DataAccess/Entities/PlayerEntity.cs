using System;

namespace banan72.DrinkingGame.DataAccess
{
    public class PlayerEntity
    {
        public int id { get; set; }
        public String name { get; set; }
        public bool isAdmin { get; set; }
        public int totalSips { get; set; }
    }
}