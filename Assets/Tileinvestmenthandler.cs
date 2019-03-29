using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tileinvestmenthandler : MonoBehaviour
{
    public GameObject Armyunits;
    public void Investciv()
    {
        int CellID = Cellhandler.CellpositionToInt(Tilehighlight.Previouscell, "ID");
        switch (Cellhandler.CellpositionToStringdatas(Tilehighlight.Previouscell, "TYPE"))
        {
            case "Rural":
                if (!(Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct < Gamemanage.Maparray[CellID].Tileciv + 1&!(Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial< Gamemanage.Maparray[CellID].Tileciv + 1)))
                {
                    Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial -= Gamemanage.Maparray[CellID].Tileciv +1;
                    Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct -= Gamemanage.Maparray[CellID].Tileciv + 1;
                    Gamemanage.Maparray[CellID].Tileciv += 1;
                }
                break;
            case "City":
                if (!(Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct < Gamemanage.Maparray[CellID].Tileciv *2 & Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial < Gamemanage.Maparray[CellID].Tileciv *2))
                {
                    Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial -= Gamemanage.Maparray[CellID].Tileciv * 2;
                    Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct -= Gamemanage.Maparray[CellID].Tileciv *2;
                    Gamemanage.Maparray[CellID].Tileciv +=1;
                }
                break;
            case "Castle":
                if (!(Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct < Gamemanage.Maparray[CellID].Tileciv * 1.5 & Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial < Gamemanage.Maparray[CellID].Tileciv *1.5))
                {
                    Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial -= Gamemanage.Maparray[CellID].Tileciv * 1.5;
                    Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct -= Gamemanage.Maparray[CellID].Tileciv * 1.5;
                    Gamemanage.Maparray[CellID].Tileciv +=1;
                }
                break;
        }
    }
    public void Investmil()
    {
        int CellID = Cellhandler.CellpositionToInt(Tilehighlight.Previouscell, "ID");
        switch (Cellhandler.CellpositionToStringdatas(Tilehighlight.Previouscell, "TYPE"))
        {
            case "Rural":
                if (!(Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct < Gamemanage.Maparray[CellID].Tilemil + 1)&!(Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial < Gamemanage.Maparray[CellID].Tilemil + 1))
                {
                    Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial -= Gamemanage.Maparray[CellID].Tilemil + 1;
                    Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct -= Gamemanage.Maparray[CellID].Tilemil + 1;
                    Gamemanage.Maparray[CellID].Tilemil += 1;
                }
                break;
            case "City":
                if (!(Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct < Gamemanage.Maparray[CellID].Tileciv * 2 & Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial < Gamemanage.Maparray[CellID].Tileciv * 2))
                {
                    Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial -= Gamemanage.Maparray[CellID].Tilemil * 2;
                    Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct -= Gamemanage.Maparray[CellID].Tilemil * 2;
                    Gamemanage.Maparray[CellID].Tilemil += 1;
                }
                break;
            case "Castle":
                if (!(Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct < Gamemanage.Maparray[CellID].Tileciv * 1.5 & Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial < Gamemanage.Maparray[CellID].Tileciv * 1.5))
                {
                    Gamemanage.Countryarray[Gamemanage.Turncountry].Currentindustrialmaterial -= Gamemanage.Maparray[CellID].Tilemil * 1.5;
                    Gamemanage.Countryarray[Gamemanage.Turncountry].currentcivilproduct -= Gamemanage.Maparray[CellID].Tilemil * 1.5;
                    Gamemanage.Maparray[CellID].Tilemil += 1;
                }
                break;
        }
    }
    public void setowner()
    {
        Gamemanage.Maparray[Cellhandler.CellpositionToInt(Tilehighlight.Previouscell, "ID")].Tileowner = Gamemanage.Turncountry;
    }
    public void Buildunit()
    {
        if ((Cellhandler.CellpositionToStringdatas(Tilehighlight.Previouscell, "TYPE")=="Castle")&((Cellhandler.CellpositionToInt(Tilehighlight.Previouscell, "OWNER") == Gamemanage.Turncountry)))
        {
            for (int i = 0; i < 400; i++)
            {
                if (!Gamemanage.Unitsdataarray[i].Existornot)
                {
                    Gamemanage.Unitsdataarray[i].OwnercountryID = Gamemanage.Turncountry;
                    Gamemanage.Unitsdataarray[i].Unitposition = Gamemanage.Maparray[Cellhandler.CellpositionToInt(Tilehighlight.Previouscell, "ID")].Tileposition;
                    GameObject I = Instantiate(Armyunits);
                    I.name = "Armyunit" + i;
                    break;
                }
            }
        }

    }
}