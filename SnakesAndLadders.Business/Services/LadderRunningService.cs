using SnakesAndLadders.Core.Entities;
using SnakesAndLadders.Core.Interfaces;

namespace SnakesAndLadders.Business.Services
{
    public class LadderRunningService : ILadderRunningService
    {
        public void Run(int squares, Token token, int steps)
        {
            var tempLocation = token.CurrentPosition + steps;

            if (tempLocation > squares)
            {
                token.CurrentPosition = token.CurrentPosition;
                token.Result = false;
                return;
            }

            token.CurrentPosition = tempLocation;
            token.Result = tempLocation >= squares;
        }
    }
}