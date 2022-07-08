using System;

namespace Console_Game_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(2, 9, '%');
            point.DrawPoint();

            HorizontalLine horizontal = new HorizontalLine(53, 71, 16, '&');
            horizontal.DrawHorizontalLine();

            VerticalLine verticalLine = new(12, 43, 9, '!');
            verticalLine.DrawVerticalLine();

            Console.ReadKey();
        }
    }
}