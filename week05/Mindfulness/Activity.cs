public class Activity{
    private string _name;
    private string _descripcion;
    private int _duracion;
    
    public Activity(string name, string descripcion){
        _name = name;
        _descripcion = descripcion;
    }

    public void setDuration(){
        Console.Write("How long, in seconds, would you like for your session? ");
        _duracion = int.Parse(Console.ReadLine());
    }

    public int GetDuration(){
        return _duracion;
    }

    public void DisplayStartingMessage(){
        Console.Clear();
        Console.WriteLine($"{_name}\n");
        Console.WriteLine($"{_descripcion}\n");
        setDuration();
        Console.Clear();
        Console.WriteLine("Get ready...\n");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duracion} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds){
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime){
            Console.Write(spinner[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    public void ShowCountDown(int seconds){
        for (int i = seconds; i > 0; i--){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}