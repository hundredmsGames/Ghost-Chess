using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    #region Singelton
    static public BoardController Instance;
    #endregion

    Dictionary<Tile, GameObject> tileToGameObjectMap;
    Board board;
    int rows = 8;
    int cols = 8;

    public Board Board
    {
        get
        {
            return board;
        }

        protected set
        {
            board = value;
        }
    }

    // Use this for initialization
    void OnEnable()
    {
        if (Instance != null)
            return;

        Instance = this;
        board = new Board(rows, cols, BoardStyle.Default);
        tileToGameObjectMap = new Dictionary<Tile, GameObject>();

        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                Tile tile = board.GetTileAt(r, c);
                GameObject tileGO = new GameObject();
                tileGO.name = string.Format("{0},{1} Tile", c, r);
                tileGO.transform.SetParent(this.transform);
                tileGO.transform.position = new Vector3(r, c, transform.position.z);
                tileGO.AddComponent<SpriteRenderer>();
                tileToGameObjectMap.Add(tile, tileGO);
            }
        }
    }

    public GameObject GetGameObjectOfTile(Tile tile)
    {
        if (tileToGameObjectMap.ContainsKey(tile) == false)
            return null;
        
        return tileToGameObjectMap[tile];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
