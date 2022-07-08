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

            upLine.DrawLine();
            downLine.DrawLine();
            leftLine.DrawLine();
            rightLine.DrawLine();

            Point point = new(12, 9, '*');
            Snake kaa = new Snake(point, 4, Direction.Right);
            kaa.DrawLine();
            kaa.Move();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    kaa.HandleKey(key.Key);
                }

                Thread.Sleep(100);
                kaa.Move();
            }
        }
    }
}