using System;
using System.IO.Compression;

class Entry {
    public string _date;
    public string _prompt;
    string _filename = "prompts.txt";
    public string _text;

    public Entry() {
        _date = DateTime.Today.ToString();
        _prompt = GetPrompt();
    }

    public Entry(bool prompt) {
        _date = DateTime.Today.ToString("d");
        _prompt = prompt?GetPrompt():_prompt = "";
    }

    public string GetPrompt() {
        string[] lines = System.IO.File.ReadAllLines(_filename);
        Random rnd = new Random();

        return lines[rnd.Next(0, lines.Length)];
    }
    
}