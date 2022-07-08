using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class VerticalLine : Figure
    {
        public VerticalLine(int yTop, int yBottom, int oX, char symbol)
        {
            PointsList = new List<Point>();

            for (int y = yTop; y <= yBottom; y++)
            {
                Point point = new Point(oX, y, symbol);
                PointsList.Add(point);
            }
        }
    }
}