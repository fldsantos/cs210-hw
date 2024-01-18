using System;

class Journal {

    public List<Entry> _entries = new List<Entry>();
    string _filename = "entries.txt";


    public void DisplayAllEntries() {
        int i = 0;
        foreach(Entry entry in _entries) {
            Console.WriteLine($"ID: {i}, Date: {entry._date}, Prompt: {entry._prompt}, Text: {entry._text}");
            i++;
        }
    }
    public void addNewEntry() {
        _entries.Add(new Entry());
    }

    public void addNewEntry(bool prompt) {
        _entries.Add(new Entry(prompt));
    }

    public void addTextToEntry(string text) {
        _entries[_entries.Count-1]._text = text;
    }

    public void saveEntries() {
        using (StreamWriter outputFile = new StreamWriter(_filename)) {
            foreach (Entry entry in _entries) {
                outputFile.WriteLine($"{entry._date}, {entry._prompt}, {entry._text}");
            }
        }
    }

    public void loadEntries() {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines) {
            string[] parts = line.Split(",");
            addNewEntry();
            addTextToEntry(parts[2]);
            _entries[_entries.Count-1]._date = parts[0];
            _entries[_entries.Count-1]._prompt = parts[1];
        }
    }

    public void removeEntry(int index) {
        _entries.RemoveAt(index);
        saveEntries();
    }
}