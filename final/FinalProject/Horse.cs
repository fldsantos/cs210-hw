class Horse : Piece
{

    public Horse(string color) : base(color)
    {
        _pieceCharacter = color == "white" ? "♘" : "♞";
    }

    public override void CheckAvailableSpots(Piece[,] _spots)
    {
        base.CheckAvailableSpots(_spots);
        CheckHorseSpots(_spots);

    }

    private void CheckHorseSpots(Piece[,] _spots)
    {
        int[] xSpots = new int[8] { _xPosition - 2, _xPosition - 1, _xPosition + 1, _xPosition + 2, _xPosition - 2, _xPosition - 1, _xPosition + 1, _xPosition + 2 };
        int[] ySpots = new int[8] { _yPosition - 1, _yPosition - 2, _yPosition - 2, _yPosition - 1, _yPosition + 1, _yPosition + 2, _yPosition + 2, _yPosition + 1 };

        for (int i = 0; i < 8; i++)
        {
            try
            {
                if (_spots[xSpots[i], ySpots[i]] == null)
                {
                    _availableSpots.Add($"{xInterpret[xSpots[i]]}{ySpots[i] + 1}");
                }
                else
                {
                    if (_spots[xSpots[i], ySpots[i]].GetColor() != _color)
                    {
                        _availableSpots.Add($"{xInterpret[xSpots[i]]}{ySpots[i] + 1}");
                    }
                }
            }
            catch (Exception e)
            {

            }


        }
    }
}