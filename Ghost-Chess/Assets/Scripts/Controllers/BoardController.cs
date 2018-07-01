using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    Dictionary<Tile, GameObject> tileToGameObjectMap;
    Board board;
    int height = 8;
    int width = 8;
    // Use this for initialization
    void Start()
    {
        board = new Board(height, width);
        tileToGameObjectMap = new Dictionary<Tile, GameObject>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile tile = new Tile(y, x);
                GameObject tileGO = new GameObject(string.Format("{0},{1} Tile",y,x));
                tileGO.transform.SetParent(this.transform);
                tileGO.transform.position = new Vector3(x, y, transform.position.z);
                tileGO.AddComponent<SpriteRenderer>();
                tileToGameObjectMap.Add(tile, tileGO);
            }
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
