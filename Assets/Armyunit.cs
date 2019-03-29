using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Armyunit : MonoBehaviour
{
    public int UnitID;
    public int ownercountryID;
    public Vector3Int unitposition;
    public GameObject me;
    public Tilemap Tilemap;
    public SpriteRenderer Highlight;
    // Start is called before the first frame update
    void Start()
    {
        Tilemap = GameObject.Find("Unittilemap").GetComponent<Tilemap>();
        UnitID = Convert.ToInt32(me.name.Substring(8));
        ownercountryID = Gamemanage.Unitsdataarray[UnitID].OwnercountryID;
        unitposition = Gamemanage.Unitsdataarray[UnitID].Unitposition;
        Gamemanage.Unitsdataarray[UnitID].Existornot = true;
        Gamemanage.Unitsdataarray[UnitID].Builtornot = true;
        Gamemanage.Unitsdataarray[UnitID].Unitmaxmovementpoint = 3;
        Gamemanage.Unitsdataarray[UnitID].Unitcurrentmovementpoint = 3;
        Gamemanage.Unitsdataarray[UnitID].Unitmaxstrength = 100;
        Gamemanage.Unitsdataarray[UnitID].Unitcurrentstrength = 100;
    }

    // Update is called once per frame
    void Update()
    {
        unitposition = Gamemanage.Unitsdataarray[UnitID].Unitposition;
        me.transform.position = Tilemap.CellToWorld(unitposition);
        if (Gamemanage.Unitsdataarray[UnitID].Existornot == false) { Destroy(me); }
    }
    public void Clicked()
    {
        if(Gamemanage.Selectedunit != null)
        {
            Gamemanage.Selectedunit.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        }
        Highlight.enabled = true;
        Gamemanage.Selectedunit = me;
        Debug.Log(Gamemanage.Unitsdataarray[UnitID].Unitcurrentstrength);
    }
    public void Pointerentered()
    {
        Tilehighlight.staticIsmouseonsomething = true;
    }
    public void Pointerexited()
    {
        Tilehighlight.staticIsmouseonsomething = false;
    }
}
