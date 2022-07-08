using System;

namespace Console_Game_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(2, 9, '%');
            point.Draw();

            Console.ReadKey();
        }
    }
}