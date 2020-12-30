using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var runAgain = true;
            while (runAgain)
            {
                var game = new Minesweeper(10, 10);
                var gameOver = false;
                Console.WriteLine(game.PrintMap());

                while (!gameOver)
                {
                    Console.Write("X = ");
                    int.TryParse(Console.ReadLine(), out int x);
                    x = x > 0 ? x : 1;
                    Console.Write("Y = ");
                    int.TryParse(Console.ReadLine(), out int y);
                    y = y > 0 ? y : 1;
                    gameOver = game.SelectSquare(x - 1, y - 1);
                    Console.WriteLine(game.PrintMap());
                }
                Console.WriteLine("GAME OVER\nStart new game? (Yes) = Y");
                runAgain = Console.ReadLine().ToUpper() == "Y";
            }
        }
    }
}
