﻿using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class HorizontalLine : Line
    {
        public List<Point> PointsList { get; }

        public HorizontalLine(int xLeft, int xRight, int oY, char symbol)
        {
            PointsList = new List<Point>();

            for (int x = xLeft; x <= xRight; x++)
            {
                Point point = new Point(x, oY, symbol);
                PointsList.Add(point);
            }
        }
    }
}