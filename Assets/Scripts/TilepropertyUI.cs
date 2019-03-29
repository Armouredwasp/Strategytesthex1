using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TilepropertyUI : MonoBehaviour
{
    public Tilemap terrainmap;
    public Text UItilename;
    public Text UIciv;
    public Text UImil;
    public Text UIpop;
    public Text UItype;
    public Text UIterrain;
    public Text UIID;
    public Text UIOWNER;
    // Start is called before the first frame update
    void Start()
    {
        terrainmap = GetComponent<Tilemap>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        //クリックされたセルに応じて対応するデータを左下のやつに表示
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int Clickedcell = Tilehighlight.Previouscell;
            UItilename.text = "Name:" + Cellhandler.CellpositionToStringdatas(Clickedcell,"NAME");
            UIciv.text = "CIVCAP:" + Cellhandler.CellpositionToDoubledatas(Clickedcell,"CIV");
            UImil.text = "MILCAP:" + Cellhandler.CellpositionToDoubledatas(Clickedcell,"MIL");
            UIpop.text = "Pop:" + Cellhandler.CellpositionToDoubledatas(Clickedcell,"POP");
            UItype.text = "Type:" + Cellhandler.CellpositionToStringdatas(Clickedcell,"TYPE");
            UIterrain.text = "Terrain:" + Cellhandler.CellpositionToStringdatas(Clickedcell,"TERRAIN");
            UIID.text = "ID:" + Cellhandler.CellpositionToInt(Clickedcell,"ID");
            UIOWNER.text = "OWNER:" + Cellhandler.CellpositionToInt(Clickedcell, "OWNER");
            //Debug.Log(Clickedcell);

        };
    }
    public void RefreshtileUI()
    {
        Vector3Int Clickedcell = Tilehighlight.Previouscell;
        UItilename.text = "Name:" + Cellhandler.CellpositionToStringdatas(Clickedcell, "NAME");
        UIciv.text = "CIVCAP:" + Cellhandler.CellpositionToDoubledatas(Clickedcell, "CIV");
        UImil.text = "MILCAP:" + Cellhandler.CellpositionToDoubledatas(Clickedcell, "MIL");
        UIpop.text = "Pop:" + Cellhandler.CellpositionToDoubledatas(Clickedcell, "POP");
        UItype.text = "Type:" + Cellhandler.CellpositionToStringdatas(Clickedcell, "TYPE");
        UIterrain.text = "Terrain:" + Cellhandler.CellpositionToStringdatas(Clickedcell, "TERRAIN");
        UIID.text = "ID:" + Cellhandler.CellpositionToInt(Clickedcell, "ID");
        UIOWNER.text = "OWNER:" + Cellhandler.CellpositionToInt(Clickedcell, "OWNER");
    }
}
