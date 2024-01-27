using System.Security.Principal;

class Scripture {
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private string _text;
    
    public Scripture(Reference reference) {
        bool foundScripture = false;
        _reference = reference;
        string[] _rawScripture = System.IO.File.ReadAllLines("scriptureMastery.txt");

        foreach (string scripture in _rawScripture){
            string[] parts = scripture.Split("/");

            if (parts[0] == _reference.GetDisplayText()) {
                foundScripture = true;
                _text = parts[1];
                string[] words = parts[1].Split(" ");

                foreach (string word in words) {
                    _words.Add(new Word(word));
                }
            }
        }

        if (!foundScripture) {
            Console.WriteLine($"Scripture {_reference.GetDisplayText()} not found in database.");
            Environment.Exit(1);
        }
    }

    public string GetDisplayText() {
        return $"{_reference.GetDisplayText()}: {_text}";
    }

    public void HideRandomWords(int numberToHide) {
        if(!IsCompletelyHidden()){
            _text = "";
            int chosenNumber;
            int chosenNumberCount = 0;
            List<int> numbers = new List<int>();
            Random rnd = new Random();

            while(chosenNumberCount < numberToHide) {
                chosenNumber = rnd.Next(0, _words.Count);

                if(!_words[chosenNumber].IsHidden()) {
                    _words[chosenNumber].hide();
                    chosenNumberCount++;

                }
                if(IsCompletelyHidden()) {
                    break;
                }
            }

            foreach (Word word in _words) {
                _text += $"{word.GetDisplayText()} ";
            }
        }
    }

    public bool IsCompletelyHidden() {
        bool allHidden = true;
        foreach (Word word in _words) {
            allHidden = allHidden && word.IsHidden();
        }
        return allHidden;
    }

    public int GetHiddenWordsNumber() {
        int count = 0;
        foreach(Word word in _words) {
            if(word.IsHidden()) {
                count++;
            }
        }

        return count;
    }
}