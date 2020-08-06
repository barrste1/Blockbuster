using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _08042020_BlockbusterLab
{
    class Blockbuster
    {

        public List<MoviesAbstract> Movies = new List<MoviesAbstract>
        {
            new DVD("Brendan Frasier is Cool",Genres.Action,260,new List<string>{"begin","goobis","end" }),
            new VHS("Saw: She Saws Sea-Saws by the Sheep's Aww",Genres.Horror,90, new List<string>{"Title","scary stuff","But it's at the ocean this time, get it?","Like, seasaw. See-saw. Get it?","Water you talking about? This is easy stuff!!!","Stop being so salty, this is easy. Seesaw. Sea Saw. It's all about a stupid pun","torture","Guess it made your life better?","end" },0 ),
            new VHS("My Shrek Foot, Tape 1",Genres.Drama,150, new List<string>{"Title","My Dreams, Muh Swamp","The Good Times","Buying Oates","Donkey's Oatey, Windmill","A Green Toe","Somebody once Told me, your foot would turn to Shrek","Surgery Without the Sharpest Tool in the Shed","My Dreams, Muh Swamp, Gone","Monologue about hope and stuff","Please insert tape 2"},0 ),
            new VHS("My Shrek Foot, Tape 2",Genres.Action,170, new List<string>{"Moving to U of M","My Dream, Muh Swamp, Reprise","Going to the Far Quad","Kick Ass and Chew Oates","All out of Donkey","Cart Chase 1","Puss in Boots Fencing","Cart Chase 2","30 minutes of Karaoke","Final Fight","Shrek: Ending it All","End Credits with happy pop song" },0 ),
            new DVD("When Hairy Met Taily: Dog's in Love",Genres.Romance,90,new List<string>{"Title","Begining of our Tail","A Lick of Danger","Meet Cute","What a treat","A walk to remember","Love at first Bite","Stupid scene where simple communication would solve a problem but we need 20 more minutes tacked onto the film","Paws for reflections","Sit! Stay! Go get em!","Chase through the Park","They're both good Bois","end" }),
            new DVD("Anna's 12",Genres.Action,100,new List<string>{"Title","Out of Prison","Where am I going to get 11 people?","Coding Bootcamp","There's 11 students in bootcamp","Teaching hacking I mean coding","Wait, Tommy's FBI??","Deploy Scripts","Bank Rob Scene","Cool stuff happens","Anna escapes to Belize","end" })
        };

        public void PrintMovies()
        {
            for (int i = 0; i < Movies.Count; i++)
            {
                Console.WriteLine($"{i + 1} {Movies[i].Title}");
            }

        }
        public MoviesAbstract CheckOut()
        {
            int selection=-1;
            bool watch = false;

            while (!watch)
            {
                selection = -1;
                PrintGreen("Welcome to Blockbuster, Home of the Block, buster!!");
                PrintGreen("Please check out our selection below:");
                PrintMovies();
                PrintGreen("What movie do you want?");

                //while loop to ensure that the number entered is in range
                while (selection < 1 || selection > Movies.Count)
                {
                    PrintGreen($"Please input a number that corresponds to your selection (1 - {Movies.Count}).");
                    int.TryParse(Console.ReadLine(), out selection);
                    continue;
                }

                Console.Clear();
                
                //Displays movie info. If the info is a turn off to user, they can select another movie
                Movies[selection - 1].PrintInfo();
                watch = ValidateYesNo(GetInput("Do you want to Rent this movie? (y/n)"));

            }


            return Movies[selection-1];
        }
        public static void PrintGreen(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string GetInput(string message)
        {
            PrintGreen(message);
            string input = Console.ReadLine();
            return input;
        }
        public static bool ValidateYesNo(string message)
        { bool input = false;
            while (!input)
            {
                if (message.ToLower() == "y")
                {
                    return !input;
                }
                else if (message.ToLower() == "n")
                {
                    Console.Clear();
                    return input;
                }
                else
                {
                    message = GetInput("Please enter  \"y\" for yes or \"n\" for no.");
                }
            }
            return input;
        }
    }
}
