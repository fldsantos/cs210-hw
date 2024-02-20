class Board {
    private List<Piece> _pieces;
    private string xInterpret = "ABCDEFGH";
    private Piece[,] _spots = new Piece[8, 8];

    public Board() {
        _spots[0,0] = new Tower("black"); //Tower
        _spots[1,0] = new Horse("black"); //Horse
        _spots[2,0] = new Bishop("black"); //Bishop
        _spots[3,0] = new Queen("black"); //Queen
        _spots[4,0] = new King("black"); //King
        _spots[5,0] = new Bishop("black"); //Bishop
        _spots[6,0] = new Horse("black"); //Horse
        _spots[7,0] = new Tower("black"); //Tower
        for (int i = 0; i < 8; i++) { _spots[i, 1] = new Pawn("black"); /* Pawn*/}

        for (int i = 0; i < 8; i++) { _spots[i, 6] = new Pawn("white"); /* Pawn*/}
        _spots[0,7] = new Tower("white"); //Tower
        _spots[1,7] = new Horse("white"); //Horse
        _spots[2,7] = new Bishop("white"); //Bishop
        _spots[3,7] = new Queen("white"); //Queen
        _spots[4,7] = new King("white"); //King
        _spots[5,7] = new Bishop("white"); //Bishop
        _spots[6,7] = new Horse("white"); //Horse
        _spots[7,7] = new Tower("white"); //Tower
    }

    public void Run() {
        string inp;

        while(true) {
            DisplayBoard();
            Console.Write("which should move? " );
            inp = Console.ReadLine();
            ExecuteCommand(inp);
            Console.Clear();
        }
        
    }

    public void DisplayBoard() {
        Console.WriteLine("    A   B   C   D   E   F   G   H");
        for (int y = 0; y < 8; y++) {
            Console.Write($"{y+1} ");
            for (int x = 0; x < 8; x++) {
                if(_spots[x, y]!=null) {
                    Console.Write($"[{_spots[x,y].Display()} ]");
                    _spots[x, y].UpdatePosition(x, y);
                    _spots[x, y].CheckAvailableSpots(_spots);

                } else {
                    Console.Write("[  ]");
                }

            }
            Console.WriteLine("");
        }
    }

    public void ExecuteCommand(string command) {
        try {
            string[] coords = command.Split(" to ");

            string location = coords[0];
            string destination = coords[1];

            int xLocation = xInterpret.IndexOf(Char.ToString(location[0]).ToUpper());
            int yLocation = Int32.Parse(Char.ToString(location[1]))-1;

            int xDestination = xInterpret.IndexOf(Char.ToString(destination[0]).ToUpper());
            int yDestination = Int32.Parse(Char.ToString(destination[1]))-1;

            if(_spots[xLocation, yLocation]._availableSpots.Contains(destination.ToUpper())) {
                _spots[xDestination, yDestination] = _spots[xLocation, yLocation];
                _spots[xLocation, yLocation] = null;
            } else {
                Console.WriteLine("Invalid Destination");
                Thread.Sleep(1000);
            }

        } catch(Exception e) {
            Console.WriteLine("Invalid Command");
            Console.WriteLine(e);
            Thread.Sleep(1000);
        }
        
    }
}