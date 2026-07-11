using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# in 10 Minutes", "Code Guru", 600);
        video1.AddComment(new Comment("Alice", "This was nice, thank you!"));
        video1.AddComment(new Comment("Bob", "Clear and good explanation"));
        video1.AddComment(new Comment("Charlie", "Can you do a tuturial on python next?"));
        videos.Add(video1);

        Video video2 = new Video("How to Get Jacked Quick", "Cool Gyms", 1200);
        video2.AddComment(new Comment("Dave", "Awesome! my muscles grew instantly!"));
        video2.AddComment(new Comment("Emma", "Where did you get that weight bench?"));
        video2.AddComment(new Comment("Frank", "Great tips on the workouts"));
        videos.Add(video2);

        Video video3 = new Video("How to Play piano in 2 minutes", "Mustard and music", 900);
        video3.AddComment(new Comment("Grace", "Worst tutorial ever! I still can't play :| "));
        video3.AddComment(new Comment("Hank", "Subscribed. Best tutorial by far."));
        video3.AddComment(new Comment("Ivy", "I've been trying piano for weeks, this helped so much."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine(); 
        }
    }
}
