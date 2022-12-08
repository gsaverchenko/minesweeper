namespace Minesweeper
{
    public class Game
    {
        private List<Square> _map;
        private int _totalMines;
        private int _remainingSquares;
        private readonly int _width;
        private readonly int _height;
        private readonly int _totalSquares;

        public bool GameOver { get; set; }
        public bool YouWon { get; set; }

        public Game(int width, int height)
        {
            _totalMines = 0;
            _width = width;
            _height = height;
            _remainingSquares = _totalSquares = _width * _height;
            _map = new List<Square> { };
            GameOver = false;
            YouWon = false;

            FillMapWithMines();
            CalculateMapSquares();
        }

        public void SelectSquare(int selectedX, int selectedY)
        {
            var square = _map.FirstOrDefault(
                s => s.X == selectedX && s.Y == selectedY);

            if (square != default)
            {
                if (square.HasMine)
                {
                    foreach (var mine in _map.Where(x => x.HasMine))
                    { mine.View = "*"; }
                    square.View = "X";
                }
                else if (square.NearByMines == 0)
                {
                    square.View = " ";

                    var nearSquares = _map.Where(
                        s => Math.Abs(s.X - selectedX) <= 1
                        && Math.Abs(s.Y - selectedY) <= 1 && s.View == "-"
                        && (s.X != selectedX || s.Y != selectedY));
                    foreach (var near in nearSquares)
                    { SelectSquare(near.X, near.Y); }
                }
                else
                { square.View = $"{square.NearByMines}"; }

                GameOver = square.HasMine;
                _remainingSquares = _map.Count(x => x.View == "-");
                if (_remainingSquares == _totalMines) { GameOver = YouWon = true; }
            }
        }

        public string PrintMap()
        {
            var mapPrint = string.Empty.PadRight(4);
            for (int y = 1; y <= _width; y++)
            {
                mapPrint += $"{y}".PadRight(3);
            }

            mapPrint += "Y\n".PadLeft(3);

            for (int x = 0; x < _height; x++)
            {
                var padX = $"{x + 1}".PadRight(3);
                mapPrint += $"{padX}|";
                for (int y = 0; y < _width; y++)
                {
                    var square = _map.FirstOrDefault(
                        m => m.X == x && m.Y == y)?.View;
                    mapPrint += $"[{square}]";
                }
                mapPrint += "|\n";
            }

            mapPrint += "X\n";
            mapPrint += $"Total mines = {_totalMines}\n";
            mapPrint += $"Remaining squares = {_remainingSquares}";

            return mapPrint;
        }

        private void FillMapWithMines()
        {
            var random = new Random { };
            var difficulty = _totalSquares / 20;
            foreach (int i in Enumerable.Range(0, _totalSquares))
            {
                var newSquare = new Square
                {
                    HasMine = random.Next(difficulty) == 1,
                    X = i % _width,
                    Y = (int)i / _width
                };
                if (newSquare.HasMine) { _totalMines++; }
                _map.Add(newSquare);
            }
        }

        private void CalculateMapSquares()
        {
            _map.ForEach(square =>
            {
                // Not the most efficient way to count nearby mines.
                // A better way would be to return 8 surounding squares and add up mines.
                square.NearByMines = _map.Count(
                    mine => mine.HasMine
                    && Math.Abs(square.X - mine.X) <= 1
                    && Math.Abs(square.Y - mine.Y) <= 1);
            });
        }
    }
}