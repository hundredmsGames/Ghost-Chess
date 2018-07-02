using System;
using System.Collections;
using System.Collections.Generic;

public class Tile
{
    private Piece piece;

    private int r;
    private int c;

    public Tile(int r, int c)
    {
        this.r = r;
        this.c = c;
    }

    public int R
    {
        get
        {
            return r;
        }

       protected set
        {
            r = value;
        }
    }

    public int C
    {
        get
        {
            return c;
        }

        protected set
        {
            c = value;
        }
    }

    public Piece Piece
    {
        get
        {
            return piece;
        }

        set
        {
            piece = value;
        }
    }
}
