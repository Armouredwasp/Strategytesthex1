using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellhandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //セルの座標からIntのデータを返す
    public static int CellpositionToInt(Vector3Int Clickedcell, string datatype)
    {
        for (int i = 0; i < Gamemanage.Mapsizex * Gamemanage.Mapsizey; i++)
        {
            if (Gamemanage.Maparray[i].Tileposition == Clickedcell)
            {
                switch (datatype)
                {
                    case "ID": return Gamemanage.Maparray[i].TileID;
                    case "OWNER": return Gamemanage.Maparray[i].Tileowner;
                };
            }
        }
        return -1;
    }
    //セルの座標からstringのデータを返す
    public static string CellpositionToStringdatas(Vector3Int Clickedcell, string datatype)//NAME TYPE TERRAIN
    {
        for (int i = 0; i < Gamemanage.Mapsizex * Gamemanage.Mapsizey; i++)
        {
            if (Gamemanage.Maparray[i].Tileposition == Clickedcell)
            {
                switch (datatype)
                {
                    case "NAME": return Gamemanage.Maparray[i].Tilename;
                    case "TYPE": return Gamemanage.Maparray[i].Tiletype;
                    case "TERRAIN": return Gamemanage.Maparray[i].Tileterrain;
                };
            }
        }
        return "Error";
    }
    //セルの座標からdoubleのデータを返す
    public static double CellpositionToDoubledatas(Vector3Int Clickedcell, string datatype)//POP CIV MIL
    {
        for (int i = 0; i < Gamemanage.Mapsizex * Gamemanage.Mapsizey; i++)
        {
            if (Gamemanage.Maparray[i].Tileposition == Clickedcell)
            {
                switch (datatype)
                {
                    case "POP": return Gamemanage.Maparray[i].Tilepop;
                    case "CIV": return Gamemanage.Maparray[i].Tileciv;
                    case "MIL": return Gamemanage.Maparray[i].Tilemil;
                };
            }
        }
        return -1;
    }
}