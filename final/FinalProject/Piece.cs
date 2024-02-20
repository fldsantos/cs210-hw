class Piece
{

    protected static List<string> _allBlackMovableSpots = new List<string>();
    protected static List<string> _allWhiteMovableSpots = new List<string>();
    protected static bool _whiteKingInCheck = false;
    protected static bool _blackKingInCheck = false;
    protected int _limit;
    protected int _xPosition;
    protected int _yPosition;
    protected bool _isCaptured = false;
    public List<string> _availableSpots;
    protected string _color;
    protected string _pieceCharacter;
    protected string xInterpret = "ABCDEFGH";

    public Piece(string color)
    {
        _color = color;
        _availableSpots = new List<string>();
    }

    public string GetColor()
    {
        return _color;
    }

    public bool getWhiteKingSafety() {
        return _whiteKingInCheck;
    }
    public bool getBlackKingSafety() {
        return _blackKingInCheck;
    }

    public List<string> GetAllWhiteMovableSpots() {
        return _allWhiteMovableSpots;
    }

    public void ClearAllWhiteMovableSpots() {
        _allWhiteMovableSpots.Clear();
    }

    public void DistinctWhiteMovableSpots(){
        _allWhiteMovableSpots = _allWhiteMovableSpots.Distinct().ToList();
    }
    public List<string> GetAllBlackMovableSpots() {
        return _allBlackMovableSpots;
    }

    public void ClearAllBlackMovableSpots() {
        _allBlackMovableSpots.Clear();
    }

    public void DistinctBlackMovableSpots(){
        _allBlackMovableSpots = _allBlackMovableSpots.Distinct().ToList();
    }

    public void checkForThreatOnWhite(int[] whiteKingCoords, Piece[,] _spots) {

        bool check = false;

        foreach(string spot in _allBlackMovableSpots) {
            if($"{xInterpret[whiteKingCoords[0]]}{whiteKingCoords[1]+1}" == spot) {
                Console.WriteLine("");
                Console.WriteLine("Check!");
                check = true;
                break;
            }
        }
        _whiteKingInCheck = check;
    }
    public void checkForThreatOnBlack(int[] blackKingCoords, Piece[,] _spots) {
        bool check = false;

        foreach(string spot in _allWhiteMovableSpots) {
            if($"{xInterpret[blackKingCoords[0]]}{blackKingCoords[1]+1}" == spot) {
                Console.WriteLine("Check!");
                check = true;
                break;
            }
        }

        _blackKingInCheck = check;
    }

    /*public void RecalculateKingAvailableSpots(int[] whiteKingCoords, int[] blackKingCoords, Piece[,] _spots) {
        //recalculating white king's spots
        foreach(string spot in _spots[whiteKingCoords[0], whiteKingCoords[1]]._availableSpots) {
            if(_allBlackMovableSpots.Contains(spot)) {
                _spots[whiteKingCoords[0], whiteKingCoords[1]]._availableSpots.Remove(spot);
                Console.WriteLine(spot);
            }
        }
    }*/

    

    public void setCaptured() {
        _isCaptured = true;
    }

    public void UpdatePosition(int x, int y)
    {
        _xPosition = x;
        _yPosition = y;
    }

    public string Display()
    {
        return _pieceCharacter;
    }
    public virtual void CheckAvailableSpots(Piece[,] _spots)
    {
        _availableSpots.Clear();
        //_allMovableSpots.Clear();
    }

    protected virtual void CheckLeft(Piece[,] _spots, int limit)
    {

        int i = 1;

        try
        {
            for (int x = _xPosition - 1; x >= 0; x--)
            {
                if (_spots[x, _yPosition] == null)
                {
                    _availableSpots.Add($"{xInterpret[x]}{_yPosition + 1}");
                }
                else
                {

                    if (_spots[x, _yPosition].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[x]}{_yPosition + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
        }
        catch (Exception e)
        {

        }

    }
    protected virtual void CheckRight(Piece[,] _spots, int limit)
    {

        int i = 1;

        try
        {

            for (int x = _xPosition + 1; x < 8; x++)
            {
                if (_spots[x, _yPosition] == null)
                {
                    _availableSpots.Add($"{xInterpret[x]}{_yPosition + 1}");
                }
                else
                {

                    if (_spots[x, _yPosition].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[x]}{_yPosition + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

        }
        catch (Exception e)
        {

        }
    }
    protected virtual void CheckUp(Piece[,] _spots, int limit)
    {

        int i = 1;

        try
        {

            for (int y = _yPosition - 1; y >= 0; y--)
            {
                if (_spots[_xPosition, y] == null)
                {
                    _availableSpots.Add($"{xInterpret[_xPosition]}{y + 1}");
                }
                else
                {

                    if (_spots[_xPosition, y].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[_xPosition]}{y + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

        }
        catch (Exception e)
        {

        }
    }
    protected virtual void CheckDown(Piece[,] _spots, int limit)
    {

        int i = 1;

        try
        {

            for (int y = _yPosition + 1; y < 8; y++)
            {
                if (_spots[_xPosition, y] == null)
                {
                    _availableSpots.Add($"{xInterpret[_xPosition]}{y + 1}");
                }
                else
                {

                    if (_spots[_xPosition, y].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[_xPosition]}{y + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }

        }
        catch (Exception e)
        {

        }
    }
    protected virtual void CheckUpLeft(Piece[,] _spots, int limit)
    {

        int i = 1;
        int y = _yPosition - 1;

        try
        {

            for (int x = _xPosition - 1; x >= 0; x--)
            {
                if (_spots[x, y] == null)
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                }
                else
                {

                    if (_spots[x, y].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
                y--;
            }
        }
        catch (Exception e)
        {

        }
    }
    protected virtual void CheckUpRight(Piece[,] _spots, int limit) {
        int i = 1;
        int y = _yPosition - 1;

        try
        {

            for (int x = _xPosition + 1; x < 8; x++)
            {
                if (_spots[x, y] == null)
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                }
                else
                {

                    if (_spots[x, y].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
                y--;
            }
        }
        catch (Exception e)
        {

        }
    }
    protected virtual void CheckDownLeft(Piece[,] _spots, int limit) {
        int i = 1;
        int y = _yPosition + 1;

        try
        {

            for (int x = _xPosition - 1; x >= 0; x--)
            {
                if (_spots[x, y] == null)
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                }
                else
                {

                    if (_spots[x, y].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
                y++;
            }
        }
        catch (Exception e)
        {

        }
    }
    protected virtual void CheckDownRight(Piece[,] _spots, int limit) {
        int i = 1;
        int y = _yPosition + 1;

        try
        {

            for (int x = _xPosition + 1; x < 8; x++)
            {
                if (_spots[x, y] == null)
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                }
                else
                {

                    if (_spots[x, y].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[x]}{y + 1}");
                    }
                    break;
                }

                if (i == limit)
                {
                    break;
                }
                else
                {
                    i++;
                }
                y++;
            }
        }
        catch (Exception e)
        {

        }
    }
}