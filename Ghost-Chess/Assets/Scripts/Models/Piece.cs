using System.Collections;
using System.Collections.Generic;

public class Piece
{
    private string name;
    private Tile tile;
    private PieceColor color;

    public Piece(PieceColor color, int x, int y, string name = "")
    {
        this.color = color;
        tile = new Tile(x, y);
        this.name = name;
    }

    public Tile Tile
    {
        get
        {
            return tile;
        }

    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public PieceColor Color
    {
        get
        {
            return color;
        }

        set
        {
            color = value;
        }
    }
}
