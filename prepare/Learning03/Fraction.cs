class Fraction {
    private int _top;
    private int _bottom;

    public Fraction() {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top) {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom) {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop() {
        return _top;
    }

    public void SetTop(int n) {
        _top = n;
    }
    public int GetBottom() {
        return _bottom;
    }

    public void SetBottom(int n) {
        _bottom = n;
    }

    public string GetFractionString() {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue() {
        return Convert.ToDouble(_top)/Convert.ToDouble(_bottom);
    }
}