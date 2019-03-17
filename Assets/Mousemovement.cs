using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousemovement : MonoBehaviour
{
     public static Vector3 mouseclickedposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            Vector3 p = Input.mousePosition;
            mouseclickedposition =Camera.main.ScreenToWorldPoint(p);
            Debug.Log("a");
        };
    }
}
