using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class HorizontalLine
    {
        public List<Point> PointsList { get; }

        public HorizontalLine(int xLeft, int xRight, int y, char symbol)
        {
            PointsList = new List<Point>();

            for (int x = xLeft; x <= xRight; x++)
            {
                Point point = new Point(x, y, symbol);
                PointsList.Add(point);
            }
        }

        public void DrawHorizontalLine()
        {
            foreach (Point point in PointsList)
            {
                point.DrawPoint();
            }
        }
    }
}