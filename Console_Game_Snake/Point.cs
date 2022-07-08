using System;

namespace Console_Game_Snake
{
    public class Point
    {
        private double X { get; set; }
        private double Y { get; set; }
        public char Symbol { get; set; }

        public Point(double x, double y, char symbol)
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
            Console.SetCursorPosition((int)X, (int)Y);
            Console.Write(Symbol);
        }

        /// <summary>
        /// Сдвигает точку на расстояние offset по направлению direction
        /// </summary>
        /// <param name="offset">расстояние, на кот. двигать</param>
        /// <param name="direction">направление, в кот. двигать</param>
        public void Move(int offset, Direction direction)
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
                    this.Y -= offset;
                    break;
                case Direction.Down:
                    this.Y += offset;
                    break;
            }
        }

        // "затираем" предыдущее положение точки при движении змейки
        public void Clear()
        {
            Symbol = ' ';
            DrawPoint();
        }

        /// <summary>
        /// Проверяет, совпали ли координаты головы змейки с координатами еды
        /// </summary>
        /// <param name="food">координаты еды</param>
        /// <returns></returns>
        public bool IsHit(Point food)
        {
            return this.X == food.X && this.Y == food.Y;
        }
    }
}