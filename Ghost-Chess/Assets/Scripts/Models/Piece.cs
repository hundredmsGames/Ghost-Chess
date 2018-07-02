using System.Collections;
using System.Collections.Generic;

public class Piece
{
    private string name;
    private Tile tile;
    private PieceColor color;
    private Board board;

    public Piece(Board board,PieceColor color, int r, int c, string name = "")
    {
        this.color = color;
        tile = new Tile(r, c);
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
