using System;
using System.Collections;
using System.Collections.Generic;

public class Tile
{
    private Piece piece;

    private int x;
    private int y;

    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X
    {
        get
        {
            return x;
        }

       protected set
        {
            x = value;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }

        protected set
        {
            y = value;
        }
    }
}
