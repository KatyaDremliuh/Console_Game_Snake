using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class VerticalLine
    {
        public List<Point> PointsList { get; }

        public VerticalLine(int yTop, int yBottom, int x, char symbol)
        {
            PointsList = new List<Point>();

            for (int y = yTop; y <= yBottom; y++)
            {
                Point point = new Point(y, y, symbol);
                PointsList.Add(point);
            }
        }

        public void DrawVerticalLine()
        {
            foreach (Point point in PointsList)
            {
                point.DrawPoint();
            }
        }
    }
}
