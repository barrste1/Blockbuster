using System;
using System.Collections.Generic;
using System.Text;

namespace _08042020_BlockbusterLab
{
    abstract class MoviesAbstract
    {
      
        public string Title { get; set; }
        public Genres Category { get; set; }
        public int RunTime { get; set; }
        public List<string> Scenes { get; set; }

        public MoviesAbstract() { }
        public MoviesAbstract(string Title, Genres Category, int RunTime,List<string> Scenes)
        {
            this.Title = Title; this.Category = Category; this.RunTime = RunTime; this.Scenes = Scenes;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Category}");
            Console.WriteLine($"Runtime: {RunTime} minutes");
            Console.WriteLine("");
        }
        public virtual void PrintScenes()
        {
            for (int i =0; i < Scenes.Count; i++)
            {
                Console.WriteLine($"{i} {Scenes[i]}");
            }
        }
        public abstract void Play();
        public abstract void PlayAll();
    }
}
