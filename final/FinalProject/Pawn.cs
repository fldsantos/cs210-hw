class Pawn : Piece
{
    private bool _firstPlay = true;
    public Pawn(string color) : base(color)
    {
        _limit = 1;
        _pieceCharacter = color == "white" ? "♙" : "♟";
    }

    public override void CheckAvailableSpots(Piece[,] _spots)
    {
        base.CheckAvailableSpots(_spots);

        if(_color=="black") {
            CheckDown(_spots, _limit);
            CheckDownLeft(_spots, _limit);
            CheckDownRight(_spots, _limit);
        } else {
            CheckUp(_spots, _limit);
            CheckUpLeft(_spots, _limit);
            CheckUpRight(_spots, _limit);
        }

        
    }

    protected override void CheckUp(Piece[,] _spots, int limit)
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
    protected override void CheckDown(Piece[,] _spots, int limit)
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
    protected override void CheckUpLeft(Piece[,] _spots, int limit)
    {

        int i = 1;
        int y = _yPosition - 1;

        try
        {

            for (int x = _xPosition - 1; x >= 0; x--)
            {

                if ((_spots[x, y] != null) && (_spots[x, y].GetColor() != _color))
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
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
    protected override void CheckUpRight(Piece[,] _spots, int limit)
    {
        int i = 1;
        int y = _yPosition - 1;

        try
        {

            for (int x = _xPosition + 1; x < 8; x++)
            {


                if ((_spots[x, y] != null) && (_spots[x, y].GetColor() != _color))
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
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
    protected override void CheckDownLeft(Piece[,] _spots, int limit)
    {
        int i = 1;
        int y = _yPosition + 1;

        try
        {

            for (int x = _xPosition - 1; x >= 0; x--)
            {


                if ((_spots[x, y] != null) && (_spots[x, y].GetColor() != _color))
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
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
    protected override void CheckDownRight(Piece[,] _spots, int limit)
    {
        int i = 1;
        int y = _yPosition + 1;

        try
        {

            for (int x = _xPosition + 1; x < 8; x++)
            {


                if ((_spots[x, y] != null) && (_spots[x, y].GetColor() != _color))
                {
                    _availableSpots.Add($"{xInterpret[x]}{y + 1}");
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