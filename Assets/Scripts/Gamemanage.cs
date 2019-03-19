using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanage : MonoBehaviour
{

    public Text UICturntext;
    public Text UICtreasurytext;
    public Text UICtext;
    public Text UICmanpowertext;
    public static Countrystruct c0;
    public static Mapstruct Cmap;

    // Start is called before the first frame update
    void Start()
    {
        c0.countryID = 0;
        c0.treasury = 100;
        c0.manpower = 1000;
        c0.treasuryincome = 6.73;
        c0.manpowerincome = 137;
        c0.countryname = "Prussia";
        Cmap.Cturn = 1;
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();
    }
    public void end()
    {
        Cmap.Cturn += 1;
        Debug.Log("Turnended");
        Refreshcountryvalue();
        Debug.Log(c0.treasury);
        Debug.Log(c0.manpower);
    }

    public void RefreshUI()
    {
        UICturntext.text = "Turn:" + Cmap.Cturn.ToString();
        UICtreasurytext.text = "Treasury:" + c0.treasury.ToString() + " + " + c0.treasuryincome.ToString();
        UICmanpowertext.text = "Manpower:" + c0.manpower.ToString() + " + " + c0.manpowerincome.ToString();
    }
    public void Refreshcountryvalue()
    {
        c0.treasury += c0.treasuryincome;
        c0.manpower += c0.manpowerincome;
    }

}
