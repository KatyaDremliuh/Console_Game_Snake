using System.Collections.Generic;

namespace Console_Game_Snake.GameField
{
    public class HorizontalLine : Figure
    {
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