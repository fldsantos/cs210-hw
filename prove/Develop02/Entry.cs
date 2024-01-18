using System;
using System.IO.Compression;

class Entry {
    public string _date;
    public string _prompt;
    string _filename = "prompts.txt";
    public string _text;

    public Entry() {
        _date = DateTime.Today.ToString();
        _prompt = getPrompt();
    }

    public Entry(bool prompt) {
        _date = DateTime.Today.ToString("d");
        _prompt = prompt?getPrompt():_prompt = "";
    }

    public string getPrompt() {
        string[] lines = System.IO.File.ReadAllLines(_filename);
        Random rnd = new Random();

        return lines[rnd.Next(0, lines.Length)];
    }
    
}