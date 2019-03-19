using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tilehighlight : MonoBehaviour
{
    public TileBase highlight;
    Tilemap highlightmap;
    public static Vector3Int Previouscell;
    // Start is called before the first frame update
    void Start()
    {
        highlightmap = GetComponent<Tilemap>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int Clickedcell = highlightmap.WorldToCell(Mousemovement.mouseclickedposition);
            highlightmap.SetTile(Previouscell, null);
            highlightmap.SetTile(Clickedcell, highlight);
            Previouscell = Clickedcell;
            //Debug.Log(Clickedcell);


        };
    }
}
