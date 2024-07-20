using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation1 World!");

        List<Video> videos = new List<Video>();

        // Create videos
        Video video1 = new Video("Abstraction in a nutshell", "Frank Ocean", 318);
        video1.AddComment(new Comment("Cris456", "Gr8 explanation!"));
        video1.AddComment(new Comment("Bobimen", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charliebrown45", "I learned a lot from this video, lol."));

        Video video2 = new Video("Encapsulation in OOP", "Carol Danvers", 450);
        video2.AddComment(new Comment("Dave879", "This is what I needed."));
        video2.AddComment(new Comment("Mistic786", "Loved the explanation."));
        video2.AddComment(new Comment("Fornite753", "Where can I find more examples?"));

        Video video3 = new Video("Polymorphism and Inheritance", "Mr. Teacher", 521);
        video3.AddComment(new Comment("Thorodin", "Fantastic video!"));
        video3.AddComment(new Comment("TobyTheCreator78", "Easy to understand."));
        video3.AddComment(new Comment("Pampers", "I am ready to take my quiz."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display each video and its comments
        foreach (var video in videos)
        {
            video.Display();
        }
    }
}

public class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; } // in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
        Console.WriteLine();
    }
}
