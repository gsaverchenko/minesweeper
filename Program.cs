using Minesweeper;

var runAgain = true;
while (runAgain)
{
    var game = new Game(15, 15);
    Console.WriteLine(game.PrintMap());

    while (!game.GameOver)
    {
        Console.Write("X = ");
        int.TryParse(Console.ReadLine(), out int x);
        x = x > 0 ? x : 1;
        Console.Write("Y = ");
        int.TryParse(Console.ReadLine(), out int y);
        y = y > 0 ? y : 1;
        game.SelectSquare(x - 1, y - 1);
        Console.WriteLine(game.PrintMap());
    }
    var message = game.YouWon ? "YOU WON" : "GAME OVER";
    Console.WriteLine($"{message}\nStart new game? (Yes) = Y");
    runAgain = Console.ReadLine()?.ToUpper() == "Y";
}
