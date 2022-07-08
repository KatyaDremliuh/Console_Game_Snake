using System;

namespace Console_Game_Snake
{
    public class Point
    {
        private int X { get; set; }
        private int Y { get; set; }

        private char Symbol { get; set; }

        public Point(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Symbol = point.Symbol;
        }

        public void DrawPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        /// <summary>
        /// Сдвигает точку на расстояние offset по направлению direction
        /// </summary>
        /// <param name="offset">расстояние, на кот. двигать</param>
        /// <param name="direction">направление, в кот. двигать</param>
        internal void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    this.X += offset;
                    break;
                case Direction.Left:
                    this.X -= offset;
                    break;
                case Direction.Up:
                    this.Y += offset;
                    break;
                case Direction.Down:
                    this.Y -= offset;
                    break;
            }
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Symbol;
        }
    }
}