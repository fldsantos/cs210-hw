class King : Piece {
    
    public King(string color) : base(color) {
        _limit = 1;
        _pieceCharacter = color=="white"?"♔":"♚";
    }

    public override void CheckAvailableSpots(Piece[,] _spots)
    {
        base.CheckAvailableSpots(_spots);
        CheckUpLeft(_spots, _limit);
        CheckUpRight(_spots, _limit);
        CheckDownLeft(_spots, _limit);
        CheckDownRight(_spots, _limit);
        CheckUp(_spots, _limit);
        CheckDown(_spots, _limit);
        CheckLeft(_spots, _limit);
        CheckRight(_spots, _limit);
        
        if(_color == "white") {
            _allWhiteMovableSpots.AddRange(_availableSpots);
        } else {
            _allBlackMovableSpots.AddRange(_availableSpots);
        }
        
    }
}