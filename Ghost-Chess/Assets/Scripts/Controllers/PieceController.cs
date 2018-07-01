using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {

    Dictionary<Piece, GameObject> pieceToGameObjectMap;
    int pieceCount=16;
	// Use this for initialization
	void Start () {
        pieceToGameObjectMap = new Dictionary<Piece, GameObject>();

        for (int i = 0; i < pieceCount; i++)
        {
            Piece piece = new Piece();
            GameObject pieceGO = new GameObject();
            pieceGO.AddComponent<SpriteRenderer>();
            pieceGO.transform.SetParent(this.transform);
            pieceToGameObjectMap.Add(piece, pieceGO);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
