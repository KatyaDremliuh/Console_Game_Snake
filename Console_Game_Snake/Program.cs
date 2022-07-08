using System;
using System.Threading;
using Console_Game_Snake.GameField;

namespace Console_Game_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wall wall = new Wall(120, 30);
            wall.Draw();

            // Draw point
            Point point = new Point(4, 5, '*');
            Snake kaa = new Snake(point, 4, Direction.Right);
            kaa.DrawLine();

            FoodCreator foodCreator = new FoodCreator(120, 30, '@');
            Point food = foodCreator.CreateFood();
            food.DrawPoint();

            while (true)
            {
                // если змейка столкнулась со стеной или со своим хвостом (то игра окончена)
                if (wall.IsHit(kaa) || kaa.IsHitTail())
                {
                    break;
                }

                // если змейка встретилась с едой
                if (kaa.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.DrawPoint();
                }
                else // если не встретилась (гуляет дальше)
                {
                    kaa.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    kaa.HandleKey(key.Key);
                }
            }
        }
    }
}