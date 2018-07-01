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
    int height = 8;
    int width = 8;

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
        board = new Board(height, width, BoardStyle.Default);
        tileToGameObjectMap = new Dictionary<Tile, GameObject>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile tile = board.GetTileAt(y,x);
                GameObject tileGO = new GameObject(string.Format("{0},{1} Tile", y, x));
                tileGO.transform.SetParent(this.transform);
                tileGO.transform.position = new Vector3(x-3, y-3, transform.position.z);
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
