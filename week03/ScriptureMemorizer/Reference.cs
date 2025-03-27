class Reference
{
    private string _book; //name book
    private int _chapter; //number chapter
    private int _verse;
    private int _endVerse;

    //constructors
    public Reference(string book, int chapter, int verse){
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse){
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    //method
    public string GetDisplayText(){
        if (_verse == _endVerse)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}