using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private bool CamMovemnt = true;

    public float CamSpeed = 30f;
    public float camBorderthiccnes = 10f;

    public float scrollSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CamMovemnt = !CamMovemnt;

        if (!CamMovemnt)
            return;

     if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * CamSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") )
        {
            transform.Translate(Vector3.back * CamSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") )
        {
            transform.Translate(Vector3.left * CamSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") )
        {
            transform.Translate(Vector3.right * CamSpeed * Time.deltaTime, Space.World);
        }

        float Scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= Scroll * 100 * scrollSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
