using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;


[Serializable]
public class Datasaver : ISerializationCallbackReceiver
{
    //シングルトンだかを実現
    
    private static Datasaver _instance = null;
    public static Datasaver Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Datasaver();
            }
            return _instance;
        }
    }

    public static string _jsonText = "";
    public static string ExportingText = "";

    public void DefaultLoad()
    {
        for (int i = 0; i < 4; i++)
        {
            Gamemanage.Countryarray[i] = JsonUtility.FromJson<Countrystruct>(File.ReadAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Country\Country" + i+".json"));
        }
        Gamemanage.Cmap = JsonUtility.FromJson<Mapstruct>(File.ReadAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Mapproperty.json"));
        for (int i = 0; i < Gamemanage.Mapsizex* Gamemanage.Mapsizey; i++)
        {
            Gamemanage.Maparray[i] = JsonUtility.FromJson<Tilestruct>(File.ReadAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\defaultmap\Cell" + i + ".json"));
       }
        for (int i = 0; i < 400; i++)
        {
            if (!(File.Exists(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Units\Armyunits\Armyunit" + i + ".json")))
                {
                break;
            }
            else Gamemanage.Unitsdataarray[i] = JsonUtility.FromJson<Unitdatastruct>(File.ReadAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Units\Armyunits\Armyunit" + i + ".json"));
        }
    }

    public void DefaultSave()
    {
        for (int i = 0; i < 4; i++)
        {
            File.WriteAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Country\Country"+i+".json", JsonUtility.ToJson(Gamemanage.Countryarray[i]));
        }
        File.WriteAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Mapproperty.json", JsonUtility.ToJson(Gamemanage.Cmap));
        for (int i = 0; i < Gamemanage.Mapsizex * Gamemanage.Mapsizey; i++)
        {
            File.WriteAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\defaultmap\Cell" + i+".json", JsonUtility.ToJson(Gamemanage.Maparray[i]));
        }
        for (int i = 0; i < 400; i++)
        {
            if (Gamemanage.Unitsdataarray[i].Existornot)
            {
                File.WriteAllText(@"C:\Users\TAKUMI\Documents\My Games\The best game ever\debug\Savegames\Defaultgame\Units\Armyunits\Armyunit" + i + ".json", JsonUtility.ToJson(Gamemanage.Unitsdataarray[i]));
            }
        }
    }

    public void OnBeforeSerialize()
    {

    }
    public void OnAfterDeserialize()
    {

    }
}
