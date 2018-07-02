using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    GameObject capturedGO;
    Piece capturedPiece;
    Camera cameraMain;

    Board board;
    PieceController pieceController;
    // Use this for initialization
    void Start()
    {
        cameraMain = Camera.main;
        board = BoardController.Instance.Board;
        pieceController = PieceController.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = cameraMain.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Tile currentTile = board[Mathf.RoundToInt(mousePos.y), Mathf.RoundToInt(mousePos.x)];
            ///Debugging
            //Debug.Log(Mathf.RoundToInt(mousePos.x) + " : " + Mathf.RoundToInt(mousePos.y));
            //Debug.Log(currentTile);
            //Debug.Log(currentTile.Piece);
            //if we are on an tile and this tile has a piece on it so we can move the object
            if (currentTile != null && currentTile.Piece != null)
            {
                capturedGO = pieceController.GetGameObjectOfPiece(currentTile.Piece);
                capturedPiece = currentTile.Piece;
            }
            //we have captured the piece so make the tile's piece null
            currentTile.Piece = null;
        }
        if (Input.GetMouseButton(0) && capturedGO != null)
        {
            //move the object
            capturedGO.transform.position = new Vector3(mousePos.x, mousePos.y);

        }

        //IsMoveLegal????
        if (Input.GetMouseButtonUp(0) && capturedGO != null && capturedPiece != null)
        {
            //make sure the piece is the correct position
            capturedGO.transform.position = new Vector3(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
            //we need to set piece when we button up
            board[Mathf.RoundToInt(mousePos.y), Mathf.RoundToInt(mousePos.x)].Piece = capturedPiece;
            capturedGO = null;
            capturedPiece = null;
        }

    }
}
