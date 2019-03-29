using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countryvaluehandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double civprocap = 0;
        double milprocap = 0;
        double food = 0;
        double indmaterial = 0;
        for (int i = 0; i < Gamemanage.Mapsizex*Gamemanage.Mapsizey; i++)
        {
            if (Gamemanage.Maparray[i].Tileowner == Gamemanage.Turncountry & Gamemanage.Maparray[i].Tiletype == "Rural")
            {
                food += Gamemanage.Maparray[i].Tileciv;
                indmaterial += Gamemanage.Maparray[i].Tilemil;
            }
            if (Gamemanage.Maparray[i].Tileowner == Gamemanage.Turncountry & (Gamemanage.Maparray[i].Tiletype == "Castle" | Gamemanage.Maparray[i].Tiletype == "City"))
            {
                civprocap += Gamemanage.Maparray[i].Tileciv;
                milprocap += Gamemanage.Maparray[i].Tilemil;
            }
        }
        Gamemanage.Countryarray[Gamemanage.Turncountry].industrialmaterialproduction = indmaterial;
        Gamemanage.Countryarray[Gamemanage.Turncountry].foodproduction = food;
        Gamemanage.Countryarray[Gamemanage.Turncountry].civilindustryCap = civprocap;
        Gamemanage.Countryarray[Gamemanage.Turncountry].militaryindustryCap = milprocap;
    }
}
