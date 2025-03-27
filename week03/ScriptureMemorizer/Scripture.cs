class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    //constructor
    public Scripture(Reference reference, string text){
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string word in words){
            _words.Add(new Word(word));
        }
    }

    //methods
    public void HideRandomWords(int numberToHide){
        Random random = new Random();
        int count = 0;

        //Check if there are still visible words 
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        while (count < numberToHide && visibleWords.Count > 0){
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            count++;
            //Update the list of visible words
            visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        }
    }

    public string GetDisplayText(){
        string verseText = "";

        foreach (Word word in _words){
            verseText += word.GetDisplayText() + " ";
        }
        return _reference.GetDisplayText() + " - " + verseText.Trim();
    }

    public bool IsCompletelyHidden(){
        foreach (Word word in _words){
            if (!word.IsHidden()){
                return false;
            }
        }return true;
    }
}