using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activeswitch : MonoBehaviour
{
    public GameObject target;
    public void openclose()
    {
        target.SetActive(!target.activeSelf);
    }
}
