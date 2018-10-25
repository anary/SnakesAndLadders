using System;
using SnakesAndLadders.Business;
using SnakesAndLadders.Business.Services;
using SnakesAndLadders.Core.Entities;

namespace SnakesAndLadders.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board { Squares = 10 };
            var dice = new Dice();
            var token = new Token() { Name = "Player1" };
            var ladderRunningService = new LadderRunningService();
            var game = new Game(board, token, dice, ladderRunningService);

            InteractToPlayGame(game, token);

            System.Console.ReadLine();
        }

        private static void InteractToPlayGame(Game game, Token token)
        {
            System.Console.WriteLine("Please input player name:");
            token.Name = System.Console.ReadLine();

            System.Console.WriteLine("Please press any key to start and press Escape to stop the game");

            while (!(System.Console.KeyAvailable && System.Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                System.Console.ReadKey();
                game.Play();
                System.Console.WriteLine($"Game result: {token.Result}");
                System.Console.WriteLine($"Player {token.Name} current position:{token.CurrentPosition}");
                System.Console.WriteLine("please any key to continue.");

                if (token.Result != true) continue;
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Congratulation! {token.Name} Win!");

                break;
            }
        }
    }
}
