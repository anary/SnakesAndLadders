using SnakesAndLadders.Core.Entities;
using SnakesAndLadders.Core.Interfaces;

namespace SnakesAndLadders.Business
{
    public class Game
    {
        private readonly Board _board;
        private readonly Token _token;
        private readonly IDice _dice;
        private readonly ILadderRunningService _ladderRunningService;
        public Game(Board board, Token token, IDice dice, ILadderRunningService ladderRunningService)
        {
            _board = board;
            _token = token;
            _dice = dice;
            _ladderRunningService = ladderRunningService;
        }

        public void Play()
        {
            var diceNumber = _dice.Roll();
            _ladderRunningService.Run(_board.Squares, _token, diceNumber);
        }
    }
}