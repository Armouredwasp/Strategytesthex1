using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.IO;
using System;

public class Gamemanage : MonoBehaviour
{

    public Text UICturntext;
    public Text UICtreasurytext;
    public Text UICcivtext;
    public Text UICmanpowertext;
    public Text UICmiltext;
    public Text UIfoodtext;
    public Text UIindmattext;
    public Text UICountryname;
    public static Countrystruct[] Countryarray = new Countrystruct[5];
    public static Countryclass Country1 = new Countryclass();
    public static Mapstruct Cmap;
    public Tilemap Terrainmap;
    public Tilemap Ownermap;
    public Tilemap Unitmap;
    public TileBase Destinationtile;
    public TileBase Plainstile;
    public Tilemap Buildingmap;
    public TileBase Ruraltile;
    public TileBase Citytile;
    public TileBase Castletile;
    public TileBase Prussia;
    public GameObject Gamamanager;
    public GameObject Govenmentwindow;
    public static int Turncountry = 1;
    public static GameObject Selectedunit;
    TilepropertyUI Tileproperty;
    public GameObject Armyunits;
    public static Unitdatastruct[] Unitsdataarray = new Unitdatastruct[1000];
    Vector3Int Previousdestination;
    Vector3Int Currentdestination;
    public static int Mapsizex = 60;
    public static int Mapsizey = 40;
    public static Tilestruct[] Maparray = new Tilestruct[Mapsizex * Mapsizey];

    // Start is called before the first frame update
    void Start()
    {
        Tileproperty = Gamamanager.GetComponent<TilepropertyUI>();
        debugmapload();
        //generatecells();
        RefreshUI();
        Refreshtile();
    }

    // Update is called once per frame
    void Update()
    {
        Refreshtile();
        RefreshUI();
        Tileproperty.RefreshtileUI();
    }
    void LateUpdate()
    {
        Unitmovement();
    }
    public void end()
    {
        Cmap.Cturn++;

        Refreshcountryvalue(ref Countryarray[Turncountry]);
        if (Turncountry==2)
        {Turncountry = 1;}
        else { Turncountry++; }


    }
    //上の数字を更新する
    public void RefreshUI()
    {
        UICturntext.text = "Turn:" + Cmap.Cturn;
        UICtreasurytext.text = "Treasury:" + Countryarray[Turncountry].treasury.ToString() + " + " + Countryarray[Turncountry].treasuryincome;
        UICmanpowertext.text = "Manpower:" + Countryarray[Turncountry].manpower.ToString() + " + " + Countryarray[Turncountry].manpowerincome;
        UICcivtext.text = "CIV/CAP:"+Countryarray[Turncountry].currentcivilproduct+"/" + Countryarray[Turncountry].civilindustryCap;
        UICmiltext.text = "MIL/CAP:" + Countryarray[Turncountry].currentmilitaryproduct + "/" + Countryarray[Turncountry].militaryindustryCap;
        UIfoodtext.text = "FOOD:" + Countryarray[Turncountry].foodproduction;
        UIindmattext.text = "MAT/CAP:"+Countryarray[Turncountry].Currentindustrialmaterial +"/" + Countryarray[Turncountry].industrialmaterialproduction;
        UICountryname.text = Countryarray[Turncountry].countryname;
    }
    //引数で指定された国のターンエンドにおける処理をする
    public void Refreshcountryvalue(ref Countrystruct country)
    {
        country.treasury += country.treasuryincome;
        country.manpower += country.manpowerincome;
        country.currentcivilproduct = country.civilindustryCap;
        country.currentmilitaryproduct = country.militaryindustryCap;
        country.Currentindustrialmaterial = country.industrialmaterialproduction;
    }
    //セルを構造体配列に割り当てる、現状60*40
    public void generatecells()
    {
        for (int i = 0; i < Mapsizex*Mapsizey; i++)
        {
            Maparray[i].TileID = i;
            Maparray[i].Tileposition.x = i % Mapsizex;
            Maparray[i].Tileposition.y = i / Mapsizex;
            //Debug.Log(Maparray[i].TileID+""+Maparray[i].Tileposition);
        }
    }
    //構造体配列のデータに基づきタイルを張り替える
    public void Refreshtile()
    {
        for (int i = 0; i < Mapsizex * Mapsizey; i++)
        {
            switch (Maparray[i].Tileterrain)
            {
                case "":
                    Terrainmap.SetTile(Maparray[i].Tileposition, null);
                    break;
                case "Plains":
                    Terrainmap.SetTile(Maparray[i].Tileposition, Plainstile);
                    break;

            }

            switch (Maparray[i].Tiletype)
            {
                case "":
                    Buildingmap.SetTile(Maparray[i].Tileposition, null);
                    break;
                case "Rural":
                    Buildingmap.SetTile(Maparray[i].Tileposition, Ruraltile);
                    break;
                case "City":
                    Buildingmap.SetTile(Maparray[i].Tileposition, Citytile);
                    break;
                case "Castle":
                    Buildingmap.SetTile(Maparray[i].Tileposition, Castletile);
                    break;
            }
            switch (Maparray[i].Tileowner)
            {
                case 0:
                    Terrainmap.SetColor(Maparray[i].Tileposition, Color.white);
                    break;
                case 1:
                    Terrainmap.SetColor(Maparray[i].Tileposition, Color.gray);
                    break;
                case 2:
                    Terrainmap.SetColor(Maparray[i].Tileposition, Color.magenta);
                    break;
            }
        }
    }

    public void openclosegovernmentwindow()
    {
        Govenmentwindow.SetActive(!Govenmentwindow.activeSelf);
    }

    public void debugmapsave()
    {
        Cmap.Mapsizex = Mapsizex;
        Cmap.Mapsizey = Mapsizey;
        Cmap.Turncountry = Turncountry;
        Datasaver.Instance.DefaultSave();
    }
    public void debugmapload()
    {
        Datasaver.Instance.DefaultLoad();
        for (int i = 0; i < 400; i++)
        {
            if (Unitsdataarray[i].Existornot& Unitsdataarray[i].Builtornot)
            {
                GameObject I = Instantiate(Armyunits);
                I.name = "Armyunit" + i;
            }
            if (!File.Exists(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Units\Armyunits\Armyunit" + i + ".json"))
            {
                Destroy(GameObject.Find("Armyunit" + i));
                Unitsdataarray[i] = new Unitdatastruct();
            }
        }
    }
    public void Unitmovement()
    {
        if (Input.GetMouseButton(1) & Selectedunit != null)
        {
            Currentdestination = Unitmap.WorldToCell(Mousemovement.mouseclickingposition1);
            Unitmap.SetTile(Previousdestination, null);
            Unitmap.SetTile(Currentdestination, Destinationtile);
            Previousdestination = Currentdestination;
        }
        else
        if (Input.GetMouseButtonUp(1) & Selectedunit != null)
        {
            for (int i = 0; i < 400; i++)
            {
                if (Unitsdataarray[i].Unitposition== Currentdestination)
                {
                    if (!(Unitsdataarray[i].OwnercountryID == Turncountry))
                    {
                        Unitmap.SetTile(Currentdestination, null);
                        Unitlandbattle(Convert.ToInt32(Selectedunit.name.Substring(8)),i);
                        break;
                    }
                    else
                    {
                        Unitmap.SetTile(Currentdestination, null);
                        break;
                    }
                }
            }
            Unitmap.SetTile(Currentdestination, null);
            Unitsdataarray[Convert.ToInt32(Selectedunit.name.Substring(8))].Unitposition = Currentdestination;
        }
    }
    public void Unitlandbattle(int attackerID, int defenderID)
    {
        switch (Diceroll.Roll(3, 1)[0])
        {
            case 0:

                break;
            case 1:
                Unitsdataarray[attackerID].Unitcurrentstrength -= 20;
                Unitsdataarray[defenderID].Unitcurrentstrength -= 50;
                Unitsdataarray[attackerID].Unitposition = Currentdestination;
                Unitsdataarray[defenderID].Unitposition.y = Currentdestination.y-1;
                break;
            case 2:
                Unitsdataarray[defenderID].Builtornot = false;
                Unitsdataarray[defenderID].Existornot = false;
                Unitsdataarray[attackerID].Unitposition = Currentdestination;
                break;
        }
    }

}
