using SnakesAndLadders.Core.Entities;

namespace SnakesAndLadders.Core.Interfaces
{
    public interface ILadderRunningService
    {
        void Run(int squares, Token token, int steps);
    }
}