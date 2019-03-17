using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tileclick : MonoBehaviour
{
    public TileBase tile4;
    Tilemap Terrainmap;
    private Vector3 pa;
    // Start is called before the first frame update
    void Start()
    {
        Vector3Int PP = new Vector3Int (0, 0, 0);
        Terrainmap = GetComponent<Tilemap>();
    }
    

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int Clickedcell = Terrainmap.WorldToCell(Mousemovement.mouseclickedposition);
            Terrainmap.SetTile(Clickedcell, tile4);
            Debug.Log(Clickedcell);


        };
    }
}

