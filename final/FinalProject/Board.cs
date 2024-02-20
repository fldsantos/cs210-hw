using System.Text.RegularExpressions;

class Board
{
    private Piece _configPiece = new Piece("white");
    private bool _checkmate = false;
    private List<Piece> _capturedBlackPieces = new List<Piece>();
    private List<Piece> _capturedWhitePieces = new List<Piece>();
    private int[] _whiteKingCoords = new int[2];
    private int[] _blackKingCoords = new int[2];
    private string _turn = "White";
    private string xInterpret = "ABCDEFGH";
    private Piece[,] _spots = new Piece[8, 8];

    public Board()
    {
        _spots[0, 0] = new Tower("black"); //Tower
        _spots[1, 0] = new Horse("black"); //Horse
        _spots[2, 0] = new Bishop("black"); //Bishop
        _spots[3, 0] = new Queen("black"); //Queen
        _spots[4,0] = new King("black"); //King
        _spots[5, 0] = new Bishop("black"); //Bishop
        _spots[6, 0] = new Horse("black"); //Horse
        _spots[7, 0] = new Tower("black"); //Tower
        for (int i = 0; i < 8; i++) { _spots[i, 1] = new Pawn("black"); /* Pawn*/}


        for (int i = 0; i < 8; i++) { _spots[i, 6] = new Pawn("white"); /* Pawn*/}
        _spots[0, 7] = new Tower("white"); //Tower
        _spots[1, 7] = new Horse("white"); //Horse
        _spots[2, 7] = new Bishop("white"); //Bishop
        _spots[3, 7] = new Queen("white"); //Queen
        _spots[4,7] = new King("white"); //King
        _spots[5, 7] = new Bishop("white"); //Bishop
        _spots[6, 7] = new Horse("white"); //Horse
        _spots[7, 7] = new Tower("white"); //Tower
    }

    public void Run()
    {
        _checkmate = false;
        string inp;
        string checkMessage = "";

        while (!_checkmate)
        {
            Console.Clear();
            DisplayBoard();
            Console.WriteLine("");
            Console.Write($"{checkMessage}{_turn}'s turn! What is your move? ");
            Console.WriteLine("");

            inp = Console.ReadLine();
            ExecuteCommand(inp);
            Console.Clear();
        }

    }

    protected void DisplayCapturedWhitePieces()
    {
        Console.Write("     Captured White Pieces: ");
        foreach (Piece piece in _capturedWhitePieces)
        {
            Console.Write($"{piece.Display()} ");
        }
    }
    protected void DisplayCapturedBlackPieces()
    {
        Console.Write("     Captured Black Pieces: ");
        foreach (Piece piece in _capturedBlackPieces)
        {
            Console.Write($"{piece.Display()} ");
        }
    }

    public void DisplayBoard()
    {
        _configPiece.ClearAllWhiteMovableSpots();
        _configPiece.ClearAllBlackMovableSpots();

        Console.WriteLine("    A   B   C   D   E   F   G   H");
        for (int y = 0; y < 8; y++)
        {
            Console.Write($"{y + 1} ");
            for (int x = 0; x < 8; x++)
            {
                if (_spots[x, y] != null)
                {
                    Console.Write($"[{_spots[x, y].Display()} ]");
                    _spots[x, y].UpdatePosition(x, y);
                    _spots[x, y].CheckAvailableSpots(_spots);

                    if (_spots[x, y].ToString() == "King")
                    {
                        if (_spots[x, y].GetColor() == "white")
                        {
                            _whiteKingCoords[0] = x;
                            _whiteKingCoords[1] = y;
                        }
                        else
                        {
                            _blackKingCoords[0] = x;
                            _blackKingCoords[1] = y;
                        }
                    }

                }
                else
                {
                    Console.Write("[  ]");
                }
                if (y == 0 && x == 7) { DisplayCapturedBlackPieces(); }
                if (y == 7 && x == 7) { DisplayCapturedWhitePieces(); }

            }
            Console.WriteLine("");
        }
        _configPiece.DistinctWhiteMovableSpots();
        _configPiece.DistinctBlackMovableSpots();

        _configPiece.CheckForThreatOnWhite(_whiteKingCoords, _spots);
        _configPiece.CheckForThreatOnBlack(_blackKingCoords, _spots);
    }

    public void ExecuteCommand(string command)
    {

        if(command=="surrender") {
            if(_turn=="White") {
                Console.WriteLine("Checkmate! Black Wins!");
                _checkmate = true;
                Thread.Sleep(5000);
            } else {
                Console.WriteLine("Checkmate! White Wins!");
                _checkmate = true;
                Thread.Sleep(5000);
            }
        }

        try
        {
            string[] coords = command.Split(" to ");

            string location = coords[0];
            string destination = coords[1];

            int xLocation = xInterpret.IndexOf(Char.ToString(location[0]).ToUpper());
            int yLocation = Int32.Parse(Char.ToString(location[1])) - 1;

            int xDestination = xInterpret.IndexOf(Char.ToString(destination[0]).ToUpper());
            int yDestination = Int32.Parse(Char.ToString(destination[1])) - 1;

            if (_spots[xLocation, yLocation]._availableSpots.Contains(destination.ToUpper()))
            {
                if (_spots[xLocation, yLocation].GetColor() == _turn.ToLower())
                {

                    if (_spots[xDestination, yDestination] != null)
                    {
                        if (_spots[xDestination, yDestination].GetColor() == "white") { _capturedWhitePieces.Add(_spots[xDestination, yDestination]); } else { _capturedBlackPieces.Add(_spots[xDestination, yDestination]); }

                        if (_spots[xDestination, yDestination].ToString() == "King")
                        {
                            if(_spots[xDestination, yDestination].GetColor() == "white") {
                                Console.WriteLine("Checkmate! Black Wins!");
                                _checkmate = true;
                                Thread.Sleep(10000);
                            } else {
                                Console.WriteLine("Checkmate! White Wins!");
                                _checkmate = true;
                                Thread.Sleep(10000);
                            }
                        }
                        
                        _spots[xDestination, yDestination] = null;
                    }

                    _spots[xDestination, yDestination] = _spots[xLocation, yLocation];

                    _spots[xLocation, yLocation] = null;
                    _turn = _turn == "White" ? "Black" : "White";
                }
                else
                {
                    Console.WriteLine($"It's not {_spots[xLocation, yLocation].GetColor()}'s turn!");
                    Thread.Sleep(1000);
                }

            }
            else
            {
                Console.WriteLine("Invalid Destination.");
                Thread.Sleep(1000);
            }

        }
        catch (Exception e)
        {
            if(!_checkmate){Console.WriteLine("Invalid Command.");}
            Thread.Sleep(1000);
        }

    }
}