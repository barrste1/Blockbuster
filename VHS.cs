using System;
using System.Collections.Generic;
using System.Text;

namespace _08042020_BlockbusterLab
{
    class VHS : MoviesAbstract
    {
        public int CurrentTime { get; set; }
        public VHS() { }
        public VHS(string Name,Genres Categoy, int RunTime,List<string> Scenes, int CurrentTime) : base(Name, Categoy, RunTime, Scenes)
        {
            this.CurrentTime = CurrentTime;
        }
        public override void Play()
        {
            while (true)
            {
                PrintYellow(Scenes[CurrentTime]);
                CurrentTime++;

                if(ValidateYesNo("Would you like to watch the next scene? y/n"))
                {
                    continue;
                }
                else
                {
                    break;
                }

            }
            if (ValidateYesNo("Would you like to rewind? (y/n)"))
            {
                Rewind();
            }

                
        }
        public void Rewind()
        {
            CurrentTime = 0;
        }

        public override void PlayAll()
        {
            for (int i = CurrentTime;i<Scenes.Count;i++)
            {
                PrintYellow(Scenes[i]);
            }
            if (ValidateYesNo("Would you like to rewind? (y/n)"))
            {
                Rewind();
            }

        }
        public static bool ValidateYesNo(string message)
        {
            string input = GetInput(message);
            bool end = false;
            while (!end)
            {
                if (input.ToLower() == "y")
                {
                    return !end;
                }
                else if (input.ToLower() == "n")
                {
                    Console.Clear();
                    return end;
                }
                else
                {
                    input = GetInput("Please enter  \"y\" for yes or \"n\" for no.");
                }
            }
            return end;
        }
        public static string GetInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            return input;
        }
        public static void PrintYellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
