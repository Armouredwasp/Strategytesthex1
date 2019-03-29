using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousemovement : MonoBehaviour
{
    public static Vector3 mouseclickedposition;
    public static Vector3 mouseclickedposition1;
    public static Vector3 mouseclickedposition2;
    public static Vector3 mouseclickingposition1;
    public static Vector3 mousereleasedposition1;
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
            //Debug.Log("a");
        };
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 c = Input.mousePosition;
            mouseclickedposition1 = Camera.main.ScreenToWorldPoint(c);
            //Debug.Log("a");
        };
        if (Input.GetMouseButtonDown(2))
        {
            Vector3 e = Input.mousePosition;
            mouseclickedposition2 = Camera.main.ScreenToWorldPoint(e);
            //Debug.Log("a");
        };
        if (Input.GetMouseButton(1))
        {
            Vector3 c = Input.mousePosition;
            mouseclickingposition1 = Camera.main.ScreenToWorldPoint(c);
            //Debug.Log("a");
        };
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 c = Input.mousePosition;
            mousereleasedposition1 = Camera.main.ScreenToWorldPoint(c);
            //Debug.Log("a");
        };
    }
}
