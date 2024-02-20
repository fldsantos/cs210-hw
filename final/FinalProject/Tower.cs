class Tower : Piece {

    public Tower(string color) : base(color) {
        _limit = 8;
        _pieceCharacter = color=="white"?"♖":"♜";
    }

    public override void CheckAvailableSpots(Piece[,] _spots)
    {
        base.CheckAvailableSpots(_spots);

        CheckUp(_spots, _limit);
        CheckLeft(_spots, _limit);
        CheckDown(_spots, _limit);
        CheckRight(_spots, _limit);

    }
}