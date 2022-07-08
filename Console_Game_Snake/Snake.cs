using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Game_Snake
{
    public class Snake : Figure
    {
        private Direction _direction;

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

        public void HandleKey(ConsoleKey key)
        {
            _direction = key switch
            {
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
            };
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();

            // если голова змейки попала на координаты еды
            // увеличим змейку (добавить в List)
            if (head.IsHit(food))
            {
                food.Symbol = head.Symbol;
                PointsList.Add(food);
                return true;
            }

            return false;
        }
    }
}