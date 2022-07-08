using System;

namespace Console_Game_Snake
{
    public class FoodCreator
    {
        private int MapWidth { get; }
        private int MapHeight { get; }
        private char SymbolFood { get; }

        private readonly Random _random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char symbolFood)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            SymbolFood = symbolFood;
        }

        public Point CreateFood()
        {
            int oX = _random.Next(2, MapWidth - 2);
            int oY = _random.Next(2, MapHeight - 2);

            return new Point(oX, oY, SymbolFood);
        }
    }
}