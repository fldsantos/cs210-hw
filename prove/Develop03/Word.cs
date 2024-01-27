class Word {
    private string _value = "";
    private bool _hidden = false;

    public Word(string value) {
        _value = value;
    }

    public void hide() {
        _hidden = true;
    }

    public void show() {
        _hidden = false;
    }

    public string GetDisplayText() {
        return _hidden?repeat("_", _value.Length):_value;
    }

    private string repeat(string charater, int length) {
        string repeated = "";
        for (int i = 0; i < length; i++) {
            repeated+=charater;
        }
        return repeated;
    }

    public bool IsHidden() {
        return _hidden;
    }
}