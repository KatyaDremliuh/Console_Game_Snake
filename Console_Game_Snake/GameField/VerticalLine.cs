using System;
using System.Collections.Generic;

namespace Console_Game_Snake.GameField
{
    public class VerticalLine : Figure
    {
        public VerticalLine(double yTop, double yBottom, double oX, char symbol)
        {
            PointsList = new List<Point>();

            for (double y = yTop; y <= yBottom; y++)
            {
                Point point = new Point(oX, y, symbol);
                PointsList.Add(point);
            }
        }

        public override void DrawLine()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            base.DrawLine();

            Console.ResetColor();
        }
    }
}