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

        public void DrawPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}
