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

        public string SelectSquare(int x, int y)
        {
            return _map.FirstOrDefault(
                m => m.X == x && m.Y == y).HasMine ? "BOOM!" : "Clear";
        }

        public string PrintMap()
        {
            return _map.ToString();
        }

        private void FillMapWithMines()
        {
            var random = new Random { };
            var difficulty = _totalSquares / 10;
            foreach (int i in Enumerable.Range(1, _totalSquares))
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
        }
    }
}