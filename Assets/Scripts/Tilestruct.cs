using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tilestruct
{
    public int TileID;
    public Vector3Int Tileposition;
    public string Tilename;
    public string Tiletype;//0;Inhospitable,1;Uninhabited,2;Rural,3;City,4;Castle
    public string Tileterrain;//0:Sea,1;Plains,2;Forest,3;Hills,4;Mountains
    public double Tilepop;
    public double Tileciv;
    public double Tilemil;
    public int Tileowner;
}
