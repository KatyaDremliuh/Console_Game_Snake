﻿using System.Collections.Generic;
using System.Linq;

namespace Console_Game_Snake
{
    public class Snake : Figure
    {
        private readonly Direction _direction;

        // tail - координаты хвостика
        public Snake(Point tail, int snakeLength, Direction direction)
        {
            this._direction = direction;
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

        public void Move()
        {
            Point tail = PointsList.First(); // First() возвращает первый эл-т списка точек "змейка"
            PointsList.Remove(tail);

            Point head = GetNextPoint();
            PointsList.Add(head);

            tail.Clear(); // "затираем" предыдущее положение точки (хвоста) при движении змейки
            head.DrawPoint();
        }

        private Point GetNextPoint()
        {
            Point head = PointsList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, _direction); // новое положение головы
            return nextPoint;
        }
    }
}