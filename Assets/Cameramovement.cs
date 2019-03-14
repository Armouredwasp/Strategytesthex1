using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    private float x, y, z = -10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= 0.1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= 0.1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 0.1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += 0.1f;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Camera.main.orthographicSize - 1.1f * scroll;
        Camera.main.transform.position = pos;

    }
}
