using System;
using SnakesAndLadders.Core.Interfaces;

namespace SnakesAndLadders.Business.Services
{
    public class Dice : IDice
    {
        public int Roll()
        {
            var random = new Random();
            return random.Next(1, 7);
        }
    }
}