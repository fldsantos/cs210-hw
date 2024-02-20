class Bishop : Piece {
    
    public Bishop(string color) : base(color) {
        _limit = 8;
        _pieceCharacter = color=="white"?"♗":"♝";
    }

    public override void CheckAvailableSpots(Piece[,] _spots)
    {
        base.CheckAvailableSpots(_spots);
        CheckUpLeft(_spots, _limit);
        CheckUpRight(_spots, _limit);
        CheckDownLeft(_spots, _limit);
        CheckDownRight(_spots, _limit);
        if(_color == "white") {
            _allWhiteMovableSpots.AddRange(_availableSpots);
        } else {
            _allBlackMovableSpots.AddRange(_availableSpots);
        }
    }
}