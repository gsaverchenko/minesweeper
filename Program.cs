using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Minesweeper(10, 10);
            Console.WriteLine("1,0" + game.SelectSquare(1,0));
            Console.WriteLine("1,1" + game.SelectSquare(1,1));
            Console.WriteLine("1,2" + game.SelectSquare(1,2));
            Console.WriteLine("1,3" + game.SelectSquare(1,3));
            Console.WriteLine("1,4" + game.SelectSquare(1,4));
            Console.WriteLine("1,5" + game.SelectSquare(1,5));
            Console.WriteLine("1,6" + game.SelectSquare(1,6));
            Console.WriteLine("1,7" + game.SelectSquare(1,7));
            Console.WriteLine("1,8" + game.SelectSquare(1,8));
            Console.WriteLine("1,9" + game.SelectSquare(1,9));
            Console.WriteLine("2,0" + game.SelectSquare(2,0));
            Console.WriteLine("2,1" + game.SelectSquare(2,1));
            Console.WriteLine("2,2" + game.SelectSquare(2,2));
            Console.WriteLine("2,3" + game.SelectSquare(2,3));
            Console.WriteLine(game.SelectSquare(2,4));
            Console.WriteLine(game.SelectSquare(2,5));
            Console.WriteLine(game.SelectSquare(2,6));
            Console.WriteLine(game.SelectSquare(2,7));
            Console.WriteLine(game.SelectSquare(2,8));
            Console.WriteLine(game.SelectSquare(2,9));
            Console.WriteLine(game.SelectSquare(3,0));
            Console.WriteLine(game.SelectSquare(3,1));
            Console.WriteLine(game.SelectSquare(3,2));
            Console.WriteLine(game.SelectSquare(3,3));
            Console.WriteLine(game.SelectSquare(3,4));
            Console.WriteLine(game.SelectSquare(3,5));
            Console.WriteLine(game.SelectSquare(3,6));
            Console.WriteLine(game.SelectSquare(3,7));
            Console.WriteLine(game.SelectSquare(3,8));
            Console.WriteLine(game.SelectSquare(3,9));
            Console.ReadLine();
        }
    }
}
