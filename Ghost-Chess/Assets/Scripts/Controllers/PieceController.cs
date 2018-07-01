using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

    Dictionary<Piece, GameObject> pieceToGameObjectMap;
    BoardController boardController;
	// Use this for initialization
	void Start () {
        pieceToGameObjectMap = new Dictionary<Piece, GameObject>();
        boardController = BoardController.Instance;
        for (int i = 0; i < boardController.Board.Pieces.Count; i++)
        {
            GameObject goPiece = new GameObject(boardController.Board.Pieces[i].GetType().FullName);
            goPiece.transform.SetParent(this.transform);
            pieceToGameObjectMap.Add(boardController.Board.Pieces[i], goPiece);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
