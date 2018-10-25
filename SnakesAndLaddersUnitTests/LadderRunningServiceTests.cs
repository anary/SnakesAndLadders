using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Business.Services;
using SnakesAndLadders.Core.Entities;

namespace SnakesAndLaddersUnitTests
{
    [TestClass]
    public class LadderRunningServiceTests
    {
        private const int SQUARE = 10;
        const int CURRENT_POSITION = 5;

        [TestMethod]
        public void LadderRunningService_Run_IfsquareIs10TokenIn5AndStepIs5_ShouldReturnTokenWithWinResult()
        {
            //Arrange
            const int ROLL_STEP = 5;

            var sut = new LadderRunningService();
            var token = new Token { CurrentPosition = CURRENT_POSITION, Result = false };

            //Act
            sut.Run(SQUARE, token, ROLL_STEP);

            //Assert
            Assert.IsTrue(token.Result);
            Assert.AreEqual(SQUARE, token.CurrentPosition);
        }

        [TestMethod]
        public void LadderRunningService_Run_IfsquareIs10TokenIn5AndStepIs4Then1_ShouldReturnTokenWithWinResult()
        {
            //Arrange
            const int ROLL_STEP1 = 4;
            const int ROLL_STEP2 = 1;

            var sut = new LadderRunningService();
            var token = new Token { CurrentPosition = CURRENT_POSITION, Result = false };

            sut.Run(SQUARE, token, ROLL_STEP1);
            Assert.IsFalse(token.Result);

            //Act
            sut.Run(SQUARE, token, ROLL_STEP2);

            //Assert
            Assert.IsTrue(token.Result);
            Assert.AreEqual(SQUARE, token.CurrentPosition);
        }

        [TestMethod]
        public void LadderRunningService_Run_IfsquareIs10TokenIn5AndStepIs4_ShouldReturnNotWinResult()
        {
            //Arrange
            const int ROLL_STEP = 4;

            var sut = new LadderRunningService();
            var token = new Token { CurrentPosition = CURRENT_POSITION, Result = false };

            //Act
            sut.Run(SQUARE, token, ROLL_STEP);

            //Assert
            Assert.IsFalse(token.Result);
            Assert.AreEqual(CURRENT_POSITION + ROLL_STEP, token.CurrentPosition);
        }

        [TestMethod]
        public void LadderRunningService_Run_IfsquareIs10TokenIn5AndStepIs6_ShouldReturnNotWinResult()
        {
            //Arrange
            const int ROLL_STEP1 = 4;
            const int ROLL_STEP2 = 6;

            var sut = new LadderRunningService();
            var token = new Token { CurrentPosition = CURRENT_POSITION, Result = false };

            sut.Run(SQUARE, token, ROLL_STEP1);
            Assert.IsFalse(token.Result);

            //Act
            sut.Run(SQUARE, token, ROLL_STEP2);

            //Assert
            Assert.IsFalse(token.Result);
            Assert.AreEqual(CURRENT_POSITION + ROLL_STEP1, token.CurrentPosition);
        }
    }
}
