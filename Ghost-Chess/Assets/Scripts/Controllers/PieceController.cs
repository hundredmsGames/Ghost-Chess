using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

    #region Singelton
    public static PieceController Instance;
    #endregion


    Dictionary<Piece, GameObject> pieceToGameObjectMap;
    BoardController boardController;
	// Use this for initialization
	void Awake () {
        if (Instance != null)
            return;

        Instance = this;

        pieceToGameObjectMap = new Dictionary<Piece, GameObject>();
        boardController = BoardController.Instance;
        for (int i = 0; i < boardController.Board.Pieces.Count; i++)
        {
            GameObject goPiece = new GameObject(boardController.Board.Pieces[i].GetType().FullName);
            goPiece.transform.SetParent(this.transform);
            goPiece.transform.position = new Vector3(boardController.Board.Pieces[i].Tile.X-3, boardController.Board.Pieces[i].Tile.Y-3);
            goPiece.AddComponent<SpriteRenderer>();
            pieceToGameObjectMap.Add(boardController.Board.Pieces[i], goPiece);
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
