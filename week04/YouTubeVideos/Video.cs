public class Video{
    private string _title; //video title
    private string _author; //video author
    private int _length; //Video length in seconds
    private List<Comment> _comments = new List<Comment>(); //comments list

    //constructor
    public Video(string title, string author, int length){
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment){
        _comments.Add(comment);
    }

    public int GetCommentCount(){
        return _comments.Count;
    }

    public void DisplayVideoInfo(){
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length}");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");

        foreach (Comment comment in _comments){
            Console.WriteLine($" - {comment.GetName()}: {comment.GetText()}");
        }
    }
}