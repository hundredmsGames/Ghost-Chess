using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSpriteController : MonoBehaviour {

    Board board;
    string piecesSortingLayer = "Pieces";
    PieceController pieceController;
    Dictionary<BoardStyle,KeyValuePair<Sprite,Sprite>> boardStyleToSpriteMap;
	// Use this for initialization
	void Start () {
        board = BoardController.Instance.Board;
        board.BoardStyleChanged += Board_BoardStyleChanged;

        Board_BoardStyleChanged(board.Style);

        pieceController = PieceController.Instance;
        SetPieceSprites();
	}

    private void Board_BoardStyleChanged(BoardStyle boardStyle)
    {
        KeyValuePair<Sprite, Sprite> whiteToBlack = GetSpriteForBoard(boardStyle);
        for (int i = 0; i < board.Height; i++)
        {
            for (int j = 0; j < board.Width; j++)
            {
                
                GameObject tileGO = BoardController.Instance.GetGameObjectOfTile(board.GetTileAt(i, j));
                if ((i * board.Width + j) % 2 == i%2)
                    tileGO.GetComponent<SpriteRenderer>().sprite = whiteToBlack.Key;
                else
                    tileGO.GetComponent<SpriteRenderer>().sprite = whiteToBlack.Value;
            }
        }
    }
    void SetPieceSprites()
    {
        for (int i = 0; i < board.Pieces.Count; i++)
        {
            GameObject pieceGO = pieceController.GetGameObjectOfPiece(board.Pieces[i]);
            pieceGO.GetComponent<SpriteRenderer>().sprite = GetSpriteForPiece(board.Pieces[i]);
            pieceGO.GetComponent<SpriteRenderer>().sortingLayerName = piecesSortingLayer;

        }
    }

    private Sprite GetSpriteForPiece(Piece piece)
    {
        return Resources.Load<Sprite>(string.Format("Pieces\\{0}_{1}{2}", board.Style,piece.Color.ToString(), piece.Name));
    }

    // Update is called once per frame
    void Update () {
		
	}

    

    public KeyValuePair<Sprite,Sprite> GetSpriteForBoard(BoardStyle boardStyle)
    {
        Sprite spriteWhite = Resources.Load<Sprite>(string.Format("BoardStyles\\{0}_White",boardStyle));
        Sprite spriteBlack = Resources.Load<Sprite>(string.Format("BoardStyles\\{0}_Black", boardStyle));
        
        return new KeyValuePair<Sprite, Sprite>(spriteWhite,spriteBlack);
    }
}
