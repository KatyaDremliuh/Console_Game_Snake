using System;
using System.Threading;
using Console_Game_Snake.GameField;

namespace Console_Game_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char borderSymbolHor = '-';
            const char borderSymbolVert = '|';

            // Sets the height and the wight of the screen
            Console.SetBufferSize(120, 30);

            // Draw all borders
            HorizontalLine upLine = new HorizontalLine(10, 88, 2, borderSymbolHor);
            HorizontalLine downLine = new HorizontalLine(10, 88, 25, borderSymbolHor);
            VerticalLine leftLine = new VerticalLine(2, 25, 10, borderSymbolVert);
            VerticalLine rightLine = new VerticalLine(2, 25, 88, borderSymbolVert);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            upLine.DrawLine();
            downLine.DrawLine();
            leftLine.DrawLine();
            rightLine.DrawLine();
            Console.ResetColor();

            // Draw point
            Point point = new(12, 9, '*');
            Snake kaa = new Snake(point, 4, Direction.Right);
            kaa.DrawLine();

            FoodCreator foodCreator = new FoodCreator(120, 30, '@');
            Point food = foodCreator.CreateFood();
            food.DrawPoint();

            while (true)
            {
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