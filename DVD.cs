using System;
using System.Collections.Generic;
using System.Text;

namespace _08042020_BlockbusterLab
{
    class DVD : MoviesAbstract
    {

        public DVD() { }
        public DVD(string Title, Genres Categoy, int RunTime, List<string> Scenes) : base(Title, Categoy, RunTime, Scenes) { }
        
        #region Play Methods
        public override void PlayAll()
        {
            int input = -1;
            PrintGreen("Scenes:");
            base.PrintScenes();
            
            PrintGreen($"Which Scene do you want to start watching from (0-{Scenes.Count-1})?");
            
            while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > Scenes.Count - 1)
            {
                PrintGreen($"Please select the scene you would like to start from (0-{Scenes.Count - 1}).");
            }

            for (int i=input;i<Scenes.Count;i++)
            {
                PrintYellow(Scenes[i]);
            }

        }
        public override void Play()
        {
            bool end = false;
            int input = -1;

            PrintGreen("Scenes:");
            base.PrintScenes();
            PrintGreen($"Which Scene do you want to watch (0-{Scenes.Count-1})?");

            while (!int.TryParse(Console.ReadLine(),out input)||input<0||input>Scenes.Count-1)
            {
                PrintGreen($"Please select the scene you would like to watch (0-{Scenes.Count-1}).");
            }

            while (input<Scenes.Count)
            {
                PrintYellow(Scenes[input]);
                input++;

                end = ValidateYesNo("Do you want to watch the next scene?");
                if (end)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

        }
        #endregion

        public static void PrintGreen(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintYellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string GetInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            return input;
        }
        public static bool ValidateYesNo(string message)
        {
            string input = GetInput(message);
            bool yesNo = false;

            while (!yesNo)
            {
                if (input.ToLower() == "y")
                {
                    return !yesNo;
                }
                else if (input.ToLower() == "n")
                {
                    Console.Clear();
                    return yesNo;
                }
                else
                {
                    input = GetInput("Please enter  \"y\" for yes or \"n\" for no.");
                }
            }
            return yesNo;
        }
    }
}
