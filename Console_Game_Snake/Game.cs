using System;
using System.Text;
using System.Threading;
using Console_Game_Snake.GameField;

namespace Console_Game_Snake
{
    public class Game
    {
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private static bool _isRunning = true;

        private static readonly int _mapWidth = Console.BufferWidth / 2; // 120
        private static readonly int _mapHeight = Console.BufferHeight / 2; // 30

        private static readonly Tuple<string, Action<string>>[] _commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("play", Play),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen.",},
            new string[] { "exit", "exits the application", "The 'exit' command exits the application.",},
            new string[] { "play", "starts the game", "The 'play' command starts the game.",},
        };

        public void ChooseCommand()
        {
            Console.WriteLine("Hello");

            do
            {
                Console.WriteLine(HintMessage);
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(HintMessage);
                    continue;
                }

                var index = Array.FindIndex(_commands, 0, _commands.Length, i
                    => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    _commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (_isRunning);

            Console.WriteLine(HintMessage);
            Console.WriteLine();
        }


        private static void Play(string command)
        {
            Console.Clear(); // очистим консоль перед игрой
            Console.OutputEncoding = Encoding.Unicode;
            char symbolFood = Convert.ToChar("\u263A");

            Wall walls = new Wall(_mapWidth, _mapHeight); // 120/30
            walls.Draw();

            // Draw point
            Point point = new Point(4, 5, '#');
            Snake kaa = new Snake(point, 4, Direction.Right);
            kaa.DrawLine();

            FoodCreator foodCreator = new FoodCreator(_mapWidth, _mapHeight, symbolFood);
            Point food = foodCreator.CreateFood();
            Console.ForegroundColor = ConsoleColor.Red;
            food.DrawPoint();
            Console.ResetColor();

            int score = 0;

            while (true)
            {
                // если змейка столкнулась со стеной или со своим хвостом (то игра окончена)
                if (walls.IsHit(kaa) || kaa.IsHitTail())
                {
                    string messageScore = "YOUR SCORE IS: ";
                    Console.SetCursorPosition((_mapWidth - (messageScore.Length + score.ToString().Length)) / 2, _mapHeight / 2 - 4);
                    Console.WriteLine(messageScore + score);
                    PrintGameOver();
                    break;
                }

                // если змейка встретилась с едой
                if (kaa.Eat(food))
                {
                    score++;
                    food = foodCreator.CreateFood();
                    Console.ForegroundColor = ConsoleColor.Red;
                    food.DrawPoint();
                    Console.ResetColor();
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

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i
                    => string.Equals(i[CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[CommandHelpIndex], helpMessage[DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            _isRunning = false;
        }

        private static void PrintGameOver()
        {
            string[] words = new[]
            {
                "================================",
                "        G A M E  O V E R",
                "================================"
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            int oYposition = _mapHeight / 2 - 2;

            foreach (var word in words)
            {
                Console.SetCursorPosition((_mapWidth - words[0].Length) / 2, oYposition);
                Console.WriteLine(word);
                oYposition++;
            }

            Console.SetCursorPosition(0, _mapHeight + 2);
        }
    }
}