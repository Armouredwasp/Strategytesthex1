using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tilehighlight : MonoBehaviour
{
    public Tilemap highlightmap;
    public TileBase highlight;
    public static Vector3Int Previouscell;
    public bool Ismouseonsomething;
    public static bool staticIsmouseonsomething;
    public InputField inputFieldaaa;
    string typeA;
    public void mouseisonsomething()
    {
        Ismouseonsomething = true;
    }
    public void Mouseisnotonsomething()
    {
        Ismouseonsomething = false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void LateUpdate()
    {
        //クリックされたタイルを光らせる
        if (Input.GetMouseButtonDown(0)&!Ismouseonsomething&!staticIsmouseonsomething)
        {
            typeA = inputFieldaaa.text;
            Vector3Int Clickedcell = highlightmap.WorldToCell(Mousemovement.mouseclickedposition);
            highlightmap.SetTile(Previouscell, null);
            if (Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell,"ID")].Tileterrain == "")
            {
                highlightmap.SetTile(Clickedcell, null);
            }
            else
            {
                highlightmap.SetTile(Clickedcell, highlight);
            }
            Previouscell = Clickedcell;
            //Debug.Log(Clickedcell);
            //Debug.Log(Gamemanage.Cells[321].Tileposition);
            //Debug.Log(Gamemanage.Cells[321].TileID);
        }
        if(Input.GetMouseButton(2))
        {
            Vector3Int Clickedcell = highlightmap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            switch (typeA)
            {
                case "Plains":
                    Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell, "ID")].Tileterrain = "Plains";
                    break;
                case "Rural":
                    Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell, "ID")].Tiletype = "Rural";
                    break;
                case "City":
                    Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell, "ID")].Tiletype = "City";
                    break;
                case "Castle":
                    Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell, "ID")].Tiletype = "Castle";
                    break;
                case "Remove":
                    Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell, "ID")].Tileterrain = "";
                    Gamemanage.Maparray[Cellhandler.CellpositionToInt(Clickedcell, "ID")].Tiletype = "";
                    break;
                default:
                    break;

            }
        }
    }
}
