using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SnakesAndLadders.Business;
using SnakesAndLadders.Core.Entities;
using SnakesAndLadders.Core.Interfaces;

namespace SnakesAndLaddersUnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_Play_ShouldCallDiceRoll()
        {
            //Arrange
            var board = new Board { Squares = 10 };
            var token = new Token();
            var dice = MockRepository.GenerateMock<IDice>();
            var ladderRunningService = MockRepository.GenerateMock<ILadderRunningService>();

            var sut = new Game(board, token, dice, ladderRunningService);

            //Act
            sut.Play();

            //Arrange
            dice.AssertWasCalled(x => x.Roll(), option => option.Repeat.Once());
        }

        [TestMethod]
        public void Game_Play_ShouldCallLadderRunningServiceRun()
        {
            //Arrange
            const int STEP = 1;
            var board = new Board { Squares = 10 };
            var token = new Token();
            var dice = MockRepository.GenerateMock<IDice>();
            dice.Stub(x => x.Roll()).Return(STEP);
            var ladderRunningService = MockRepository.GenerateMock<ILadderRunningService>();

            var sut = new Game(board, token, dice, ladderRunningService);

            //Act
            sut.Play();

            //Arrange
            ladderRunningService.AssertWasCalled(
                x => x.Run(Arg<int>.Is.Equal(board.Squares), Arg<Token>.Is.Equal(token), Arg<int>.Is.Equal(STEP)),
                option => option.Repeat.Once());
        }
    }
}
