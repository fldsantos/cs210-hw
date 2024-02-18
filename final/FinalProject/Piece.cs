class Piece {
    private string _position;
    private bool _isCaptured;
    private List<string> _availableSpots;
    private string _color;
    private string _pieceCharacter;

    public Piece(string _char) {
        _pieceCharacter = _char;
    }

    public string Display() {
        return _pieceCharacter;
    }
    public void checkAvailableSpots() {
        _availableSpots.Clear();
    }
}