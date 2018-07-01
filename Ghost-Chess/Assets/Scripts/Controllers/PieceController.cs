using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

    #region Singelton
    public static PieceController Instance;
    #endregion


    Dictionary<Piece, GameObject> pieceToGameObjectMap;
    BoardController boardController;
    Board board;

	// Use this for initialization
	void Awake ()
    {
        if (Instance != null)
            return;

        Instance = this;
        pieceToGameObjectMap = new Dictionary<Piece, GameObject>();
        boardController = BoardController.Instance;
        board = boardController.Board;

        for (int i = 0; i < board.Pieces.Count; i++)
        {
            Piece piece = board.Pieces[i];
            GameObject pieceGO = new GameObject();
            pieceGO.name = piece.GetType().FullName;
            pieceGO.transform.SetParent(this.transform);
            pieceGO.transform.position = new Vector3(piece.Tile.C, piece.Tile.R);
            pieceGO.AddComponent<SpriteRenderer>();
            pieceToGameObjectMap.Add(boardController.Board.Pieces[i], pieceGO);
        }
	}
	
    public GameObject GetGameObjectOfPiece(Piece piece)
    {
        if(pieceToGameObjectMap.ContainsKey(piece) == false)
        {
            return null;
        }

        return pieceToGameObjectMap[piece];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
