using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Minesweeper
    {
        private List<Square> _map;
        private readonly int _width;
        private readonly int _height;
        private readonly int _totalSquares;

        public Minesweeper(int width, int height)
        {
            _width = width;
            _height = height;
            _totalSquares = _width * _height;
            _map = new List<Square> { };
            FillMapWithMines();
            CalculateMapSquares();
        }

        public bool SelectSquare(int selectedX, int selectedY)
        {
            var square = _map.FirstOrDefault(
                s => s.X == selectedX && s.Y == selectedY);
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

            return square.HasMine;
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
                        m => m.X == x && m.Y == y).View;
                    mapPrint += $"[{square}]";
                }
                mapPrint += "|\n";
            }

            mapPrint += "X\n";

            return mapPrint;
        }

        private void FillMapWithMines()
        {
            var random = new Random { };
            var difficulty = _totalSquares / 20;
            foreach (int i in Enumerable.Range(0, _totalSquares))
            {
                _map.Add(new Square
                {
                    HasMine = random.Next(difficulty) == 1,
                    X = i % _width,
                    Y = (int)i / _width
                });
            }
        }

        private void CalculateMapSquares()
        {
            _map.ForEach(square =>
            {
                square.NearByMines = _map.Count(
                    x => x.HasMine
                    && Math.Abs(square.X - x.X) <= 1
                    && Math.Abs(square.Y - x.Y) <= 1);
            });
        }
    }
}