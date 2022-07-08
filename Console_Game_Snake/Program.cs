﻿using System;

namespace Console_Game_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char borderSymbolHor = '-';
            const char borderSymbolVert = '|';

            // Sets the height and the wight of the screen
            Console.SetBufferSize(220, 210);

            // Draw all borders
            HorizontalLine upLine = new HorizontalLine(10, 88, 2, borderSymbolHor);
            HorizontalLine downLine = new HorizontalLine(10, 88, 25, borderSymbolHor);
            VerticalLine leftLine = new VerticalLine(2, 25, 10, borderSymbolVert);
            VerticalLine rightLine = new VerticalLine(2, 25, 88, borderSymbolVert);

            upLine.DrawLine();
            downLine.DrawLine();
            leftLine.DrawLine();
            rightLine.DrawLine();

            Point point = new(12, 9, '&');
            point.DrawPoint();

            Console.ReadKey();
        }
    }
}