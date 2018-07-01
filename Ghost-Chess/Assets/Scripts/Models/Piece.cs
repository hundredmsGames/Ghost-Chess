using System.Collections;
using System.Collections.Generic;

public class Piece
{
    private Tile tile;
    private PieceColor color;

    public Piece(PieceColor color, int x, int y)
    {
        this.color = color;
        tile = new Tile(x, y);
    }
}
