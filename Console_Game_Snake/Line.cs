using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class Line
    {
        protected List<Point> PointsList;

        public void DrawLine()
        {
            foreach (Point point in PointsList)
            {
                point.DrawPoint();
            }
        }
    }
}