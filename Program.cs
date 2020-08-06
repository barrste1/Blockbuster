using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08042020_BlockbusterLab
{
    class Program
    {
        static void Main(string[] args)
        {
            #region StartingVariables

            Blockbuster buster = new Blockbuster();
            bool end = false;
            int playOption = 0;
            #endregion  

            while (!end)
            {
                //film selection is the movie the user has chosen
                List<MoviesAbstract> filmSelection = new List<MoviesAbstract>();

                filmSelection.Add(buster.CheckOut());
                Console.Clear();

                #region Playing the Movie
                while (true)
                {
                    playOption = ValidatePlayOption("Press 1 if you would like to play the whole movie or 2 if you want to play scene by scene!");
                    Console.Clear();

                    if (playOption == 1)
                    {
                        filmSelection[0].PlayAll();
                    }
                    else if (playOption == 2)
                    {
                        filmSelection[0].Play();
                    }

                    filmSelection.Clear();

                    Console.Clear();

                    if(ValidateYesNo("Would you like to watch another movie?"))
                    {
                        break;
                    }
                    else
                    {
                        PrintGreen("Ok! Bye!");
                        end = true;
                        break;
                    }

                }
                #endregion

                

            }

        }
        public static bool LoopProgram(string message)
        {
            bool end = false;
            string cont = "";
            Console.WriteLine(message);
            while (cont.ToLower() != "n")
            {
                cont = Console.ReadLine().ToLower();
                if (cont == "y")
                {
                    end = false;
                    break;
                }
                else if (cont == "n")
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter (y) to square/cube a number and (n) to stop.");
                }
            }
            return end;
        }
        public static void PrintGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
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
        public static int ValidatePlayOption(string message)
        {
            int intInput = 0;
            Regex regex = new Regex("^[12]{1}$");
            string input = GetInput(message);
            while (!regex.IsMatch(input))
            {
                input = GetInput(message);
                int.TryParse(input, out intInput);
            }
            intInput = int.Parse(input);
            return intInput;
        }
        public static bool ValidateYesNo(string message)
        {
            string input="";
            input = GetInput(message);
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
    }
}
