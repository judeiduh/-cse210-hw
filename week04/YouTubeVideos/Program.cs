using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Cool Science Facts", "SmartNerd", 300);
        video1.AddComment(new Comment("Alice", "Wow! I learned so much."));
        video1.AddComment(new Comment("Bob", "This is so cool!"));
        video1.AddComment(new Comment("Charlie", "Loved the visuals."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Guitar Basics", "MusicMaster", 450);
        video2.AddComment(new Comment("Daisy", "Helped me a lot, thanks!"));
        video2.AddComment(new Comment("Ethan", "Great explanation."));
        video2.AddComment(new Comment("Fiona", "I want more lessons like this."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Travel Destinations", "Wanderlust", 600);
        video3.AddComment(new Comment("George", "Adding these to my bucket list."));
        video3.AddComment(new Comment("Hannah", "Can’t wait to travel again!"));
        video3.AddComment(new Comment("Ian", "Nice editing and info."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Healthy Eating Tips", "FitLife", 400);
        video4.AddComment(new Comment("Jill", "Super helpful tips!"));
        video4.AddComment(new Comment("Kyle", "Trying this starting tomorrow."));
        video4.AddComment(new Comment("Liam", "More of this content please!"));
        videos.Add(video4);

        // Display info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine(); // Add a blank line between videos
        }
    }
}
