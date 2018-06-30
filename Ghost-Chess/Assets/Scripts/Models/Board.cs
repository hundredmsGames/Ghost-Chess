using System.Collections;
using System.Collections.Generic;

public class Board
{
    Tile[,] tiles;

    public Board(int rows, int cols)
    {
        tiles = new Tile[rows, cols];
    }
}
