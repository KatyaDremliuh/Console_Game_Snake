using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class Figure
    {
        public List<Point> PointsList;

        // метод DrawLine виртуальный (любой наследник от Figure может метод переопределить (написать свою реализацию метода))
        public virtual void DrawLine()
        {
            foreach (Point point in PointsList)
            {
                point.DrawPoint();
            }
        }

        // пересекается ли переданная фигура с какой-л. точкой другой фируры
        public bool IsHit(Figure figure)
        {
            foreach (var point in PointsList)
            {
                if (figure.IsHit(point))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHit(Point point)
        {
            foreach (var p in PointsList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }
            }

            return false;
        }
    }
}