class Reference {
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse = 0;
    private int _verseQuantity;

    public Reference(string book, int chapter, int verse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _verseQuantity = 1;
    }
    public Reference(string book, int chapter, int verse, int endVerse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
        _verseQuantity = (endVerse-verse)+1;
    }

    public string GetDisplayText() {
        return _endVerse==0?$"{_book} {_chapter}:{_verse}":$"{_book} {_chapter}:{_verse}-{_endVerse}";
    }

    public int GetVerseQuantity() {
        return _verseQuantity;
    }
}