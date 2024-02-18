class Board {
    private List<Piece> _pieces;

    private Piece[,] _spots = new Piece[8, 8];

    public Board() {
        _spots[0,0] = new Piece("T"); //Tower
        _spots[1,0] = new Piece("H"); //Horse
        _spots[2,0] = new Piece("B"); //Bishop
        _spots[3,0] = new Piece("Q"); //Queen
        _spots[4,0] = new Piece("K"); //King
        _spots[5,0] = new Piece("B"); //Bishop
        _spots[6,0] = new Piece("H"); //Horse
        _spots[7,0] = new Piece("T"); //Tower
        for (int i = 0; i < 8; i++) { _spots[i, 1] = new Piece("P"); /* Pawn*/}

        for (int i = 0; i < 8; i++) { _spots[i, 6] = new Piece("P"); /* Pawn*/}
        _spots[0,7] = new Piece("T"); //Tower
        _spots[1,7] = new Piece("H"); //Horse
        _spots[2,7] = new Piece("B"); //Bishop
        _spots[3,7] = new Piece("Q"); //Queen
        _spots[4,7] = new Piece("K"); //King
        _spots[5,7] = new Piece("B"); //Bishop
        _spots[6,7] = new Piece("H"); //Horse
        _spots[7,7] = new Piece("T"); //Tower
    }

    public void DisplayBoard() {
        Console.WriteLine("    A   B   C   D   E   F   G   H");
        for (int y = 0; y < 8; y++) {
            Console.Write($"{y} ");
            for (int x = 0; x < 8; x++) {
                if(_spots[x, y]!=null) {
                    Console.Write($"[{_spots[x,y].Display()} ]");
                } else {
                    Console.Write("[  ]");
                }
                
            }
            Console.WriteLine("");
        }
    }
}