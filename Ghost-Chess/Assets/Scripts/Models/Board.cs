using System.Collections;
using System.Collections.Generic;

public class Board
{
    private BoardStyle style;
    private int width;
    private int height;

    private Tile[,] tiles;

    public Board(int width, int height, BoardStyle style)
    {
        this.width = width;
        this.height = height;
        this.style = style;

        CreateTiles();
        CreatePieces();
    }

    private void CreateTiles()
    {
        tiles = new Tile[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; x++)
            {
                tiles[x, y] = new Tile(x, y);
            }
        }
    }

    private void CreatePieces()
    {

    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public BoardStyle Style
    {
        get { return style; }
        set { style = value; }
    }
}
