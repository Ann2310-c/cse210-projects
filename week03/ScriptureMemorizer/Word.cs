class Word
{
    private string _text;
    private bool _isHidden;

    //constructor
    public Word(string text){
        _text = text;
        _isHidden = false;
    }

    //methods
    public void Hide(){ //hide words
        _isHidden = true;
    }

    public void Show(){
        _isHidden = false; //show word
    }

    public bool IsHidden(){ //ishidden?
        return _isHidden;
    }

    public string GetDisplayText(){
        if (_isHidden){
            return new string('_', _text.Length);
        }else{
            return _text;
        }
    }
}