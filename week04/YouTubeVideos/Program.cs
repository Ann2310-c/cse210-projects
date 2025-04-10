using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("The trip to the moon", "Karol Hanks", 300);
        //form1
        Comment comment1 =new Comment("Juan", "What a great video!");
        video1.AddComment(comment1);
        //form2
        video1.AddComment(new Comment("Luisa", "I loved the final part"));
        video1.AddComment(new Comment("Carlos", "Good edition"));
        videos.Add(video1);

        Video video2 = new Video("How to make desserts", "Carlos Torres", 600);
        video2.AddComment(new Comment("María", "Delicious!"));
        video2.AddComment(new Comment("Pedro", "I'm going to try the recipe"));
        video2.AddComment(new Comment("Sofía", "Make more videos like this"));
        videos.Add(video2);

        Video video3 = new Video("Programming tutorial", "Ana Dev", 450);
        video3.AddComment(new Comment("Erick", "Very clear everything"));
        video3.AddComment(new Comment("Dani", "Thanks for sharing"));
        video3.AddComment(new Comment("Lina", "Excellent explanation"));
        videos.Add(video3);

        // display the information
        foreach (Video video in videos){
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}