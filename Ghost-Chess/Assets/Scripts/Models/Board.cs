using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public delegate void BoardStyleChangedHandler(BoardStyle boardStyle);
    public event BoardStyleChangedHandler BoardStyleChanged;
    // This probably should not be here
    private string[,] pieceMap = new string[,]
    {
        { "br", "bn", "bb", "bq", "bk", "bb", "bn", "br" },
        { "bp", "bp", "bp", "bp", "bp", "bp", "bp", "bp" },
        { "em", "em", "em", "em", "em", "em", "em", "em" },
        { "em", "em", "em", "em", "em", "em", "em", "em" },
        { "em", "em", "em", "em", "em", "em", "em", "em" },
        { "em", "em", "em", "em", "em", "em", "em", "em" },
        { "wp", "wp", "wp", "wp", "wp", "wp", "wp", "wp" },
        { "wr", "wn", "wb", "wq", "wk", "wb", "wn", "wr" }
    };

    private BoardStyle style;
    private int width;
    private int height;

    private Tile[,] tiles;
    private List<Piece> pieces;

    public Board(int width, int height, BoardStyle style)
    {
        this.width = width;
        this.height = height;
        this.style = style;
      

        CreateTiles();
        CreatePieces();
        if (BoardStyleChanged != null)
            BoardStyleChanged(style);
    }

    private void CreateTiles()
    {
        tiles = new Tile[width, height];
      
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(x, y);
            }
        }
    }
    public Tile GetTileAt(int x, int y)
    {
        if (x > width || x < 0 || y > height || y < 0)
            return null;

        return tiles[x,y];
    }
    private void CreatePieces()
    {
        if(pieceMap.GetLength(0) != width || pieceMap.GetLength(1) != height)
        {
            Debug.LogError("Piece map does not match with the given width and height.");
            return;
        }

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                CreatePiece(x, y);
            }
        }
    }

    private void CreatePiece(int x, int y)
    {
        pieces = new List<Piece>();
        Piece piece;
        PieceColor color = PieceColor.White;

        if (pieceMap[x, y][0] == 'w')
        {
            color = PieceColor.White;
        }
        else if(pieceMap[x, y][0] == 'b')
        {
            color = PieceColor.Black;
        }

        switch(pieceMap[x, y][1])
        {
            case 'r':
                piece = new Rook(color, x, y);
                break;
            case 'n':
                piece = new Knight(color, x, y);
                break;
            case 'b':
                piece = new Bishop(color, x, y);
                break;
            case 'q':
                piece = new Queen(color, x, y);
                break;
            case 'k':
                piece = new King(color, x, y);
                break;
            case 'p':
                piece = new Pawn(color, x, y);
                break;
            default:
                piece = null;
                break;
        }

        pieces.Add(piece);
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

    public List<Piece> Pieces
    {
        get
        {
            return pieces;
        }

      protected  set
        {
            pieces = value;
        }
    }
}
