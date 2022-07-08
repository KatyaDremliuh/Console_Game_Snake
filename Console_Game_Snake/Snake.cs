using System.Collections.Generic;

namespace Console_Game_Snake
{
    public class Snake : Figure
    {
        // tail - координаты хвостика
        public Snake(Point tail, int snakeLength, Direction direction)
        {
            PointsList = new List<Point>();

            for (int i = 0; i < snakeLength; i++)
            {
                // создаю нужное кол-во точек (длина змейки).
                // Двигаю след. точку на позицию i в направлении directionю
                // Добавляю в список
                Point point = new Point(tail);
                point.Move(i, direction);
                PointsList.Add(point);
            }
        }
    }
}