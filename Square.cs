namespace Minesweeper
{
    internal class Square
    {
        public bool HasMine { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public string View { get; internal set; } = "-";
        public int NearByMines { get; internal set; }
    }
}