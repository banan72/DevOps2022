﻿using System;

namespace banan72.DrinkingGame.Core
{
    public class Player
    {
        public int id { get; set; }
        public String name { get; set; }

        public String Type { get; set; }
        public bool isAdmin { get; set; }
        public int totalSips { get; set; }
    }
}