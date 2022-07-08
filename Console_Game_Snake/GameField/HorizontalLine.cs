using System;
using System.Collections.Generic;

namespace Console_Game_Snake.GameField
{
    public class HorizontalLine : Figure
    {
        public HorizontalLine(double xLeft, double xRight, double oY, char symbol)
        {
            PointsList = new List<Point>();

            for (double x = xLeft; x <= xRight; x++)
            {
                Point point = new Point(x, oY, symbol);
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