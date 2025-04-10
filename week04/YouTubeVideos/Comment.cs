public class Comment{
    private string _name;
    private string _text;

    //constructor
    public Comment(string name, string text){
        _name = name;
        _text = text;
    }

    public string GetName(){
        return _name; //return the value in _name
    }

    public void SetName(string value){
        _name = value; //change the _name value
    }

    public string GetText(){
        return _text;
    }

    public void SetText(string value){
        _text = value;
    }
}