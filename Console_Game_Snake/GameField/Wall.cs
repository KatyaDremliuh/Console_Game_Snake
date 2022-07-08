using System;
using System.Collections.Generic;

namespace Console_Game_Snake.GameField
{
    public class Wall
    {
        private List<Figure> _wallsList;
        private const char BorderSymbolHor = '-';
        private const char BorderSymbolVert = '|';

        // принимает габариты экрана
        public Wall(double mapWidth, double mapHeight)
        {
            _wallsList = new List<Figure>();

            // Draw all borders
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, BorderSymbolHor);
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, BorderSymbolHor);
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, BorderSymbolVert);
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, BorderSymbolVert);

            _wallsList.Add(upLine);
            _wallsList.Add(downLine);
            _wallsList.Add(leftLine);
            _wallsList.Add(rightLine);
        }

        // есть ли пересечения у змейки и стены (врезалась в стену)
        public bool IsHit(Figure figure)
        {
            foreach (var wall in _wallsList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach (var wall in _wallsList)
            {
                wall.DrawLine();
            }

            Console.ResetColor();
        }
    }
}